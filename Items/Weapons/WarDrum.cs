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
            DisplayName.SetDefault("War Drum");
            Tooltip.SetDefault("Releases a loud barrier of sound waves deafening and weakening enemies");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 4;
            item.rare = ItemRarityID.Green;
            item.width = 28;
            item.height = 32;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 8f;
            item.mana = 20;
            item.summon = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/WarDrum");
            item.shoot = mod.ProjectileType("WarDrumProjectile");
            item.shootSpeed = 0f;
        }
    }
}