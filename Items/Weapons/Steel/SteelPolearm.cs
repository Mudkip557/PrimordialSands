using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Steel
{
    public class SteelPolearm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Polearm");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 4;
            item.rare = 2;
            item.width = 64;
            item.height = 62;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 5;
            item.knockBack = 5.5f;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.shootSpeed = 2.85f;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SteelPolearmProjectile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 10);
            recipe.AddIngredient(ItemID.Wood, 6);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}