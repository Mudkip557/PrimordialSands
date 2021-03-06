﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Accessories
{
    public class AnkhRingTopaz : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Topaz Ankh Ring");
            Tooltip.SetDefault("Increases maximum mana by 5");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.width = 34;
            item.height = 34;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 5;
            if (player.armor[1].type == ItemID.TopazRobe)
            {
                Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().ankhTopaz = true;
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "AnkhRingTopaz", "Magic weapons have a chance to afflict 'On Fire!' when worn with a Topaz Robe");

            line.overrideColor = new Color(106, 255, 48);
            tooltips.Add(line);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
