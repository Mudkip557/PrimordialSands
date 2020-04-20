using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Projectiles
{
    public class WitchFlaskProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vile Flask");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 22;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 300;
            projectile.magic = true;
            projectile.hostile = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 18f)
            {
                projectile.velocity.X = projectile.velocity.X * 0.995f;
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(13, projectile.position);
            int num13;
            for (int num186 = 0; num186 < 20; num186 = num13 + 1)
            {
                int num187 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 188, 0f, 0f, 100, default(Color), 1.5f);
                Dust dust = Main.dust[num187];
                dust.velocity *= 0.5f;
                num13 = num186;
            }
            for (int num188 = 0; num188 < 5; num188 = num13 + 1)
				{
					int num189 = Gore.NewGore(new Vector2(projectile.position.X + (float)Main.rand.Next(projectile.width), projectile.position.Y + (float)Main.rand.Next(projectile.height)), default(Vector2), Main.rand.Next(mod.GetGoreSlot("Gores/WitchFlaskGore1"), mod.GetGoreSlot("Gores/WitchFlaskGore2")), 1f);
                    Gore.NewGore(new Vector2(projectile.position.X + (float)Main.rand.Next(projectile.width), projectile.position.Y + (float)Main.rand.Next(projectile.height)), default(Vector2), Main.rand.Next(mod.GetGoreSlot("Gores/WitchFlaskGore2"), mod.GetGoreSlot("Gores/WitchFlaskGore3")), 1f);
					Gore gore = Main.gore[num189];
					gore.velocity *= 0.5f;
					if (num188 == 0)
					{
						Gore gore19 = Main.gore[num189];
						gore19.velocity.X = gore19.velocity.X + 1f;
						Gore gore20 = Main.gore[num189];
						gore20.velocity.Y = gore20.velocity.Y + 1f;
					}
					else if (num188 == 1)
					{
						Gore gore21 = Main.gore[num189];
						gore21.velocity.X = gore21.velocity.X - 1f;
						Gore gore22 = Main.gore[num189];
						gore22.velocity.Y = gore22.velocity.Y + 1f;
					}
					else if (num188 == 2)
					{
						Gore gore23 = Main.gore[num189];
						gore23.velocity.X = gore23.velocity.X + 1f;
						Gore gore24 = Main.gore[num189];
						gore24.velocity.Y = gore24.velocity.Y - 1f;
					}
					else
					{
						Gore gore25 = Main.gore[num189];
						gore25.velocity.X = gore25.velocity.X - 1f;
						Gore gore26 = Main.gore[num189];
						gore26.velocity.Y = gore26.velocity.Y - 1f;
					}
					gore = Main.gore[num189];
					gore.velocity *= 0.5f;
					num13 = num188;
				}
            int num3;
            if (Main.myPlayer == projectile.owner)
            {
                for (int num350 = 0; num350 < 8; num350 = num3 + 1)
                {
                    int projectileIndex = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, Main.rand.Next(mod.ProjectileType("PoisonGas1Projectile"), mod.ProjectileType("PoisonGas2Projectile")), projectile.damage / 3, 0f, projectile.owner, 0f, 0f);
                    num3 = num350;
                }
            }
        }
    }
}