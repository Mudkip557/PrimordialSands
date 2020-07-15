using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SteelBrogues : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Brogues");
            Tooltip.SetDefault("Decreases movement speed by 5%"
                + "\nIncreases fall speed, decreases fall damage");
        }

        public override void SetDefaults()
        {
            item.height = 22;
            item.width = 22;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed -= 0.05f;
            player.maxFallSpeed = 25f;
            player.extraFall += 3;
        }
    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 8);
            recipe.AddIngredient(ItemID.Leather, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}