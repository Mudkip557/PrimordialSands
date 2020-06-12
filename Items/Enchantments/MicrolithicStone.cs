using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Enchantments
{
    public class MicrolithicStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Microlithic Stone");
            Tooltip.SetDefault("Enchanting Item");
        }
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.rare = ItemRarityID.Orange;
            item.width = 30;
            item.height = 30;
        }
    }
}
