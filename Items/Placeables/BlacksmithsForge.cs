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
    public class BlacksmithsForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blacksmith's Forge");
            Tooltip.SetDefault("Used for advanced smelting and forging");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.maxStack = 99;
            item.width = 18;
            item.height = 24;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("BlacksmithsForgeTile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Carbon"), 10);
            recipe.AddIngredient(ItemID.Obsidian, 4);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddIngredient(ItemID.IronAnvil);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Carbon"), 10);
            recipe.AddIngredient(ItemID.Obsidian, 4);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddIngredient(ItemID.LeadAnvil);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}