using PrimordialSands.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;

namespace PrimordialSands.Items
{
    public class _GlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            if (modPlayer.harvestEnchant)
            {

            }
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (player.statDefense > 15 && player.ZoneSandstorm)
            {
                player.buffImmune[BuffID.WindPushed] = true;
            }
        }
    }
}