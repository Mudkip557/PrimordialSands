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
	public class IndenwoodArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Splinter Arrow");
            Tooltip.SetDefault("Impales and leaves splinters in enemies");
        }

		public override void SetDefaults()
		{
			item.damage = 5;
            item.rare = 1;
            item.width = 14;
			item.height = 32;
			item.maxStack = 999;
			item.knockBack = 1.5f;
            item.shootSpeed = 2f;
            item.ranged = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 35);
            item.shoot = mod.ProjectileType("IndenwoodArrowProjectile");
			item.ammo = AmmoID.Arrow;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 10);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}