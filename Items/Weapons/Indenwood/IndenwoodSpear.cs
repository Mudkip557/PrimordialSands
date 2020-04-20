using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class IndenwoodSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Spear");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 4;
            item.rare = 1;
            item.width = 36;
            item.height = 44;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 1;
            item.knockBack = 1.5f;
            item.maxStack = 999;
            item.thrown = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("IndenwoodSpearProjectile");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 15);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}