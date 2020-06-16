using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Items
{
    public class OrcWarDeclaration : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orcin Pillar");
            Tooltip.SetDefault("'Supposedly said to be a declaration item of war'");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Green;
            item.maxStack = 999;
            item.width = 34;
            item.height = 44;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 0, 0);
        }
		public override bool UseItem(Player player)
		{
				Main.NewText("An Orcin army is approaching!", 175, 75, 255, false);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            OrcsAcquisition.StartOrcsAcquisition();
			return true;
		}
    }
}