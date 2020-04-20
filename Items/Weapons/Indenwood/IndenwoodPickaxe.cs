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
    public class IndenwoodPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Pickaxe");
            Tooltip.SetDefault("Mining minerals occasionally drops extra");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit = 4;
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 1;
            item.pick = 55;
            item.knockBack = 2f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 60, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 48);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}