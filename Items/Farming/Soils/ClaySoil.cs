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
    public class ClaySoil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clay");
            Tooltip.SetDefault("Can be used to make new soil types");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.maxStack = 999;
            item.width = 18;
            item.height = 24;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 5);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ClayBlock);
            recipe.AddRecipe();
        }
    }
}