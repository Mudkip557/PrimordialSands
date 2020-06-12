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
            projectile.width = 28;
            projectile.height = 28;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
            projectile.timeLeft = 240;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 240);
        }
    }
}