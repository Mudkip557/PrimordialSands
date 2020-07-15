using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Farming.Herbs
{
    public class Herb_WaterCaltrop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Caltrop");
            Tooltip.SetDefault("Replenishing Plant");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.buffTime = 600;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_Berries");
            item.buffType = BuffID.Gills;
            item.value = Item.buyPrice(0, 0, 33, 0);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_WaterCaltrop", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
        public override void OnConsumeItem(Player player)
        {
            CombatText.NewText(player.Hitbox, new Color(30, 44, 165), "Waterbreathing +10s");
        }
    }
}