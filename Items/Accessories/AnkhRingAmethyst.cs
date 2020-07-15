using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Accessories
{
    public class AnkhRingAmethyst : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amethyst Ankh Ring");
            Tooltip.SetDefault("Increases magic damage by 7%");
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
            player.magicDamage += 0.07f;
            if (player.armor[1].type == ItemID.AmethystRobe)
            {
                player.magicDamage += 0.05f;
            }

        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "AnkhRingAmethyst", "Boosts magic damage when worn with an Amethyst Robe");
            line.overrideColor = new Color(106, 255, 48);
            tooltips.Add(line);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst, 5);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}