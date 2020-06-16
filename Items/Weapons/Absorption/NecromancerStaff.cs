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
    public class NecromancerStaff : AbsorptionItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necrotic Sceptre");
            Tooltip.SetDefault("Absorbs 50% of an enemies damage, which can be returned"
                + "\nThis effect is active for 5 seconds, there is a 10 second cooldown afterwards"
                + string.Format("\n[c/832a2a:40% Health draw:] [i:{0}]", ItemID.Heart)
                + string.Format("\n[c/4d6b38:10 Second health draw Cooldown:] [i:{0}]", ItemID.FastClock));
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
            item.mana = 20;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.UseSound = SoundID.Item8;
            item.shoot = mod.ProjectileType("NecroticSceptreProjectile");
            item.shootSpeed = 8f;
        }
    }
}