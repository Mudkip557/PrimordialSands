using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using PrimordialSands.Projectiles;

namespace PrimordialSands.Items.Weapons
{
    public class MyeclialWarhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mycelial Warhammer");
            Tooltip.SetDefault("Slams down on the ground creating splash damage" +
                "\nEnemies hit with direct contact are afflicted with the fungus infection debuff");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.crit = 2;
            item.knockBack = 5.7f;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.DD2_MonkStaffSwing;
            item.shoot = ProjectileType<MycelialMasherProjectile>();
            item.shootSpeed = 24f;
        }
    }
}
