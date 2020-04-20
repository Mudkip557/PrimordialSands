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
    public class SteelAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Hatchet");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 4;
            item.rare = 2;
            item.width = 40;
            item.height = 40;
            item.useAnimation = 23;
            item.useTime = 23;
            item.useStyle = 1;
            item.axe = 9;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 85, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 12);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}