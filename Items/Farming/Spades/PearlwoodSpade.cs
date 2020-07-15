using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Farming.Spades
{
    public class PearlwoodSpade : FarmToolItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearlwood Spade");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
            item.knockBack = 1f;
            item.value = Item.buyPrice(0, 1, 85, 0);
            item.pick = 22;
            spade = true;
            treasureChance = 100;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}