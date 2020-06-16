using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items.Armors
{
	[AutoloadEquip(EquipType.Head)]
	public class RogueShemagh : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Rogue Shemagh");
            Tooltip.SetDefault("Decreases enemy detection by 10%");
		}

		public override void SetDefaults()
		{
            item.height = 24;
            item.width = 32;
            item.value = Terraria.Item.buyPrice(0, 0, 30, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 2;
		}

        /*public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ExampleBreastplate") && legs.type == mod.ItemType("ExampleLeggings");
		}*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.aggro = -100;
            player.stealth += 0.1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Movement speed is moderately increased"
            + "\nPress [C] to disappear into smoke and evade enemy dection completely"
            + "\nprojectile effect lasts only 10 seconds and has a 5 minute cooldown";
            player.moveSpeed += 0.15f;

            /*if (playerVanish)
            {
                if (vanishCooldown == 0f)
                {
                    player.shroomiteStealth = true;
                    player.immune = true;
                    player.aggro = -1000;
                    player.stealth += 1f;
                    player.vanishCooldown += 0.1f;
                }
                else 
                if (vanishCooldown > 600f)
                {
                    player.shroomiteStealth = false;
                    player.immune = false;
                    player.aggro = -100;
                    player.stealth += 0.1f;
                }
            }*/
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Wool"), 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}