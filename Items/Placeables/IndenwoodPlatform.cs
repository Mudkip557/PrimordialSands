using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Placeables
{
    public class IndenwoodPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Platform");
            Tooltip.SetDefault("");
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
            item.createTile = mod.TileType("IndenwoodPlatformTile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"));
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}