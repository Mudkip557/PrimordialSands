using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Farming.Soils
{
    public class Twigs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twigs");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Green;
            item.maxStack = 999;
            item.width = 18;
            item.height = 24;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
        }
    }
}