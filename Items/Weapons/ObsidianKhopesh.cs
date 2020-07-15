using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Security.Cryptography.X509Certificates;

namespace PrimordialSands.Items.Weapons
{
    public class ObsidianKhopesh : ModItem
    {
        public bool DashAttack = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Khopesh");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 16;
            item.crit = 4;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 14;
            item.useTime = 14;
            item.width = 34;
            item.height = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
            item.UseSound = SoundID.Item1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "ObsidianSword", "Allows stealth attacks when wearing Obsidian Armor");
            line.overrideColor = new Color(106, 255, 48);
            tooltips.Add(line);
        }

        public override bool CanUseItem(Player player)
        {
            int choice = Main.rand.Next(3);
            if (player.armor[0].type == ItemID.ObsidianHelm && 
                player.armor[1].type == ItemID.ObsidianShirt && 
                player.armor[2].type == ItemID.ObsidianPants)
            {
                if (choice == 0)
                {
                    item.useStyle = ItemUseStyleID.SwingThrow;
                }
                if (choice == 1)
                {
                    item.useStyle = ItemUseStyleID.Stabbing;
                }
                if (choice == 2)
                {
                    item.useStyle = ItemUseStyleID.Stabbing;
                    DashAttack = true;
                }
                float dash = 6f;
                if (DashAttack)
                {
                    if (player.direction == 1)
                    {
                        player.velocity = new Vector2(player.velocity.X + dash, player.velocity.Y);
                        if (player.velocity.X > 6f)
                        {
                            player.velocity.X = 6f;
                        }
                    }

                    if (player.direction == -1)
                    {
                        player.velocity = new Vector2(player.velocity.X - dash, player.velocity.Y);
                        if (player.velocity.X < 6f)
                        {
                            player.velocity.X = -6f;
                        }
                    }
                    else
                    {
                        item.useStyle = ItemUseStyleID.SwingThrow;
                    }
                    DashAttack = false;
                }
            }
            return base.CanUseItem(player);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, 1f, 1f, 0, default, 1f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 12);
            recipe.AddIngredient(ItemID.Hellstone, 3);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}