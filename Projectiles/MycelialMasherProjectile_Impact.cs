using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;


namespace PrimordialSands.Projectiles
{
	public class MycelialMasherProjectile_Impact : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mycelial Warhammer");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 46;
			projectile.height = 170;
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
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Point point = projectile.TopLeft.ToTileCoordinates();
			Point point2 = projectile.BottomRight.ToTileCoordinates();
			int num2 = 4;
			int width = projectile.width;
			for (int i = point.X; i <= point2.X; i++)
			{
				for (int j = point.Y; j <= point2.Y; j++)
				{
					if (Vector2.Distance(projectile.Bottom, new Vector2((float)(i * 16), (float)(j * 16))) <= (float)width)
					{
						for (int l = 0; l < num2 - 1; l++)
						{
							Dust.NewDust(target.Center, 0, 0, 4, 0, 0, 0, target.color, 1.5f);
						}
					}
				}
			}
		}

		public override void AI()
		{
			Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().screenShake = true;
			Point point = projectile.TopLeft.ToTileCoordinates();
			Point point2 = projectile.BottomRight.ToTileCoordinates();
			int arg_20_0 = point.X / 2;
			int arg_29_0 = point2.X / 2;
			int width = projectile.width;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 20f)
			{
				projectile.Kill();
				return;
			}
			if (projectile.ai[0] == 1f)
			{
				bool flag = false;
				int num = 4;
				for (int i = point.X; i <= point2.X; i++)
				{
					for (int j = point.Y; j <= point2.Y; j++)
					{
						if (Vector2.Distance(projectile.Bottom, new Vector2((float)(i * 16), (float)(j * 16))) <= (float)width)
						{
							Tile tileSafely = Framing.GetTileSafely(i, j);
							if (tileSafely.active() && Main.tileSolid[(int)tileSafely.type] && !Main.tileSolidTop[(int)tileSafely.type] && !Main.tileFrameImportant[(int)tileSafely.type])
							{
								Tile tileSafely2 = Framing.GetTileSafely(i, j - 1);
								if (!tileSafely2.active() || !Main.tileSolid[(int)tileSafely2.type] || Main.tileSolidTop[(int)tileSafely2.type])
								{
									int num2 = WorldGen.KillTile_GetTileDustAmount(true, tileSafely, i, j) * 6;
									for (int k = 0; k < num2; k++)
									{
										Dust dust;
										Dust expr_15A = dust = Main.dust[WorldGen.KillTile_MakeTileDust(i, j, tileSafely)];
										dust.velocity.Y = dust.velocity.Y - (3f + (float)num * 1.5f);
										Dust dust2 = expr_15A;
										dust2.velocity.Y = dust2.velocity.Y * Main.rand.NextFloat();
										expr_15A.scale += (float)num * 0.03f;
									}
									if (num >= 2)
									{
										for (int l = 0; l < num2 - 1; l++)
										{
											Dust dust3;
											Dust expr_1EA = dust3 = Main.dust[WorldGen.KillTile_MakeTileDust(i, j, tileSafely)];
											dust3.velocity.Y = dust3.velocity.Y - (1f + (float)num);
											Dust dust4 = expr_1EA;
											dust4.velocity.Y = dust4.velocity.Y * Main.rand.NextFloat();
										}
									}
									if (num2 > 0)
									{
										flag = true;
									}
								}
							}
						}
					}
				}
				Vector2 bottom = projectile.Bottom;
				Vector2 spinningpoint = new Vector2(7f, 0f);
				Vector2 value = new Vector2(1f, 0.7f);
				Color color = new Color(20, 255, 100, 200);
				for (float num3 = 0f; num3 < 25f; num3 += 1f)
				{
					Vector2 value2 = spinningpoint.RotatedBy((double)(num3 * 6.28318548f / 25f), default(Vector2)) * value;
					Dust dust5 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 55, 0f, 0f, 0, default(Color), 1f);
					dust5.alpha = 0;
					if (!flag)
					{
						dust5.alpha = 50;
					}
					dust5.color = color;
					dust5.position = bottom + value2;
					Dust dust6 = dust5;
					dust6.velocity.Y = dust6.velocity.Y - 3f;
					Dust dust7 = dust5;
					dust7.velocity.X = dust7.velocity.X * 0.5f;
					dust5.fadeIn = 0.5f + Main.rand.NextFloat() * 0.5f;
					dust5.noLight = true;
				}
				if (!flag)
				{
					for (float num4 = 0f; num4 < 25f; num4 += 1f)
					{
						Vector2 value3 = spinningpoint.RotatedBy((double)(num4 * 6.28318548f / 25f), default(Vector2)) * value;
						Dust expr_432 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 55, 0f, 0f, 0, default(Color), 1f);
						expr_432.alpha = 100;
						expr_432.color = color;
						expr_432.position = bottom + value3;
						Dust dust8 = expr_432;
						dust8.velocity.Y = dust8.velocity.Y - 5f;
						Dust dust9 = expr_432;
						dust9.velocity.X = dust9.velocity.X * 0.8f;
						expr_432.fadeIn = 0.5f + Main.rand.NextFloat() * 0.5f;
						expr_432.noLight = true;
					}
				}
			}
		}
		
	}
}