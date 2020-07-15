using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;


namespace PrimordialSands.Projectiles
{
    public class MycelialMasherProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mycelial Warhammer");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.width = 88;
            projectile.height = 88;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.hide = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 12;
			projectile.ownerHitCheck = true;

		}
		public override void AI()
		{
			float spinVelocity = 56f; //Speed the projectile moves
			float num2 = 2f;
			float scaleFactor = 20f;
			Player player = Main.player[projectile.owner];
			float num3 = -0.7853982f;
			Vector2 value = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 value2 = Vector2.Zero;
			if (player.dead)
			{
				projectile.Kill();
				return;
			}
				int num4 = projectile.damage * 2;
				int num5 = Math.Sign(projectile.velocity.X);
				projectile.velocity = new Vector2((float)num5, 0f);
				if (projectile.ai[0] == 0f)
				{
					projectile.rotation = new Vector2((float)num5, -player.gravDir).ToRotation() + num3 + 3.14159274f;
					if (projectile.velocity.X < 0f)
					{
						projectile.rotation -= 1.57079637f;
					}
				}
				projectile.alpha -= 128;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
				float arg_2E4_0 = projectile.ai[0] / spinVelocity;
				float num6 = 1f;
				projectile.ai[0] += num6;
				projectile.rotation += 2.88318548f * num2 / spinVelocity * (float)num5; //Controls The amount of times the projectile is rotated
				bool flag = projectile.ai[0] == (float)((int)(spinVelocity / 2f));
				if (projectile.ai[0] >= spinVelocity || (flag && !player.controlUseItem))
				{
					projectile.Kill();
					player.reuseDelay = 10;
				}
				else if (flag)
				{
					Vector2 mouseWorld = Main.MouseWorld;
					int num7 = (player.DirectionTo(mouseWorld).X > 0f) ? 1 : -1;
					if ((float)num7 != projectile.velocity.X)
					{
						player.ChangeDir(num7);
						projectile.velocity = new Vector2((float)num7, 0f);
						projectile.netUpdate = true;
						projectile.rotation -= 3.14159274f;
					}
				}
				float num8 = projectile.rotation - 0.7853982f * (float)num5;
				value2 = (num8 + ((num5 == -1) ? 3.14159274f : 0f)).ToRotationVector2() * (projectile.ai[0] / spinVelocity) * scaleFactor;
				Vector2 vector = projectile.Center + (num8 + ((num5 == -1) ? 3.14159274f : 0f)).ToRotationVector2() * 30f;


			if (projectile.ai[0] == spinVelocity - 3f && projectile.owner == Main.myPlayer)
			{
				Point point;
				if (projectile.localAI[1] == 1f || WorldUtils.Find(vector.ToTileCoordinates(), Searches.Chain(new Searches.Down(4), new GenCondition[]
				{
						new Conditions.IsSolid()
				}), out point))
				{
					Projectile.NewProjectile(vector + new Vector2((float)(num5 * 20), -60f), Vector2.Zero, ProjectileType< MycelialMasherProjectile_Impact>(), num4, 0f, projectile.owner, 0f, 0f);
					Main.PlayTrackedSound(SoundID.DD2_MonkStaffGroundImpact, projectile.Center);
				}
				else
				{
					Main.PlayTrackedSound(SoundID.DD2_MonkStaffSwing, projectile.Center);
				}
			}
			projectile.position = value - projectile.Size / 2f;
			projectile.position += value2;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = MathHelper.WrapAngle(projectile.rotation);
		}
	}
}
