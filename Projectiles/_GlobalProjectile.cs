using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Projectiles
{
    public class _GlobalProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>();
            if (modPlayer.ankhTopaz && projectile.magic)
            {
                if (Main.rand.NextBool(4))
                {
                    target.AddBuff(BuffID.OnFire, 120);
                }
            }
        }
    }
}
