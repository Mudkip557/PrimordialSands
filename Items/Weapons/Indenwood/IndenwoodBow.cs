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
    public class IndenwoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Bow");
            Tooltip.SetDefault("Charges up into a large blast of energy");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 4;
            item.rare = ItemRarityID.Blue;
            item.width = 20;
            item.height = 38;
            item.useAnimation = 28;
            item.useTime = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2.75f;
            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 65, 0);
            item.UseSound = SoundID.Item5;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 5f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float posX = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float posY = (float)Main.mouseY + Main.screenPosition.Y - position.Y;

            float projectilePosition = 0.314159274f;
            int numProjectile = 2;
            Vector2 vector15 = new Vector2(posX, posY);
            vector15.Normalize();
            vector15 *= 50f;
            bool flag13 = Collision.CanHit(position, 0, 0, position + vector15, 0, 0);
            int num2;
            for (int num123 = 0; num123 < numProjectile; num123 = num2 + 1)
            {
                float num124 = (float)num123 - ((float)numProjectile - 1f) / 2f;
                Vector2 vector16 = vector15.RotatedBy((double)(projectilePosition * num124), default(Vector2));
                if (!flag13)
                {
                    vector16 -= vector15;
                }
                int projectileIndex = Projectile.NewProjectile(position.X + vector16.X, position.Y + vector16.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Main.projectile[projectileIndex].noDropItem = true;
                num2 = num123;
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 30);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}