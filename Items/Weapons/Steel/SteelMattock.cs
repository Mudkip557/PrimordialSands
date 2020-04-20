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
    public class SteelMattock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Mattock");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 9;
            item.crit = 4;
            item.rare = 2;
            item.width = 36;
            item.height = 36;
            item.useAnimation = 18;
            item.useTime = 18;
            item.useStyle = 1;
            item.pick = 60;
            item.hammer = 80;
            item.knockBack = 2.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 16);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}