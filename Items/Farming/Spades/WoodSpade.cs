using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Farming.Spades
{
    public class WoodSpade : FarmToolItem
    {
        public bool itemCrafted = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Spade");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
            item.knockBack = 1f;
            item.value = Item.buyPrice(0, 0, 0, 35);
            item.pick = 18;
            spade = true;
            treasureChance = 100;
        }
        public override void OnCraft(Recipe recipe)
        {
            PrimordialSandsWorld.playerCraftedWoodSpade = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (!PrimordialSandsWorld.playerCraftedWoodSpade)
            {
                TooltipLine line = new TooltipLine(mod, "WoodSpade_Hint", "Generally faster than metal spades");

                line.overrideColor = new Color(106, 190, 48);
                tooltips.Add(line);
            }
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "PickPower" && x.mod == "Terraria"); //Tooltip resets so this is a quickfix
            if (tt != null)
            {
                tt.text = item.pick + "% digging power";
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}