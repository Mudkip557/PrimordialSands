using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Weapons.Metallurgy
{
    public class Claymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Claymore");
            Tooltip.SetDefault("Right-click to counter-thrust"
                + "\nThrusting will allow you to dodge an incoming attack and deal massive damage"
                + "\nThere is a 25 second cooldown after counter-thusting, during this cooldown you cannot wield this sword");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.crit = 4;
            item.rare = ItemRarityID.Green;
            item.width = 48;
            item.height = 48;
            item.useAnimation = 24;
            item.useTime = 24;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
            item.UseSound = SoundID.Item1;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (!Main.player[Main.myPlayer].HasBuff(mod.BuffType("ClaymoreCooldown")))
            {
                if (player.altFunctionUse == 2)
                {
                    Item.staff[item.type] = true;
                    item.useAnimation = 100;
                    item.useTime = 100;
                    item.damage = 100;
                    item.useStyle = ItemUseStyleID.HoldingOut;
                    float dash = 10f;
                    if (player.direction == 1)
                    {
                        player.velocity = new Vector2(player.velocity.X + dash, player.velocity.Y);
                        if (player.velocity.X > 30f)
                        {
                            player.velocity.X = 10f;
                        }
                    }

                    if (player.direction == -1)
                    {
                        player.velocity = new Vector2(player.velocity.X - dash, player.velocity.Y);
                        if (player.velocity.X > 30f)
                        {
                            player.velocity.X = 10f;
                        }
                    }
                }
                else
                {
                    item.useStyle = ItemUseStyleID.SwingThrow;
                    item.damage = 14;
                    item.useAnimation = 24;
                    item.useTime = 24;
                }
            }
            else
            {
                return false;
            }
            return base.CanUseItem(player);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (!Main.player[Main.myPlayer].HasBuff(mod.BuffType("ClaymoreCooldown")))
            {
                if (player.altFunctionUse == 2)
                {
                    player.AddBuff(mod.BuffType("ClaymoreCooldown"), 1550);
                    player.immune = true;
                    player.immuneTime = 200;
                }
            }
            else
            {
                return;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SteelAlloy"), 10);
            recipe.AddTile(mod.TileType("BlacksmithsForgeTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}