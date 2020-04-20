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
    public class IndenwoodStave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Stave");
            Tooltip.SetDefault("");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 4;
            item.rare = 1;
            item.width = 46;
            item.height = 46;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 5;
            item.knockBack = 3f;
            item.mana = 4;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 70, 0);
            item.UseSound = SoundID.Item8;
            item.shoot = mod.ProjectileType("FloodBlastProjectile");
            item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 20))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 25);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}