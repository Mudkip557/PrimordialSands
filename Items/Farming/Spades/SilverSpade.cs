﻿using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Farming.Spades
{
    public class SilverSpade : FarmToolItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Spade");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.melee = true;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
            item.knockBack = 1f;
            item.value = Item.buyPrice(0, 1, 25, 0);
            item.pick = 28;
            spade = true;
            treasureChance = 80;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
