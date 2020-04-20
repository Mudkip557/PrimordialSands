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
    public class AnkhRingDiamond : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Ankh Ring");
            Tooltip.SetDefault("Increases critical strike chance by 2");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.rare = 2;
            item.accessory = true;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeCrit += 2;
            player.magicCrit += 2;
            player.rangedCrit += 2;
            player.thrownCrit += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}