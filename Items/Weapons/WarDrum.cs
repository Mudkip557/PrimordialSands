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
    public class WarDrum : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit War Drum");
            Tooltip.SetDefault("Summons a spirit animal to fight for you"
                + "\nSpirit animals vary depending on the moon phase");
        }
        public override void SetDefaults()
        {
            item.damage = 24;
            item.crit = 4;
            item.rare = 3;
            item.width = 28;
            item.height = 32;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 1;
            item.knockBack = 1f;
            item.mana = 8;
            item.summon = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/WarDrum");
            item.shoot = mod.ProjectileType("SpiritAnimalSpawnProjectile");
            item.shootSpeed = 10f;
        }
    }
}