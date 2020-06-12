using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PrimordialSands.Projectiles.Minions;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Items.Weapons.Indenwood
{
    public class TreeEntStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Ent Staff");
            Tooltip.SetDefault("Summons a cute tree ent to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.crit = 4;
            item.rare = ItemRarityID.Blue;
            item.width = 42;
            item.height = 48;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3f;
            item.mana = 8;
            item.summon = true;
            item.noMelee = true;
            item.value = Terraria.Item.buyPrice(0, 0, 80, 0);
            item.UseSound = SoundID.Item83;
            if (Main.rand.Next(2) == (0))
            {
                item.shoot = ProjectileType<TreeEntMinion>();
            }
            else
            {
                item.shoot = ProjectileType<TreeEntMinion_Alt>();
            }

            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Indenwood"), 28);
            recipe.AddTile(mod.TileType("IndenstoneAnvilTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}