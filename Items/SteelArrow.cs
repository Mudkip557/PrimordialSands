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
	public class SteelArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Arrow");
            Tooltip.SetDefault("");
        }

		public override void SetDefaults()
		{
			item.damage = 7;
            item.rare = 2;
            item.width = 10;
			item.height = 32;
			item.maxStack = 999;
			item.knockBack = 1.5f;
            item.shootSpeed = 3f;
            item.ranged = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 40);
            item.shoot = mod.ProjectileType("SteelArrowProjectile");
			item.ammo = AmmoID.Arrow;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 3);
            recipe.AddIngredient(ItemID.Wood, 2);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this, 45);
            recipe.AddRecipe();
        }
    }
}