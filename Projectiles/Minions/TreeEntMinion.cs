using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PrimordialSands.Projectiles.Minions
{
	public class TreeEntMinion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			DisplayName.SetDefault("Tree Ent");
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 50;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft = projectile.timeLeft * 5;
			projectile.minionSlots = 1f;
			projectile.minion = true;
			projectile.friendly = true;
			projectile.netImportant = true;
			projectile.tileCollide = false;
		}
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
			}
			return false;
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
		public override void AI()
		{
			//messiest code in the source btw, just vanilla code.
			Player player = Main.player[projectile.owner];
			player.AddBuff(mod.BuffType("TreeEntMinionBuff"), 3600);
			PrimordialSandsPlayer modPlayer = player.GetModPlayer<PrimordialSandsPlayer>();
			if (!player.active)
			{
				projectile.active = false;
				return;
			}

			bool minionCheck = projectile.type == mod.ProjectileType("TreeEntMinion") || projectile.type == mod.ProjectileType("TreeEntMinion_Alt");
			if (minionCheck)
			{
				if (player.dead)
				{
					modPlayer.treeEnt = false;
				}
				if (modPlayer.treeEnt)
				{
					projectile.timeLeft = 2;
				}
			}
			Vector2 vector53 = player.Center;
			if (minionCheck)
			{
				vector53.X -= (float)((15 + player.width / 2) * player.direction);
				vector53.X -= (float)(projectile.minionPos * 40 * player.direction);
			}
			bool flag27 = true;
			int num656 = -1;
			float num657 = 450f;
			if (minionCheck)
			{
				num657 = 800f;
			}
			int num658 = 15;
			if (projectile.ai[0] == 0f & flag27)
			{
				NPC ownerMinionAttackTargetNPC4 = projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC4 != null && ownerMinionAttackTargetNPC4.CanBeChasedBy(projectile, false))
				{
					float num659 = (ownerMinionAttackTargetNPC4.Center - projectile.Center).Length();
					if (num659 < num657)
					{
						num656 = ownerMinionAttackTargetNPC4.whoAmI;
						num657 = num659;
					}
				}
				if (num656 < 0)
				{
					int num3;
					for (int num660 = 0; num660 < 200; num660 = num3 + 1)
					{
						NPC nPC3 = Main.npc[num660];
						if (nPC3.CanBeChasedBy(projectile, false))
						{
							float num661 = (nPC3.Center - projectile.Center).Length();
							if (num661 < num657)
							{
								num656 = num660;
								num657 = num661;
							}
						}
						num3 = num660;
					}
				}
			}
			if (projectile.ai[0] == 1f)
			{
				projectile.tileCollide = false;
				float num662 = 0.2f;
				float num663 = 10f;
				int num664 = 200;
				if (num663 < Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y))
				{
					num663 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
				}
				Vector2 vector57 = player.Center - projectile.Center;
				float num665 = vector57.Length();
				if (num665 > 5000f)
				{
					projectile.position = player.Center - new Vector2((float)projectile.width, (float)projectile.height) / 2f;
				}
				if (num665 < (float)num664 && player.velocity.Y == 0f && projectile.position.Y + (float)projectile.height <= player.position.Y + (float)player.height && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
					if (projectile.velocity.Y < -6f)
					{
						projectile.velocity.Y = -6f;
					}
				}
				if (num665 >= 60f)
				{
					vector57.Normalize();
					vector57 *= num663;
					if (projectile.velocity.X < vector57.X)
					{
						projectile.velocity.X = projectile.velocity.X + num662;
						if (projectile.velocity.X < 0f)
						{
							projectile.velocity.X = projectile.velocity.X + num662 * 1.5f;
						}
					}
					if (projectile.velocity.X > vector57.X)
					{
						projectile.velocity.X = projectile.velocity.X - num662;
						if (projectile.velocity.X > 0f)
						{
							projectile.velocity.X = projectile.velocity.X - num662 * 1.5f;
						}
					}
					if (projectile.velocity.Y < vector57.Y)
					{
						projectile.velocity.Y = projectile.velocity.Y + num662;
						if (projectile.velocity.Y < 0f)
						{
							projectile.velocity.Y = projectile.velocity.Y + num662 * 1.5f;
						}
					}
					if (projectile.velocity.Y > vector57.Y)
					{
						projectile.velocity.Y = projectile.velocity.Y - num662;
						if (projectile.velocity.Y > 0f)
						{
							projectile.velocity.Y = projectile.velocity.Y - num662 * 1.5f;
						}
					}
				}
				if (projectile.velocity.X != 0f)
				{
					projectile.spriteDirection = Math.Sign(projectile.velocity.X);
				}
				if (minionCheck)
				{
					int num3 = projectile.frameCounter;
					projectile.frameCounter = num3 + 1;
					if (projectile.frameCounter > 3)
					{
						num3 = projectile.frame;
						projectile.frame = num3 + 1;
						projectile.frameCounter = 0;
					}
					if (projectile.frame < 10 | projectile.frame > 13)
					{
						projectile.frame = 10;
					}
					projectile.rotation = projectile.velocity.X * 0.1f;
				}
			}
			if (projectile.ai[0] == 2f)
			{
				projectile.friendly = true;
				projectile.spriteDirection = projectile.direction;
				projectile.rotation = 0f;
				projectile.frame = 4 + (int)((float)num658 - projectile.ai[1]) / (num658 / 3);
				if (projectile.velocity.Y != 0f)
				{
					projectile.frame += 3;
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.4f;
				if (projectile.velocity.Y > 10f)
				{
					projectile.velocity.Y = 10f;
				}
				projectile.ai[1] -= 1f;
				if (projectile.ai[1] <= 0f)
				{
					projectile.ai[1] = 0f;
					projectile.ai[0] = 0f;
					projectile.friendly = false;
					projectile.netUpdate = true;
					return;
				}
			}
			if (num656 >= 0)
			{
				float num666 = 400f;
				float num667 = 20f;
				if (minionCheck)
				{
					num666 = 700f;
				}
				if ((double)projectile.position.Y > Main.worldSurface * 16.0)
				{
					num666 *= 0.7f;
				}
				NPC nPC4 = Main.npc[num656];
				Vector2 center3 = nPC4.Center;
				float num668 = (center3 - projectile.Center).Length();
				Collision.CanHit(projectile.position, projectile.width, projectile.height, nPC4.position, nPC4.width, nPC4.height);
				if (num668 < num666)
				{
					vector53 = center3;
					if (center3.Y < projectile.Center.Y - 30f && projectile.velocity.Y == 0f)
					{
						float num669 = Math.Abs(center3.Y - projectile.Center.Y);
						if (num669 < 120f)
						{
							projectile.velocity.Y = -10f;
						}
						else if (num669 < 210f)
						{
							projectile.velocity.Y = -13f;
						}
						else if (num669 < 270f)
						{
							projectile.velocity.Y = -15f;
						}
						else if (num669 < 310f)
						{
							projectile.velocity.Y = -17f;
						}
						else if (num669 < 380f)
						{
							projectile.velocity.Y = -18f;
						}
					}
				}
				if (num668 < num667)
				{
					projectile.ai[0] = 2f;
					projectile.ai[1] = (float)num658;
					projectile.netUpdate = true;
				}
			}
			if (projectile.ai[0] == 0f && num656 < 0)
			{
				float num670 = 500f;
				if (Main.player[projectile.owner].rocketDelay2 > 0)
				{
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
				}
				Vector2 vector58 = player.Center - projectile.Center;
				if (vector58.Length() > 2000f)
				{
					projectile.position = player.Center - new Vector2((float)projectile.width, (float)projectile.height) / 2f;
				}
				else if (vector58.Length() > num670 || Math.Abs(vector58.Y) > 300f)
				{
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
					if (projectile.velocity.Y > 0f && vector58.Y < 0f)
					{
						projectile.velocity.Y = 0f;
					}
					if (projectile.velocity.Y < 0f && vector58.Y > 0f)
					{
						projectile.velocity.Y = 0f;
					}
				}
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.tileCollide = true;
				float num671 = 0.5f;
				float num672 = 4f;
				float num673 = 4f;
				float num674 = 0.1f;
				if (num673 < Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y))
				{
					num673 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
					num671 = 0.7f;
				}
				int num675 = 0;
				bool flag28 = false;
				float num676 = vector53.X - projectile.Center.X;
				if (Math.Abs(num676) > 5f)
				{
					if (num676 < 0f)
					{
						num675 = -1;
						if (projectile.velocity.X > -num672)
						{
							projectile.velocity.X = projectile.velocity.X - num671;
						}
						else
						{
							projectile.velocity.X = projectile.velocity.X - num674;
						}
					}
					else
					{
						num675 = 1;
						if (projectile.velocity.X < num672)
						{
							projectile.velocity.X = projectile.velocity.X + num671;
						}
						else
						{
							projectile.velocity.X = projectile.velocity.X + num674;
						}
					}
					if (!minionCheck)
					{
						flag28 = true;
					}
				}
				else
				{
					projectile.velocity.X = projectile.velocity.X * 0.9f;
					if (Math.Abs(projectile.velocity.X) < num671 * 2f)
					{
						projectile.velocity.X = 0f;
					}
				}
				if (num675 != 0)
				{
					int num677 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
					int num678 = (int)projectile.position.Y / 16;
					num677 += num675;
					num677 += (int)projectile.velocity.X;
					int num3;
					for (int num679 = num678; num679 < num678 + projectile.height / 16 + 1; num679 = num3 + 1)
					{
						if (WorldGen.SolidTile(num677, num679))
						{
							flag28 = true;
						}
						num3 = num679;
					}
				}
				Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY, 1, false, 0);
				if (projectile.velocity.Y == 0f & flag28)
				{
					int num3;
					for (int num680 = 0; num680 < 3; num680 = num3 + 1)
					{
						int num681 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
						if (num680 == 0)
						{
							num681 = (int)projectile.position.X / 16;
						}
						if (num680 == 2)
						{
							num681 = (int)(projectile.position.X + (float)projectile.width) / 16;
						}
						int num682 = (int)(projectile.position.Y + (float)projectile.height) / 16;
						if (WorldGen.SolidTile(num681, num682) || Main.tile[num681, num682].halfBrick() || Main.tile[num681, num682].slope() > 0 || (TileID.Sets.Platforms[(int)Main.tile[num681, num682].type] && Main.tile[num681, num682].active() && !Main.tile[num681, num682].inActive()))
						{
							try
							{
								num681 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
								num682 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
								num681 += num675;
								num681 += (int)projectile.velocity.X;
								if (!WorldGen.SolidTile(num681, num682 - 1) && !WorldGen.SolidTile(num681, num682 - 2))
								{
									projectile.velocity.Y = -5.1f;
								}
								else if (!WorldGen.SolidTile(num681, num682 - 2))
								{
									projectile.velocity.Y = -7.1f;
								}
								else if (WorldGen.SolidTile(num681, num682 - 5))
								{
									projectile.velocity.Y = -11.1f;
								}
								else if (WorldGen.SolidTile(num681, num682 - 4))
								{
									projectile.velocity.Y = -10.1f;
								}
								else
								{
									projectile.velocity.Y = -9.1f;
								}
								goto IL_1DF58;
							}
							catch
							{
								projectile.velocity.Y = -9.1f;
								goto IL_1DF58;
							}
						}
					IL_1DF58:
						num3 = num680;
					}
				}
				if (projectile.velocity.X > num673)
				{
					projectile.velocity.X = num673;
				}
				if (projectile.velocity.X < -num673)
				{
					projectile.velocity.X = -num673;
				}
				if (projectile.velocity.X < 0f)
				{
					projectile.direction = -1;
				}
				if (projectile.velocity.X > 0f)
				{
					projectile.direction = 1;
				}
				if (projectile.velocity.X > num671 && num675 == 1)
				{
					projectile.direction = 1;
				}
				if (projectile.velocity.X < -num671 && num675 == -1)
				{
					projectile.direction = -1;
				}
				projectile.spriteDirection = projectile.direction;
				projectile.velocity.Y = projectile.velocity.Y + 0.4f;
				if (projectile.velocity.Y > 10f)
				{
					projectile.velocity.Y = 10f;
				}
			}
			if (minionCheck)
			{
				projectile.localAI[0] += 1f;
				if (projectile.velocity.X == 0f)
				{
					projectile.localAI[0] += 1f;
				}
				if (projectile.localAI[0] >= (float)Main.rand.Next(900, 1200))
				{
					projectile.localAI[0] = 0f;
					int num3;
					for (int num683 = 0; num683 < 6; num683 = num3 + 1)
					{
						int num684 = Dust.NewDust(projectile.Center + Vector2.UnitX * -(float)projectile.direction * 8f - Vector2.One * 5f + Vector2.UnitY * 8f, 3, 6, 195, -(float)projectile.direction, 1f, 0, default(Color), 1f);
						Dust dust3 = Main.dust[num684];
						dust3.velocity /= 2f;
						Main.dust[num684].scale = 0.8f;
						num3 = num683;
					}
					return;
				}
			}
		}
	}
}