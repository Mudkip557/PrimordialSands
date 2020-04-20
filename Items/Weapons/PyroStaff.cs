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
    public class PyroStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pyromaniac Staff");
            Tooltip.SetDefault("Right-click to summon an inferno"
                + "\nLeft-click to fire bolts of flames that fragment into embers");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 24;
            item.crit = 8;
            item.rare = 3;
            item.width = 48;
            item.height = 58;
            item.useAnimation = 38;
            item.useTime = 45;
            item.useStyle = 5;
            item.knockBack = 1.75f;
            item.mana = 18;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("InfernoBollProjectile");
            item.shootSpeed = 10f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                Item.staff[item.type] = true;
            }
            else
            {
                item.useStyle = 5;
                Item.staff[item.type] = true;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            PrimordialSandsPlayer modPlayer = (PrimordialSandsPlayer)player.GetModPlayer(mod, "PrimordialSandsPlayer");
            if (player.altFunctionUse != 2)
            {
                modPlayer.infernoSummoned = true;
            }
            if (player.altFunctionUse == 2)
            {
                int p = Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, mod.ProjectileType("InfernoProjectile"), item.damage, item.knockBack, Main.myPlayer);
                return false;
            }
            return true;
        }
    }
}