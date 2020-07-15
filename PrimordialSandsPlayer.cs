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
using IL.Terraria.GameContent.Events;
using On.Terraria.GameContent.Skies;
using PrimordialSands.Items.Farming.Spades;
using Terraria.ModLoader.IO;

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
        public bool harvestEnchant = false;
        public bool claymoreCooldown = false;
        public bool elderberryBuff = false;
        public bool flood = false;
        public bool infernoSummoned = false;
        public bool isSpade = false;
        public bool plague = false;
        public bool reaperRosario = false;
        public bool screenShake = false;
        public bool screenShakeLight = false;
        public bool signiasPet = false;
        public bool splintered = false;
        public bool treeEnt = false;
        public bool ZoneSwamp = false;

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ItemType<CopperSpade>());
            items.Add(item);
        }
        public override void ResetEffects()
        {
            ankhAmber = false;
            ankhAmeythst = false;
            ankhDiamond = false;
            ankhEmerald = false;
            ankhSapphire = false;
            ankhTopaz = false;
            isSpade = false;
            claymoreCooldown = false;
            elderberryBuff = false;
            flood = false;
            plague = false;
            reaperRosario = false;
            screenShake = false;
            screenShakeLight = false;
            signiasPet = false;
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
            isSpade = false;
            claymoreCooldown = false;
            elderberryBuff = false;
            flood = false;
            plague = false;
            reaperRosario = false;
            screenShake = false;
            screenShakeLight = false;
            signiasPet = false;
            splintered = false;
            treeEnt = false;
        }
        public override void ModifyScreenPosition()
        {
            if (screenShake) //Thanks, Hallam :)
            {
                Main.screenPosition.X += Main.rand.Next(-10, 11);
                Main.screenPosition.Y += Main.rand.Next(-10, 11);
            }
            if (screenShakeLight)
            {
                Main.screenPosition.X += Main.rand.Next(-5, 6);
                Main.screenPosition.Y += Main.rand.Next(-5, 6);
            }
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

        public override void UpdateBiomeVisuals()
        {
            if (Main.LocalPlayer.ZoneDesert)
            {
                DrawSand();
            }
        }
        private void DrawSand()
        {
            for (int k = (int)Math.Floor(player.position.X / 16) - 55; k < (int)Math.Floor(player.position.X / 16) + 55; k++)
            {
                for (int i = (int)Math.Floor(player.position.Y / 16) - 30; i < (int)Math.Floor(player.position.Y / 16) + 30; i++)
                {
                    if (!Main.tile[k, i - 1].active()
                        && !Main.tile[k, i - 2].active()
                        && Main.tile[k, i].active()
                        && Main.tile[k, i].type == TileID.Sand
                        && Main.tile[k, i].type == TileID.Sand) //Sand is the only tile that it should spawn on, but we'll settle
                    {
                        if (Main.rand.Next(0, 95) == 2)
                        {
                            int Index = Dust.NewDust(new Vector2((k - 2) * 16, (i - 1) * 16), 5, 5, DustType<SandDust>());
                            if (player.ZoneSandstorm)
                            {
                                Main.dust[Index].velocity.Y += 0.09f;
                            }
                        }
                    }
                }
            }
            for (int k2 = (int)Math.Floor(player.position.X / 16) - 55; k2 < (int)Math.Floor(player.position.X / 16) + 55; k2++)
            {
                for (int i2 = (int)Math.Floor(player.position.Y / 16) - 30; i2 < (int)Math.Floor(player.position.Y / 16) + 30; i2++)
                {
                    if (!Main.tile[k2, i2 - 1].active()
                    && !Main.tile[k2, i2 - 2].active()
                    && Main.tile[k2, i2].active()
                    && Main.tile[k2, i2].type == TileID.Ebonsand
                    && Main.tile[k2, i2].type == TileID.Ebonsand) //Sand is the only tile that it should spawn on, but we'll settle
                    {
                        if (Main.rand.Next(0, 95) == 2)
                        {
                            int Index = Dust.NewDust(new Vector2((k2 - 2) * 16, (i2 - 1) * 16), 5, 5, DustType<SandDust>());
                            Main.dust[Index].color = new Color(222, 77, 222);
                            if (player.ZoneSandstorm)
                            {
                                Main.dust[Index].velocity.Y += 0.09f;
                            }
                        }
                    }
                }
            }
            for (int k3 = (int)Math.Floor(player.position.X / 16) - 55; k3 < (int)Math.Floor(player.position.X / 16) + 55; k3++)
            {
                for (int i3 = (int)Math.Floor(player.position.Y / 16) - 30; i3 < (int)Math.Floor(player.position.Y / 16) + 30; i3++)
                {
                    if (!Main.tile[k3, i3 - 1].active()
                    && !Main.tile[k3, i3 - 2].active()
                    && Main.tile[k3, i3].active()
                    && Main.tile[k3, i3].type == TileID.Crimsand
                    && Main.tile[k3, i3].type == TileID.Crimsand) //Sand is the only tile that it should spawn on, but we'll settle
                    {
                        if (Main.rand.Next(0, 95) == 2)
                        {
                            int Index = Dust.NewDust(new Vector2((k3 - 2) * 16, (i3 - 1) * 16), 5, 5, DustType<SandDust>());
                            Main.dust[Index].color = new Color(222, 55, 85);
                            if (player.ZoneSandstorm)
                            {
                                Main.dust[Index].velocity.Y += 0.09f;
                            }
                        }
                    }
                }
            }
            for (int k4 = (int)Math.Floor(player.position.X / 16) - 55; k4 < (int)Math.Floor(player.position.X / 16) + 55; k4++)
            {
                for (int i4 = (int)Math.Floor(player.position.Y / 16) - 30; i4 < (int)Math.Floor(player.position.Y / 16) + 30; i4++)
                {
                    if (!Main.tile[k4, i4 - 1].active()
                    && !Main.tile[k4, i4 - 2].active()
                    && Main.tile[k4, i4].active()
                    && Main.tile[k4, i4].type == TileID.Pearlsand
                    && Main.tile[k4, i4].type == TileID.Pearlsand) //Sand is the only tile that it should spawn on, but we'll settle
                    {
                        if (Main.rand.Next(0, 95) == 2)
                        {
                            int Index = Dust.NewDust(new Vector2((k4 - 2) * 16, (i4 - 1) * 16), 5, 5, DustType<SandDust>());
                            Main.dust[Index].color = new Color(160, 114, 250);
                            if (player.ZoneSandstorm)
                            {
                                Main.dust[Index].velocity.Y += 0.09f;
                            }
                        }
                    }
                }
            }
        } //Sand Haze
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