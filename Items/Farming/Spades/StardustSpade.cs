﻿using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Farming.Spades
{
    public class StardustSpade : FarmToolItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Spade");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Red;
            item.damage = 25;
            item.melee = true;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
            item.knockBack = 1f;
            item.value = Item.buyPrice(0, 7, 0, 0);
            item.pick = 85;
            spade = true;
            treasureChance = 10;
         }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
