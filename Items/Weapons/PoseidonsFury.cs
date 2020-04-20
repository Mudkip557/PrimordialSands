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
    public class PoseidonsFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poseidon's Fury");
            Tooltip.SetDefault("'Mighty depths shall smite thee!'");
        }
        public override void SetDefaults()
        {
            item.damage = 22;
            item.crit = 7;
            item.rare = 2;
            item.width = 2;
            item.height = 44;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 3;
            item.knockBack = 1.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 3, 75, 0);
            item.shoot = mod.ProjectileType("PoseidonBoltProjectile");
            item.shootSpeed = 10f;
            item.UseSound = SoundID.Item1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num11 = 1;
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-40, 41), (float)Main.rand.Next(-40, 41));
                vector += player.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.2f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, vector.X, vector.Y, mod.ProjectileType("PoseidonBoltProjectile"), damage, knockBack, player.whoAmI, Main.mouseX, Main.mouseY);
            }
            return false;
        }
    }
}