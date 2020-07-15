using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;


namespace PrimordialSands.Items.Farming
{
    public abstract class FarmToolItem : ModItem
    {
        public override bool CloneNewInstances => true;
        public float treasureChance = 0f;
        public bool spade = false;
        public bool hoe = false;
        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Farming_Tool_Tooltip", "-- Farming Tool --");
            line.overrideColor = new Color(106, 190, 48);

            tooltips.Add(line);
            if (spade)
            {
                TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "PickPower" && x.mod == "Terraria");
                if (tt != null)
                {
                    tt.text = item.pick + "% digging power";
                }
            }
            if (hoe)
            {
                TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "PickPower" && x.mod == "Terraria");
                if (tt != null)
                {
                    tt.text = item.pick + "% tilling strength";
                }
            }


            if (treasureChance > 0)
            {
                tooltips.Add(new TooltipLine(mod, "Treasure Rate", $" {100f / treasureChance}% chance to dig up treasure"));
            }
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return rand.Next(new int[] { PrefixID.Agile, PrefixID.Quick, PrefixID.Light, PrefixID.Slow, PrefixID.Sluggish, PrefixID.Lazy, PrefixID.Large });
        }
    }
}