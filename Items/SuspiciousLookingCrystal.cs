using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace PrimordialSands.Items
{
    public class SuspiciousLookingCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("An ancient rock");
            Tooltip.SetDefault("Summons an ancient elemental\nUse in the light of the sun while at the jungle");
        }
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = 6;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("EngulfedTreant"));
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("EngulfedTreant"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}