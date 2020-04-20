using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Steel
{
    public class SteelBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Bow");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 4;
            item.rare = 2;
            item.width = 26;
            item.height = 48;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 5;
            item.knockBack = 3f;
            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 2, 15, 0);
            item.UseSound = SoundID.Item5;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, -5);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 10);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}