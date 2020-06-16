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
    public class Herb_Yucca : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yucca");
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
            item.consumable = true;
            item.buffType = BuffID.Sunflower;
            item.buffTime = 300;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_Berries");
            item.value = Item.buyPrice(0, 0, 50, 0);
        }
        public override void OnConsumeItem(Player player)
        {
            CombatText.NewText(player.Hitbox, new Color(125, 224, 74), "Movement Speed +5s");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Yucca", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
    }
}