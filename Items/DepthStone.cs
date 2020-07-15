using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using PrimordialSands.Traps;

namespace PrimordialSands.Items
{
    public class DepthStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Depth Stone");
            Tooltip.SetDefault("Summons a miniature blue whale that follows you around :)");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Expert;
            item.width = 18;
            item.height = 24;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.shoot = ProjectileType<Projectiles.Minions.SigniasPetProjectile>();
            item.buffType = BuffType<Buffs.DepthStone>();
            item.UseSound = SoundID.Item10;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }
    }
}