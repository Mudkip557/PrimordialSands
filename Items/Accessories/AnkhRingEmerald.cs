using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Accessories
{
    public class AnkhRingEmerald : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Ankh Ring");
            Tooltip.SetDefault("Increases regeneration speed by 4");
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
            player.lifeRegen += 4;
            if (player.armor[1].type == ItemID.EmeraldRobe)
            {
                player.manaRegen += 5;
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "AnkhRingEmerald", "Boosts mana regeneration by 5 when worn with a Emerald Robe");

            line.overrideColor = new Color(106, 255, 48);
            tooltips.Add(line);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
