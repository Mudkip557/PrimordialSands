using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrimordialSands.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Weapons
{
    public class ProjectileTest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Projectile Tester");
            Tooltip.SetDefault("Set projectile in source");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Expert;
            item.useAnimation = 7;
            item.useTime = 7;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileType<PrimordialSandsProjectile>();
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}