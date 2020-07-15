using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using PrimordialSands.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;

namespace PrimordialSands.Items.Weapons
{
    public class LocustStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Locust Staff");
            Tooltip.SetDefault("Sends locust to devour your enemies" +
                "\nEvery 1/4 locust siphons life off of enemies");
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
            item.summon = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 22, 0);
            item.UseSound = SoundID.NPCDeath11;
            item.shoot = ProjectileType<LocustProjectile>();
            item.shootSpeed = 10.5f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = Main.rand.Next(5, 8);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3.4f));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}