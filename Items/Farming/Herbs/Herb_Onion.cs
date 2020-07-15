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
    public class Herb_Onion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onion");
            Tooltip.SetDefault("Edible Herb");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.consumable = true;
            item.useTime = 60;
            item.useAnimation = 60;
            item.buffTime = 600;
            item.buffType = BuffID.Stinky;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_HeavyCrunch");
            item.healLife = 10;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 35);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Onion", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
        public override void OnConsumeItem(Player player)
        {
            CombatText.NewText(player.Hitbox, new Color(66, 130, 60), "Odor +10s");
        }
    }
}