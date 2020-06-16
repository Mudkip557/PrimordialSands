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
    public class Mace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mace");
            Tooltip.SetDefault("Something ultra gay");
        }
        public override void SetDefaults()
        {
            item.damage = 22;
            item.crit = 4;
            item.rare = ItemRarityID.Green;
            item.width = 48;
            item.height = 48;
            item.useAnimation = 28;
            item.useTime = 28;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3.5f;
            item.hammer = 55;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 30, 0);
            item.UseSound = SoundID.Item1;
        }
     
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 10);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}