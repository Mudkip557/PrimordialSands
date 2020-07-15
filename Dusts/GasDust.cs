using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace PrimordialSands.Dusts
{
    public class GasDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 0.05f;
            dust.frame = new Rectangle((Main.rand.Next(0, 1) == 0) ? 0 : 125, 0, 125, 125);
            dust.alpha = 245;
        }

        public override bool Update(Dust dust)
        {
            dust.alpha = 200;
            if (Main.rand.Next(0, 7) == 1) dust.alpha++;
            dust.position -= dust.velocity;
            if (dust.alpha > 255)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
