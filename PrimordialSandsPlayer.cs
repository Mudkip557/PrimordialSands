using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using PrimordialSands.Dusts;

namespace PrimordialSands
{
    public class PrimordialSandsPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public static bool hasProjectile;
        public bool ankhAmber = false;
        public bool ankhAmeythst = false;
        public bool ankhDiamond = false;
        public bool ankhEmerald = false;
        public bool ankhSapphire = false;
        public bool ankhTopaz = false;

        public bool claymoreCooldown = false;
        public bool elderberryBuff = false;
        public bool flood = false;
        public bool infernoSummoned = false;
        public bool plague = false;
        public bool reaperRosario = false;
        public bool splintered = false;
        public bool treeEnt = false;
        public bool ZoneSwamp = false;

        public override void ResetEffects()
        {
            ankhAmber = false;
            ankhAmeythst = false;
            ankhDiamond = false;
            ankhEmerald = false;
            ankhSapphire = false;
            ankhTopaz = false;

            claymoreCooldown = false;
            elderberryBuff = false;
            flood = false;
            plague = false;
            reaperRosario = false;
            splintered = false;
            treeEnt = false;
        }
        public override void UpdateDead()
        {
            ankhAmber = false;
            ankhAmeythst = false;
            ankhDiamond = false;
            ankhEmerald = false;
            ankhSapphire = false;
            ankhTopaz = false;

            claymoreCooldown = false;
            elderberryBuff = false;
            flood = false;
            plague = false;
            reaperRosario = false;
            splintered = false;
            treeEnt = false;
        }

        public override void UpdateBiomes()
        {
            //ZoneSwamp = (EngulfedIsle.swampTiles > 100);
        }

        public override bool CustomBiomesMatch(Player other)
        {
            PrimordialSandsPlayer modOther = other.GetModPlayer<PrimordialSandsPlayer>();
            return ZoneSwamp == modOther.ZoneSwamp;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            PrimordialSandsPlayer modOther = other.GetModPlayer<PrimordialSandsPlayer>();
            modOther.ZoneSwamp = ZoneSwamp;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneSwamp;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneSwamp = flags[0];
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneSwamp)
            {
                return mod.GetTexture("FloodMapBackground");
            }
            return null;
        }
        private void DrawMist()
        {
            for (int k = (int)Math.Floor(player.position.X / 16) - 55; k < (int)Math.Floor(player.position.X / 16) + 55; k++)
            {
                for (int i = (int)Math.Floor(player.position.Y / 16) - 30; i < (int)Math.Floor(player.position.Y / 16) + 30; i++)
                {
                    if ((!Main.tile[k, i - 1].active() //These tell the dust not to spawn on the specific tiles
                        && !Main.tile[k, i - 2].active()
                        && Main.tile[k, i].active()
                        && Main.tile[k, i].type != TileID.Cactus)
                        || (Main.tile[k, i - 1].type == TileID.Cactus
                        && Main.tile[k, i].type == TileID.Sand)) //Sand is the only tile that it should spawn on, but we'll settle
                    {
                        if (Main.rand.Next(0, 95) == 2)
                        {
                            Dust.NewDust(new Vector2((k - 2) * 16, (i - 1) * 16), 5, 5, DustType<SandDust>());
                        }
                    }
                
                    if (Main.tile[k, i].type == TileID.Cactus 
                        && !Main.tile[k, i - 1].active() 
                        && !Main.tile[k - 1, i].active() 
                        && !Main.tile[k + 1, i].active())
                    {
                        Lighting.AddLight(new Vector2(k * 16, i * 16), new Vector3(1, 1, 1));
                    }
                }
            }
        }

        public override void UpdateBiomeVisuals()
        {
            if (Main.LocalPlayer.ZoneDesert)
            {
                DrawMist();
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (flood)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
            if (flood)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 6;
            }
            if (splintered)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.statDefense /= 4;
            }
            if (elderberryBuff)
            {
                player.statLifeMax2 += 35;
            }
        }
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (flood)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 89, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 1f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.25f;
                b *= 0f;
                fullBright = true;
            }
            if (plague)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 256, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 0.45f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0.567f;
                b *= 0f;
                fullBright = true;
            }
            if (splintered)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 7, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 1f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 0f;
                b *= 0f;
                fullBright = true;
            }
        }
    }
}