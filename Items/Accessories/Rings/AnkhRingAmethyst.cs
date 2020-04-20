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
    public class AnkhRingAmethyst : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amethyst Ankh Ring");
            Tooltip.SetDefault("Increases damage by 5%");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.rare = 1;
            item.accessory = true;
            item.value = Terraria.Item.buyPrice(0, 0, 65, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.thrownDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Amethyst, 5);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}