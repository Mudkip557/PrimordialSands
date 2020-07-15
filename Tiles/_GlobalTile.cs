using System;
using Microsoft.Xna.Framework;
using PrimordialSands.Items.Farming;
using PrimordialSands.Items.Placeables;
using PrimordialSands.Projectiles;
using PrimordialSands.Tiles.Swamp;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Tiles
{
    internal sealed class _GlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            Player player = Main.LocalPlayer;
            #region Soil Types
            bool Soil = type == TileID.Dirt
            || type == TileID.Mud
            || type == TileID.Mudstone
            || type == TileID.Grass
            || type == TileID.CorruptGrass
            || type == TileID.FleshGrass
            || type == TileID.HallowedGrass
            || type == TileID.JungleGrass
            || type == TileID.MushroomGrass
            || type == TileID.Cloud
            || type == TileID.RainCloud
            || type == TileID.Sand
            || type == TileID.Ebonsand
            || type == TileID.Crimsand
            || type == TileID.Pearlsand
            || type == TileID.Sand
            || type == TileID.Silt
            || type == TileID.Slush
            || type == TileID.Ash
            || type == TileType<IndenSoilTile>()
            || type == TileType<IndenGrassTile>()
            || type == TileID.ClayBlock
            || type == TileID.SnowCloud;
            #endregion
            if (modPlayer.harvestEnchant)
            {
                if (Main.rand.Next(6) == (0))
                {
                    if (type == TileID.Copper)
                    {
                        int amount = Main.rand.Next(1, 3);
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.CopperOre, amount);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Copper Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Copper Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Copper Harvest +3");
                        }
                    }
                    if (type == TileID.Tin)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Tan, "Tin Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Tan, "Tin Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Tan, "Tin Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.TinOre, amount);
                    }
                    if (type == TileID.Iron)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGoldenrodYellow, "Iron Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGoldenrodYellow, "Iron Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGoldenrodYellow, "Iron Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.IronOre, amount);
                    }
                    if (type == TileID.Lead)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Lead Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Lead Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Lead Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.LeadOre, amount);
                    }
                    if (type == TileID.Silver)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Silver, "Silver Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Silver, "Silver Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Silver, "Silver Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.SilverOre, amount);
                    }
                    if (type == TileID.Tungsten)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Green, "Tungesten Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Green, "Tungsten Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Green, "Tungesten Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.TungstenOre, amount);
                    }
                    if (type == TileID.Gold)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightYellow, "Gold Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightYellow, "Gold Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightYellow, "Gold Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.GoldOre, amount);
                    }
                    if (type == TileID.Platinum)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSlateGray, "Platinum Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSlateGray, "Platinum Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSlateGray, "Platinum Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.PlatinumOre, amount);
                    }
                    if (type == TileID.Demonite)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumPurple, "Demonite Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumPurple, "Demonite Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumPurple, "Demonite Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.DemoniteOre, amount);
                    }
                    if (type == TileID.Crimtane)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.OrangeRed, "Crimtane Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.OrangeRed, "Crimtane Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.OrangeRed, "Crimtane Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.CrimtaneOre, amount);
                    }
                    if (type == TileID.Meteorite)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.RosyBrown, "Meteorite Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.RosyBrown, "Meteorite Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.RosyBrown, "Meteorite Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Meteorite, amount);
                    }
                }
                if (Main.rand.Next(7) == (0))
                {
                    if (type == TileID.Amethyst)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orchid, "Amethyst Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orchid, "Amethyst Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orchid, "Amethyst Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Amethyst, amount);
                    }
                    if (type == TileID.Topaz)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Topaz Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Topaz Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Topaz Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Topaz, amount);
                    }
                    if (type == TileID.Emerald)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Emerald Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Emerald Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Emerald Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Emerald, amount);
                    }
                    if (type == TileID.Sapphire)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumBlue, "Sapphire Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumBlue, "Sapphire Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.MediumBlue, "Sapphire Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Sapphire, amount);
                    }
                    if (type == TileID.Ruby)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Ruby Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Ruby Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Ruby Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Ruby, amount);
                    }
                    if (type == TileID.Diamond)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.AntiqueWhite, "Diamond Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.AntiqueWhite, "Diamond Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.AntiqueWhite, "Diamond Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Diamond, amount);
                    }
                    if (type == TileID.Hellstone)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Hellstone Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Hellstone Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Orange, "Hellstone Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Hellstone, amount);
                    }
                }

                if (Main.rand.Next(7) == (0))
                {
                    if (type == TileID.Cobalt)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.CornflowerBlue, "Cobalt Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.CornflowerBlue, "Cobalt Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.CornflowerBlue, "Cobalt Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.CobaltOre, amount);
                    }
                    if (type == TileID.Palladium)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Palladium Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Palladium Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Gold, "Palladium Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.PalladiumOre, amount);
                    }
                    if (type == TileID.Mythril)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Mythril Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Mythril Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightGreen, "Mythril Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.MythrilOre, amount);
                    }
                    if (type == TileID.Orichalcum)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightPink, "Orichalcum Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightPink, "Orichalcum Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightPink, "Orichalcum Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.OrichalcumOre, amount);
                    }
                    if (type == TileID.Adamantite)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Adamantite Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Adamantite Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Red, "Adamantite Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.AdamantiteOre, amount);
                    }
                    if (type == TileID.Titanium)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Titanium Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Titanium Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.LightSteelBlue, "Titanium Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.TitaniumOre, amount);
                    }
                    if (type == TileID.Chlorophyte)
                    {
                        int amount = Main.rand.Next(1, 3);
                        if (amount == 1)
                        {
                            CombatText.NewText(player.Hitbox, Color.Lime, "Chlorophyte Harvest +1");
                        }
                        if (amount == 2)
                        {
                            CombatText.NewText(player.Hitbox, Color.Lime, "Chlorophyte Harvest +2");
                        }
                        if (amount == 3)
                        {
                            CombatText.NewText(player.Hitbox, Color.Lime, "Chlorophyte Harvest +3");
                        }
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.ChlorophyteOre, amount);
                    }
                }
            }
            if (player.HeldItem.modItem is FarmToolItem farmToolItem && Soil && Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (Main.rand.NextBool(5))
                {
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemType<Items.Farming.Soils.SiltSoil>(), Main.rand.Next(1, 3));
                }

                if (Main.rand.NextBool((int)farmToolItem.treasureChance))
                {
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.GoldCoin, Main.rand.Next(1, 3));
                    CombatText.NewText(player.Hitbox, Color.Gold, "Dug Treasure!");
                }
            }
            return true;
        }
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            #region Soil Types
            bool Soil = type == TileID.Dirt
            || type == TileID.Mud
            || type == TileID.Mudstone
            || type == TileID.Grass
            || type == TileID.CorruptGrass
            || type == TileID.FleshGrass
            || type == TileID.HallowedGrass
            || type == TileID.JungleGrass
            || type == TileID.MushroomGrass
            || type == TileID.Cloud
            || type == TileID.RainCloud
            || type == TileID.Sand
            || type == TileID.Ebonsand
            || type == TileID.Crimsand
            || type == TileID.Pearlsand
            || type == TileID.Sand
            || type == TileID.Silt
            || type == TileID.Slush
            || type == TileID.Ash
            || type == TileType<IndenSoilTile>()
            || type == TileType<IndenGrassTile>()
            || type == TileID.ClayBlock
            || type == TileID.SnowCloud;
            #endregion
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            Player player = Main.LocalPlayer;
            bool spadeItem = player.HeldItem.modItem is FarmToolItem farmToolItem;
            if (spadeItem && !Soil)
            {

                return false;
            }

            if (!spadeItem && Soil)
            {
                return false;
            }
            return true;
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            #region Soil Types
            bool Soil = type == TileID.Dirt
            || type == TileID.Mud
            || type == TileID.Mudstone
            || type == TileID.Grass
            || type == TileID.CorruptGrass
            || type == TileID.FleshGrass
            || type == TileID.HallowedGrass
            || type == TileID.JungleGrass
            || type == TileID.MushroomGrass
            || type == TileID.Cloud
            || type == TileID.RainCloud
            || type == TileID.Sand
            || type == TileID.Ebonsand
            || type == TileID.Crimsand
            || type == TileID.Pearlsand
            || type == TileID.Sand
            || type == TileID.Silt
            || type == TileID.Slush
            || type == TileID.Ash
            || type == TileType<IndenSoilTile>()
            || type == TileType<IndenGrassTile>()
            || type == TileID.ClayBlock
            || type == TileID.SnowCloud;
            #endregion
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            Player player = Main.LocalPlayer;
            bool spadeItem = player.HeldItem.modItem is FarmToolItem farmToolItem;
            if (!spadeItem && Soil)
            {
                if (Main.rand.NextBool(5))
                {
                    CombatText.NewText(player.Hitbox, Color.White, "You need a Spade to dig soils!");
                }
            }
        }
        public override void RightClick(int i, int j, int type)
        {
            #region Soil Types
            bool Soil = type == TileID.Dirt
            || type == TileID.Mud
            || type == TileID.Mudstone
            || type == TileID.Grass
            || type == TileID.CorruptGrass
            || type == TileID.FleshGrass
            || type == TileID.HallowedGrass
            || type == TileID.JungleGrass
            || type == TileID.MushroomGrass
            || type == TileID.Cloud
            || type == TileID.RainCloud
            || type == TileID.Sand
            || type == TileID.Ebonsand
            || type == TileID.Crimsand
            || type == TileID.Pearlsand
            || type == TileID.Sand
            || type == TileID.Silt
            || type == TileID.Slush
            || type == TileID.Ash
            || type == TileType<IndenSoilTile>()
            || type == TileType<IndenGrassTile>()
            || type == TileID.ClayBlock
            || type == TileID.SnowCloud;
            #endregion
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            Player player = Main.LocalPlayer;
        }
    }
}