using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class IndenwoodHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Mallet");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit = 4;
            item.rare = 1;
            item.width = 40;
            item.height = 44;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 1;
            item.axe = 8;
            item.hammer = 50;
            item.knockBack = 5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 60, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {

            int Index = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 89);
            Main.dust[Index].noGravity = true;
            Main.dust[Index].rotation = ((float)1.1f + hitbox.X);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 22);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}