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
    public class RavenThrush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Raven's Eiserne");
            Tooltip.SetDefault("'Wielded by the soul of the cursed sword's servant'"
                + "\nAllows the player to control the elevation of the Ringed Blade");
        }
        public override void SetDefaults()
        {
            item.damage = 21;
            item.crit = 12;
            item.rare = 2;
            item.width = 42;
            item.height = 44;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 1;
            item.knockBack = 2.5f;
            item.thrown = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.value = Terraria.Item.buyPrice(0, 8, 30, 0);
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("RavenThrushProjectile");
            item.shootSpeed = 10f;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;
        }
    }
}