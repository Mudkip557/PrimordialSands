using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class IndenwoodKhopesh : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Indenwood Khopesh");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 16;
            item.crit = 4;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.buyPrice(0, 0, 75, 0);
            item.UseSound = SoundID.Item1;
        }
        /*public override void OnCraft(Recipe recipe)
        {
            Player player = Main.LocalPlayer;
            if (!PrimordialSandsPlayer.downedVajra)
            {
                CombatText.NewText(player.Hitbox, new Color(0, 160, 100), "Vajra's spirit curses this item!");
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/SFX/CurseSound"), player.Center);
            }
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 30);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}