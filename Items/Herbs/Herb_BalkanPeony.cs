using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using IL.Terraria.Audio;

namespace PrimordialSands.Items.Herbs
{
    public class Herb_BalkanPeony : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Balkan Peony");
            Tooltip.SetDefault("Replenishing Plant");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.consumable = true;
            item.buffType = (BuffID.Regeneration);
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_Berries");
            item.buffTime = 600;
            item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Balkan Peony", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
    }
}