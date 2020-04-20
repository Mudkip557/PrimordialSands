using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons
{
    public class LeadSpade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Spade");
            Tooltip.SetDefault("'Only for the bravest of knights...'");
        }
        public override void SetDefaults()
        {
            item.damage = 11;
            item.crit = 4;
            item.rare = 0;
            item.width = 36;
            item.height = 44;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}