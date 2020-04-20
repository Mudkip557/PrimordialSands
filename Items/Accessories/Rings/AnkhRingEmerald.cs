using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Accessories.Rings
{
    public class AnkhRingEmerald : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Ankh Ring");
            Tooltip.SetDefault("Increases maximum health by 5");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.rare = 1;
            item.accessory = true;
            item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}