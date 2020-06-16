using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using PrimordialSands.Buffs;

namespace PrimordialSands.Items.Herbs
{
    public class Herb_Elderberry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderberry");
            Tooltip.SetDefault("Replenishing Plant");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Quest;
            item.maxStack = 99;
            item.width = 30;
            item.height = 30;
            item.consumable = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.buffTime = 600;
            item.buffType = BuffType<Elderberry>();
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Food_Berries");
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }
        public override void OnConsumeItem(Player player)
        {
            CombatText.NewText(player.Hitbox, new Color(123, 56, 224), "35+ Max life +10s");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Herb_Elderberry", "-- Herb Item --");

            line.overrideColor = new Color(106, 190, 48);
            tooltips.Add(line);
        }
    }
}