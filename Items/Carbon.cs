using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items
{
    public class Carbon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carbon Fragment");
            Tooltip.SetDefault("'A black glass-like mineral...'");
        }
        public override void SetDefaults()
        {
            item.rare = 1;
            item.maxStack = 999;
            item.width = 18;
            item.height = 24;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 1, 25);
            item.createTile = mod.TileType("CarbonTile");
        }
    }
}