using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PrimordialSands.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class IndenwoodStave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Stave");
            Tooltip.SetDefault("");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 4;
            item.rare = ItemRarityID.Blue;
            item.width = 41;
            item.height = 42;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3f;
            item.mana = 5;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Item.buyPrice(0, 0, 8, 35);
            item.UseSound = SoundID.Item8;
            item.shoot = ProjectileType<FloodBlastProjectile>();
            item.shootSpeed = 6.5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 20))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 25);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}