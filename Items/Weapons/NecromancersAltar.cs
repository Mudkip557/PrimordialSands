using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using PrimordialSands.Projectiles;
using Terraria.ModLoader;

namespace PrimordialSands.Items.Weapons
{
    public class NecromancersAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer's Altar");
            Tooltip.SetDefault("Summons an altar that casts shadowflames towards nearby enemies" +
                "\nShadowflames steal the lifeforce of enemies");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 18;
            item.crit = 4;
            item.rare = ItemRarityID.Orange;
            item.width = 44;
            item.height = 48;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0f;
            item.noMelee = true;
            item.autoReuse = true;
            item.sentry = true;
            item.summon = true;
            item.value = Item.buyPrice(0, 0, 44, 0);
            item.UseSound = SoundID.Item8;
            item.shoot = ProjectileType<ShadowflameAltarProjectile>();
            item.shootSpeed = 8f;
            item.mana = 20;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}