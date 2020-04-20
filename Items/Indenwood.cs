﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items
{
    public class Indenwood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood");
            Tooltip.SetDefault("'Witholds spiritual essence of Vajra'");
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
            item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
            item.createTile = mod.TileType("IndenwoodPlankTile");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IndenwoodWall"), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IndenwoodPlatform"), 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}