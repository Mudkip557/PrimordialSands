using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using PrimordialSands.Dusts;

namespace PrimordialSands.Projectiles
{
    public class PoisonGas1Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poisonous Chemicals");
        }

        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            projectile.alpha = 235;
            projectile.timeLeft = 240;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            int num3;
            int num570 = 6;
            if (projectile.timeLeft == 240)
            {
                for (int num571 = 0; num571 < num570; num571 = num3 + 1)
                {
                    int Index = Dust.NewDust(projectile.position, (int)projectile.velocity.X, (int)projectile.velocity.Y, DustType<GasDust>(), 0f, 0f, projectile.alpha, new Color(0, 255, 0), 1f);
                    Dust dust = Main.dust[Index];
                    Main.dust[Index].scale = 1f;
                    Main.dust[Index].noGravity = true;
                    num3 = num571;

                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 240);
        }
    }
}