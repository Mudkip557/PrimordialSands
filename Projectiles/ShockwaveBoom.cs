using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;

namespace PrimordialSands.Projectiles
{
    public class ShockwaveBoom : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 200;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            float progress = (180f - projectile.timeLeft) / 60f;
            float pulseCount = 35;
            float rippleSize = 0.00002f;
            float speed = 75;
            Filters.Scene["PrimordialSands:Shockwave"].GetShader().UseProgress(progress).UseOpacity(70f * (1 - progress / 3f));
            projectile.localAI[1]++;
            if (projectile.localAI[1] >= 0 && projectile.localAI[1] <= 60)
            {
                if (!Filters.Scene["PrimordialSands:Shockwave"].IsActive())
                {                                                             //pulseCount rippleSize speed
                    Filters.Scene.Activate("PrimordialSands:Shockwave", projectile.Center).GetShader().UseColor(pulseCount, rippleSize, speed).UseTargetPosition(projectile.Center);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Filters.Scene["PrimordialSands:Shockwave"].Deactivate();
        }
    }
}
