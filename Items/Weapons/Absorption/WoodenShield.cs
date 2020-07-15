using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Absorption
{
    public class WoodenShield : AbsorptionItem
    {
        public int baseDamage = 5;
        public bool DashAttack = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Shield");
            Tooltip.SetDefault("Absorps damage inflicted and returns for half the value" +
                "\nMaxixum return damage us capped at 30");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = baseDamage;
            item.crit = 2;
            item.width = 28;
            item.height = 28;
            item.useAnimation = 20;
            item.useTime = 20;
   
            item.knockBack = 3.5f;
            item.value = Item.buyPrice(0, 0, 0, 10);
            item.UseSound = SoundID.DD2_MonkStaffSwing;
            item.rare = ItemRarityID.White;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().screenShakeLight = true;
            item.damage = target.damage / 2 + baseDamage;
            if (item.damage < baseDamage)
                item.damage = baseDamage;

            if (item.damage > 30)
                item.damage = 30;

            if (target.damage <= 0)
            {
                item.damage = baseDamage;
            }
        }
        public override bool CanUseItem(Player player)
        {
            float dash = 3.5f;
            if (player.direction == 1)
            {
                player.velocity = new Vector2(player.velocity.X + dash, player.velocity.Y);
                if (player.velocity.X > dash)
                {
                    player.velocity.X = dash + 2;
                }
            }

            if (player.direction == -1)
            {
                player.velocity = new Vector2(player.velocity.X - dash, player.velocity.Y);
                if (player.velocity.X < dash)
                {
                    player.velocity.X = -dash - 2;
                }
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}