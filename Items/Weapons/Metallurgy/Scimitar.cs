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
    public class Scimitar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scimitar");
            Tooltip.SetDefault("Something gay");
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 4;
            item.rare = 2;
            item.width = 48;
            item.height = 48;
            item.useAnimation = 24;
            item.useTime = 24;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
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