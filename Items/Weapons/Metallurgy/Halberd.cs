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
    public class Halberd : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Halberd");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 4;
            item.rare = 2;
            item.width = 52;
            item.height = 52;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 5;
            item.knockBack = 4.5f;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = false;
            item.autoReuse = true;
            item.channel = true;
            item.shootSpeed = 25f;
            item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("HalberdProjectile");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num75 = item.shoot;
            float num76 = item.shootSpeed;
            if (item.melee && num75 != 25 && num75 != 26 && num75 != 35)
            {
                num76 /= player.meleeSpeed;
            }
            int num77 = item.damage;
            float num78 = item.knockBack;
            num78 = player.GetWeaponKnockback(item, num78);
            if (num75 == 228)
            {
                num78 = 0f;
            }
            player.itemTime = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            bool flag12 = true;
            int type5 = item.type;
            Vector2 value = Vector2.UnitX.RotatedBy((double)player.fullRotation, default(Vector2));
            Vector2 vector3 = Main.MouseWorld - vector2;
            Vector2 vector4 = player.itemRotation.ToRotationVector2() * (float)player.direction;
            if (vector3 != Vector2.Zero)
            {
                vector3.Normalize();
            }
            float num81 = Vector2.Dot(value, vector3);
            if (flag12)
            {
                if (num81 > 0f)
                {
                    player.ChangeDir(1);
                }
                else
                {
                    player.ChangeDir(-1);
                }
            }
            if (num75 == 9)
            {
                vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)Main.rand.Next(201) * -(float)player.direction + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                num78 = 0f;
                num77 *= 2;
            }
            float num82 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
            float num83 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
            if (player.gravDir == -1f)
            {
                num83 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
            }
            float num84 = (float)Math.Sqrt((double)(num82 * num82 + num83 * num83));
            float num85 = num84;
            if ((float.IsNaN(num82) && float.IsNaN(num83)) || (num82 == 0f && num83 == 0f))
            {
                num82 = (float)player.direction;
                num83 = 0f;
                num84 = num76;
            }
            else
            {
                num84 = num76 / num84;
            }
            num82 *= num84;
            num83 *= num84;
            if (num75 == 12)
            {
                vector2.X += num82 * 3f;
                vector2.Y += num83 * 3f;
            }
            if (item.useStyle == 5)
            {

                player.itemRotation = (float)Math.Atan2((double)(num83 * (float)player.direction), (double)(num82 * (float)player.direction)) - player.fullRotation;
                NetMessage.SendData(13, -1, -1, null, player.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                NetMessage.SendData(41, -1, -1, null, player.whoAmI, 0f, 0f, 0f, 0, 0, 0);

            }
            if (num75 == 17)
            {
                vector2.X = (float)Main.mouseX + Main.screenPosition.X;
                vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
                if (player.gravDir == -1f)
                {
                    vector2.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
                }
            }
            if (num75 == 76)
            {
                num75 += Main.rand.Next(3);
                num85 /= (float)(Main.screenHeight / 2);
                if (num85 > 1f)
                {
                    num85 = 1f;
                }
                float num87 = num82 + (float)Main.rand.Next(-40, 41) * 0.01f;
                float num88 = num83 + (float)Main.rand.Next(-40, 41) * 0.01f;
                num87 *= num85 + 0.25f;
                num88 *= num85 + 0.25f;
                int num89 = Projectile.NewProjectile(vector2.X, vector2.Y, num87, num88, num75, num77, num78, Main.myPlayer, 0f, 0f);
                Main.projectile[num89].ai[1] = 1f;
                num85 = num85 * 2f - 1f;
                if (num85 < -1f)
                {
                    num85 = -1f;
                }
                if (num85 > 1f)
                {
                    num85 = 1f;
                }
                Main.projectile[num89].ai[0] = num85;
                NetMessage.SendData(27, -1, -1, null, num89, 0f, 0f, 0f, 0, 0, 0);
            }
            float ai4 = Main.rand.NextFloat() * num76 * 0.75f * (float)player.direction;
            Vector2 velocity = new Vector2(num82, num83);
            Projectile.NewProjectile(vector2, velocity, num75, num77, num78, Main.myPlayer, ai4, 0f);
            return false;
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