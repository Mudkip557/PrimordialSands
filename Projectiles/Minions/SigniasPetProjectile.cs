using Microsoft.Xna.Framework;
using PrimordialSands.Buffs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Projectiles.Minions
{
	public class SigniasPetProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Whale");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 1f;
			projectile.tileCollide = false;
		}


		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (player.wet)
			{
				projectile.scale += 0.004f;
			}
			if (!player.wet && projectile.scale > 1f)
			{
				projectile.scale -= 0.005f;
			}
			float num = 4f;
			int num2 = 6;
			int num3 = 4;
			int num4 = Main.projFrames[projectile.type];
			int num5 = 0;
			Vector2 value = new Vector2((float)(player.direction * 30), -20f);
			PrimordialSandsPlayer modPlayer = player.GetModPlayer<PrimordialSandsPlayer>();
			if (!player.active)
			{
				projectile.active = false;
				return;
			}
			if (player.dead)
			{
				modPlayer.signiasPet = false;
			}
			if (modPlayer.signiasPet)
			{
				projectile.timeLeft = 2;
			}
			projectile.direction = (projectile.spriteDirection = player.direction);
			Vector2 vector = player.MountedCenter + value;
			float expr_39A = Vector2.Distance(projectile.Center, vector);
			if (expr_39A > 8000f)
			{
				projectile.Center = player.Center + value;
			}
			Vector2 vector2 = vector - projectile.Center;
			if (expr_39A < num)
			{
				projectile.velocity *= 0.25f;
			}
			if (vector2 != Vector2.Zero)
			{
				if (vector2.Length() < num * 0.5f)
				{
					projectile.velocity = vector2;
				}
				else
				{
					projectile.velocity = vector2 * 0.1f;
				}
			}
			if (projectile.velocity.Length() > 10f)
			{
				float num6 = projectile.velocity.X * 0.08f + projectile.velocity.Y * (float)projectile.spriteDirection * 0.02f;
				if (Math.Abs(projectile.rotation - num6) >= 3.14159274f)
				{
					if (num6 < projectile.rotation)
					{
						projectile.rotation -= 6.28318548f;
					}
					else
					{
						projectile.rotation += 6.28318548f;
					}
				}
				float num7 = 12f;
				projectile.rotation = (projectile.rotation * (num7 - 1f) + num6) / num7;
				int num8 = projectile.frameCounter + 1;
				projectile.frameCounter = num8;
				if (num8 >= num3)
				{
					projectile.frameCounter = 0;
					num8 = projectile.frame + 1;
					projectile.frame = num8;
					if (num8 >= num4)
					{
						projectile.frame = num5;
					}
				}
			}
			else
			{
				if (projectile.rotation > 3.14159274f)
				{
					projectile.rotation -= 6.28318548f;
				}
				if (projectile.rotation > -0.005f && projectile.rotation < 0.005f)
				{
					projectile.rotation = 0f;
				}
				else
				{
					projectile.rotation *= 0.96f;
				}
				int num8 = projectile.frameCounter + 1;
				projectile.frameCounter = num8;
				if (num8 >= num2)
				{
					projectile.frameCounter = 0;
					num8 = projectile.frame + 1;
					projectile.frame = num8;
					if (num8 >= num4)
					{
						projectile.frame = num5;
					}
				}
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 120f)
			{
				projectile.localAI[0] = 0f;
			}
		}
	}
}