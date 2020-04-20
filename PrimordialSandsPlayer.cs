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
using PrimordialSands.Shaders;

namespace PrimordialSands
{
    public class PrimordialSandsPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public static bool hasProjectile;
        public bool claymoreCooldown = false;
        public bool flood = false;
        public bool plague = false;
        public bool splintered = false;
        public bool treeEnt = false;
        public bool infernoSummoned = false;
        public bool reaperRosario = false;
        public bool ZoneSwamp = false;

        public override void ResetEffects()
        {
            claymoreCooldown = false;
            flood = false;
            plague = false;
            splintered = false;
            treeEnt = false;
            reaperRosario = false;
        }
        public override void UpdateDead()
        {
            claymoreCooldown = false;
            flood = false;
            plague = false;
            splintered = false;
            treeEnt = false;
            reaperRosario = false;
        }

        public override void UpdateBiomes()
        {
            ZoneSwamp = (PrimordialSandsWorld.swampTiles > 200);
        }

        public override bool CustomBiomesMatch(Player other)
        {
            PrimordialSandsPlayer modOther = other.GetModPlayer<PrimordialSandsPlayer>(mod);
            return ZoneSwamp == modOther.ZoneSwamp;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            PrimordialSandsPlayer modOther = other.GetModPlayer<PrimordialSandsPlayer>(mod);
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

        public override void UpdateBiomeVisuals()
        {
            //bool useTestShader = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().ZoneSwamp;
            //player.ManageSpecialBiomeVisuals("PrimoridalSands:TestShader", useTestShader, player.Center);
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