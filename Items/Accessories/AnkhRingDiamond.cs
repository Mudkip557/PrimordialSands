using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Accessories
{
    public class AnkhRingDiamond : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Ankh Ring");
            Tooltip.SetDefault("Increases critical strike chance by 5");
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
            player.magicCrit += 5;
            if (player.armor[1].type == ItemID.DiamondRobe)
            {
                player.magicCrit += 2;
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "AnkhRingDiamond", "Boosts critical strike chance when worn with a Diamond Robe");

            line.overrideColor = new Color(106, 255, 48);
            tooltips.Add(line);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
