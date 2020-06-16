using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Metallurgy
{
    public class Longsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Longsword");
            Tooltip.SetDefault("Right-click to slam the face of the blade");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 4;
            item.rare = ItemRarityID.Green;
            item.width = 62;
            item.height = 62;
            item.useAnimation = 32;
            item.useTime = 32;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5.5f;
            item.melee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 2, 40, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 14);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}