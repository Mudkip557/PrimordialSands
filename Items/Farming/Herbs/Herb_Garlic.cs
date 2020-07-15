using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.DataStructures;
using IL.Terraria.Localization;

namespace PrimordialSands.Items.Farming.Herbs
{
    public class Herb_Garlic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Garlic");
            Tooltip.SetDefault("Edible Herb");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.consumable = true;
            item.buffType = BuffID.Stinky;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_HeavyCrunch");
            item.buffTime = 600;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 35);
        }
        public override void OnConsumeItem(Player player)
        {
            CombatText.NewText(player.Hitbox, new Color(66, 130, 60), "Odor +10s");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Garlic", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
    }
}