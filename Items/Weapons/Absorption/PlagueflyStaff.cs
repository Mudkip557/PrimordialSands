using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Absorption
{
    public class PlagueflyStaff : AbsorptionItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaguefly Staff");
            Tooltip.SetDefault("Sends plagueflies to devour your enemies"
                + string.Format("\n[c/832a2a:Minus 1 health every hit:] [i:{0}]", ItemID.Heart)
                + string.Format("\n[c/4d6b38:5 Second health draw Cooldown:] [i:{0}]", ItemID.FastClock));

            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 7;
            item.rare = ItemRarityID.Green;
            item.width = 44;
            item.height = 48;
            item.useAnimation = 28;
            item.useTime = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0f;
            item.mana = 16;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 8, 35, 0);
            item.UseSound = SoundID.NPCDeath11;
            item.shoot = mod.ProjectileType("PlagueflyProjectile");
            item.shootSpeed = 10.5f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = Main.rand.Next(2, 4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}