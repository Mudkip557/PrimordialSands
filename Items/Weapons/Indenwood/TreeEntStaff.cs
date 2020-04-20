using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class TreeEntStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Ent Staff");
            Tooltip.SetDefault("Summons a cute tree ent to fight for you");
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.crit = 4;
            item.rare = 1;
            item.width = 42;
            item.height = 48;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 1;
            item.knockBack = 3f;
            item.mana = 8;
            item.summon = true;
            item.noMelee = true;
            item.value = Terraria.Item.buyPrice(0, 0, 80, 0);
            item.UseSound = SoundID.Item83;
            item.shoot = mod.ProjectileType("TreeEntMinion");
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 28);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}