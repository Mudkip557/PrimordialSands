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
    public class VajrsThorns : ModProjectile
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
            projectile.localAI[0] += 1;
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
            if (projectile.localAI[0] >= 40)
            {
                int num13 = 0;
                int num20 = 72;
                for (int i = 0; i < num20; i++)
                {
                    Vector2 vector2 = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, (float)projectile.height) * 0.75f * 0.5f;
                    vector2 = vector2.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + projectile.Center;
                    Vector2 vector3 = vector2 - projectile.Center;
                }
                int num229 = 4;
                int[] array = new int[num229];
                int num230 = 0;
                if (num230 > 1)
                {
                    for (int num232 = 0; num232 < 100; num232 = num13 + 1)
                    {
                        int num233 = Main.rand.Next(num230);
                        int num234;
                        for (num234 = num233; num234 == num233; num234 = Main.rand.Next(num230))
                        {
                        }
                        int num235 = array[num233];
                        array[num233] = array[num234];
                        array[num234] = num235;
                        num13 = num232;
                    }
                }
                Vector2 vector10 = new Vector2(-1f, -1f);
                for (int num236 = 0; num236 < num230; num236 = num13 + 1)
                {
                    Vector2 value9 = Main.npc[array[num236]].Center - projectile.Center;
                    value9.Normalize();
                    vector10 += value9;
                    num13 = num236;
                }
                vector10.Normalize();
                for (int num237 = 0; num237 < num229; num237 = num13 + 1)
                {
                    float scaleFactor = (float)Main.rand.Next(1, 3);
                    Vector2 vector11 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    vector11.Normalize();
                    if (num230 > 0)
                    {
                        vector11 += vector10;
                        vector11.Normalize();
                    }
                    vector11 *= scaleFactor;
                    if (num230 > 0)
                    {
                        num13 = num230;
                        num13 = num13 - 1;
                        vector11 = Main.npc[array[num230]].Center - projectile.Center;
                        vector11.Normalize();
                        vector11 *= scaleFactor;
                    }
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector11.X, vector11.Y, mod.ProjectileType("StormcallersSurge_1Projectile"), (int)((double)projectile.damage * 0.7), projectile.knockBack * 0.7f, projectile.owner, 0f, 0f);
                    num13 = num237;
                    projectile.localAI[0] = 0;
                }
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