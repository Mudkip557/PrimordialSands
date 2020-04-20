using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using PrimordialSands.Items;

namespace PrimordialSands
{
    public abstract class AbsorptionProjectile : ModProjectile
    {
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player owner = null;
            if (projectile.owner != -1)
                owner = Main.player[projectile.owner];
            else if (projectile.owner == 255)
                owner = Main.LocalPlayer;

            ModItem mItem = owner.HeldItem.modItem;
            if (mItem != null)
            {
                int cc = owner.HeldItem.crit;
                (mItem as AbsorptionItem).GetWeaponCrit(owner, ref cc);
                crit = crit || Main.rand.Next(1, 101) <= cc;
            }
        }
    }

    public abstract class AbsorptionItem : ModItem
    {
        public override void SetDefaults()
        {
            item.crit = 4;
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            damage = (int)(damage * AbsorptionPlayer.ModPlayer(player).absorptionDamage + 5E-06f);
        }
        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback = knockback + AbsorptionPlayer.ModPlayer(player).absorptionKnockback;
        }
        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit = crit + AbsorptionPlayer.ModPlayer(player).absorptionCrit;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " absorption " + damageWord;
            }

            if (item.crit > 0)
            {
                int crit = item.crit;
                GetWeaponCrit(Main.LocalPlayer, ref crit);
                tt = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.mod == "Terraria");
                if (tt != null)
                {
                    tt.text = crit + "% " + string.Join(" ", tt.text.Split(' ').Skip(1).ToArray());
                }
                else
                {
                    TooltipLine ttl = new TooltipLine(mod, "CritChance", crit + "% critical strike chance");
                    int index = tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria");
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, ttl);
                    }
                }
            }
        }
    }
}