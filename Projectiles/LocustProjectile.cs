using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimordialSands.Projectiles
{
    public class LocustProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Locust");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 12;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.minion = true;
        }
        public override void AI()
        {
            int DustIndex = Dust.NewDust(projectile.Center, 0, 0, 256, 0f, 0f, 6, default, 1f);
            Main.dust[DustIndex].alpha = 115;
            Main.dust[DustIndex].scale = 0.45f;
            int num = projectile.frameCounter + 1;
            projectile.frameCounter = num;
            if (num >= 9)
            {
                projectile.frameCounter = 0;
                num = projectile.frame + 1;
                projectile.frame = num;
                if (num >= 3)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 50;
            }
            else
            {
                projectile.extraUpdates = 0;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            if (projectile.velocity.X > 0f)
            {
                projectile.spriteDirection = 1;
            }
            else if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = -1;
            }
            projectile.rotation = projectile.velocity.X * 0.1f;

            float num372 = projectile.position.X;
            float num373 = projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 30f)
            {
                projectile.ai[0] = 30f;
                int num3;
                for (int num375 = 0; num375 < 200; num375 = num3 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(projectile, false) && (!Main.npc[num375].wet || projectile.type == 307))
                    {
                        float num376 = Main.npc[num375].position.X + (float)(Main.npc[num375].width / 2);
                        float num377 = Main.npc[num375].position.Y + (float)(Main.npc[num375].height / 2);
                        float num378 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num376) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num377);
                        if (num378 < 800f && num378 < num374 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num375].position, Main.npc[num375].width, Main.npc[num375].height))
                        {
                            num374 = num378;
                            num372 = num376;
                            num373 = num377;
                            flag10 = true;
                        }
                    }
                    num3 = num375;
                }
            }
            if (!flag10)
            {
                num372 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
                num373 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
            }
            float num379 = 6f;
            float num380 = 0.8f;
            Vector2 vector29 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num381 = num372 - vector29.X;
            float num382 = num373 - vector29.Y;
            float num383 = (float)Math.Sqrt((double)(num381 * num381 + num382 * num382));
            num383 = num379 / num383;
            num381 *= num383;
            num382 *= num383;
            if (projectile.velocity.X < num381)
            {
                projectile.velocity.X = projectile.velocity.X + num380;
                if (projectile.velocity.X < 0f && num381 > 0f)
                {
                    projectile.velocity.X = projectile.velocity.X + num380 * 2f;
                }
            }
            else if (projectile.velocity.X > num381)
            {
                projectile.velocity.X = projectile.velocity.X - num380;
                if (projectile.velocity.X > 0f && num381 < 0f)
                {
                    projectile.velocity.X = projectile.velocity.X - num380 * 2f;
                }
            }
            if (projectile.velocity.Y < num382)
            {
                projectile.velocity.Y = projectile.velocity.Y + num380;
                if (projectile.velocity.Y < 0f && num382 > 0f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num380 * 2f;
                    return;
                }
            }
            else if (projectile.velocity.Y > num382)
            {
                projectile.velocity.Y = projectile.velocity.Y - num380;
                if (projectile.velocity.Y > 0f && num382 < 0f)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num380 * 2f;
                    return;
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.NPCDeath21, projectile.position);
            Dust.NewDust(projectile.Center, 0, 0, 256, 0f, 0f, 6, default, 1.5f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(SoundID.NPCHit18, projectile.position);
            target.immune[projectile.owner] = 5;
        }
    }
}