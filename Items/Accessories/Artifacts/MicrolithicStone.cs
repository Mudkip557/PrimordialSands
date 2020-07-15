using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Accessories.Artifacts
{
	public class MicrolithicStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Microlithic Stone");
			Tooltip.SetDefault("Grants Fortune harvesting, which allows for ore tiles to drop more ore" +
				"\nFortune harvesting rates are uncommon");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.rare = ItemRarityID.Orange;
			item.width = 24;
			item.height = 30;
			item.accessory = true;
		}
		public override void PostUpdate()
		{
			if (Main.rand.Next(4) == 0)
			{
				Vector2 vector119 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust108 = Main.dust[Dust.NewDust(item.Center - vector119 * 30f, 0, 0, 240, 0f, 0f, 0, default(Color), 1f)];
				dust108.noGravity = true;
				dust108.position = item.Center - vector119 * (float)Main.rand.Next(10, 11);
				dust108.velocity = vector119.RotatedBy(1.5707963705062866, default(Vector2)) * 4f;
				dust108.scale = 0.5f + Main.rand.NextFloat();
				dust108.fadeIn = 0.5f;
			}
			if (Main.rand.Next(4) == 0)
			{
				Vector2 vector120 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust109 = Main.dust[Dust.NewDust(item.Center - vector120 * 30f, 0, 0, 246, 0f, 0f, 0, default(Color), 1.5f)];
				dust109.noGravity = true;
				dust109.position = item.Center - vector120 * 25f;
				dust109.velocity = vector120.RotatedBy(-1.5707963705062866, default(Vector2)) * 2f;
				dust109.scale = 0.5f + Main.rand.NextFloat();
				dust109.fadeIn = 0.5f;
			}
			if (Main.rand.Next(2) == 0)
			{
				Vector2 vector124 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust111 = Main.dust[Dust.NewDust(item.Center - vector124 * 30f, 0, 0, 240, 0f, 0f, 0, default(Color), 1f)];
				dust111.noGravity = true;
				dust111.position = item.Center - vector124 * (float)Main.rand.Next(10, 11);
				dust111.velocity = vector124.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
				dust111.scale = 0.5f + Main.rand.NextFloat();
				dust111.fadeIn = 0.5f;
				dust111.customData = item.Center;
			}
			if (Main.rand.Next(2) == 0)
			{
				Vector2 vector125 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust112 = Main.dust[Dust.NewDust(item.Center - vector125 * 30f, 0, 0, 246, 0f, 0f, 0, default(Color), 1.5f)];
				dust112.noGravity = true;
				dust112.position = item.Center - vector125 * 25f;
				dust112.velocity = vector125.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
				dust112.scale = 0.5f + Main.rand.NextFloat();
				dust112.fadeIn = 0.5f;
				dust112.customData = item.Center;
			}
		}

		public override bool GrabStyle(Player player)
		{
			Vector2 vectorItemToPlayer = player.Center - item.Center;
			Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
			item.velocity = item.velocity + movement;
			item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
			return true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().harvestEnchant = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(255, 71, 49);
				}
			}
			TooltipLine line = new TooltipLine(mod, "MicrolithicStone", "Artifact Item");
            line.overrideColor = new Color(255, 71, 49);
            tooltips.Add(line);
        }
    }
}
