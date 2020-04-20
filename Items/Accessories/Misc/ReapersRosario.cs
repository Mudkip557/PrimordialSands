using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimordialSands.Items.Accessories.Misc
{
    public class ReapersRosario : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper's Rosario");
            Tooltip.SetDefault("You cannot criticly hit enemies and all non-absorption damage is reduced by 20%"
            + "\nAbsorption damage is increased by 15% and you rapidly regenerate health"
            + "\nWhile under 40% of your maximum health, reapers appear and automatically restore health overtime");
        }
        public override void SetDefaults()
        {

            item.width = 34;
            item.height = 42;
            item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.rare = 5;
            item.accessory = true;
            item.defense = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit = -100;
            player.meleeCrit = -100;
            player.rangedCrit = -100;
            player.thrownCrit = -100;
            player.meleeDamage -= 0.20f;
            player.rangedDamage -= 0.20f;
            player.magicDamage -= 0.20f;
            player.minionDamage -= 0.20f;
            player.thrownDamage -= 0.20f;
            player.lifeRegen += 10;
            if (player.statLife <= (player.statLifeMax2 * 0.40f))
            {
                player.AddBuff(mod.BuffType("ReaperHealBuff"), 1);
                ((PrimordialSandsPlayer)player.GetModPlayer(mod, "PrimordialSandsPlayer")).reaperRosario = true;
            }
            if (player.statLife >= (player.statLifeMax2 * 0.40f))
            {
                player.buffImmune[mod.BuffType("ReaperHealBuff")] = true;
                ((PrimordialSandsPlayer)player.GetModPlayer(mod, "PrimordialSandsPlayer")).reaperRosario = false;
            }
        }
    }
}