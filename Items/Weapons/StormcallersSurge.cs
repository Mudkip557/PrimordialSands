using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimordialSands.Items.Weapons
{
    public class StormcallersSurge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stormcaller's Surge");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.width = 60;
            item.height = 60;
            item.useTime = 50;
            item.useAnimation = 50;
            item.mana = 56;
            item.knockBack = 8f;
            item.shootSpeed = 10f;
            item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = mod.ProjectileType("StormcallersSurgeProjectile");
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Thunderclap");
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.magic = true;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 95f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = Main.rand.Next(5, 8);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0.35f));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}