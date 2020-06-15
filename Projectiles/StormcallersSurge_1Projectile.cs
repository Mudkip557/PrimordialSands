using IL.Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrimordialSands.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Projectiles
{
    public class StormcallersSurge_1Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stormcaller's Surge");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 100;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
            projectile.extraUpdates = 18;

            projectile.friendly = true;
            projectile.magic = true;
        }
        int radians = 8;
        public override void AI()
        {
            int num3;
            for (int num20 = 0; num20 < 1; num20 = num3 + 1)
            {
                float num21 = projectile.velocity.X / 2f * (float)num20;
                float num22 = projectile.velocity.Y / 2f * (float)num20;
                int num23 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 246, 0f, 0f, 0, default(Color), 0.5f);
                Main.dust[num23].position.X = projectile.Center.X - num21;
                Main.dust[num23].position.Y = projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                Main.dust[num23].scale = 0.5f;
                num3 = num20;
            }

            projectile.ai[0] += 1;
            if (projectile.ai[0] >= 8)
            {
                Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(radians));
                if (radians >= 16)
                {
                    radians = -24;
                }
                if (radians <= -16)
                {
                    radians = 16;
                }
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                projectile.velocity.Y = perturbedSpeed.Y;
                projectile.velocity.X = perturbedSpeed.X;
                projectile.ai[0] = 0;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item66, projectile.position);
            int num3;
            int num570 = 6;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(projectile.Center, 0, 0, 246, 0f, 0f, 100, default, 5f);
                Dust dust = Main.dust[num572];
                dust.velocity *= 1.6f;
                Dust dust56 = Main.dust[num572];
                dust56.velocity.Y = dust56.velocity.Y - 1f;
                dust = Main.dust[num572];
                dust.velocity += -projectile.velocity * (Main.rand.NextFloat() * 2f - 1f) * 0.5f;
                Main.dust[num572].scale = 1.5f;
                Main.dust[num572].fadeIn = 0.5f;
                Main.dust[num572].noGravity = true;
                num3 = num571;
            }
        }
    }
}