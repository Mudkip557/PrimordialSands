using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Herbs
{
    public class Herb_Valerian : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valerian");
            Tooltip.SetDefault("Medicinal Herb");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.value = Terraria.Item.buyPrice(0, 0, 33, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Valerian", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
    }
}