using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimordialSands.Tiles
{
    internal sealed class _GlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            Player player = Main.LocalPlayer;
            #region Indenwood Pickaxe
            if (player.HeldItem.type == mod.ItemType("IndenwoodPickaxe"))
            {
                if (Main.rand.Next(3) == (0))
                {
                    if (type == TileID.Copper)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.CopperOre, Main.rand.Next(1, 3));
                    }
                    if (type == TileID.Tin)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.TinOre, Main.rand.Next(1, 3));
                    }
                    //Tier 1

                    if (type == TileID.Iron)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.IronOre, Main.rand.Next(1, 3));
                    }
                    if (type == TileID.Lead)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.LeadOre, Main.rand.Next(1, 3));
                    }
                    //Tier 2

                    if (type == TileID.Silver)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.SilverOre, Main.rand.Next(1, 3));
                    }
                    if (type == TileID.Tungsten)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.TungstenOre, Main.rand.Next(1, 3));
                    }
                    //Tier 3

                    if (type == TileID.Gold)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.GoldOre, Main.rand.Next(1, 3));
                    }
                    if (type == TileID.Platinum)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 48, ItemID.PlatinumOre, Main.rand.Next(1, 3));
                    }
                }
            }
            #endregion 
            return true;
        }
    }
}