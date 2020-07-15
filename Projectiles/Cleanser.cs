using Microsoft.Xna.Framework;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using IL.Terraria.Map;

namespace PrimordialSands.Projectiles
{
	public class Cleanser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("lol cleanser");
		}
		public override void SetDefaults()
		{
			projectile.width = 9999;
			projectile.height = 9999;
			projectile.penetrate = 3;
			projectile.aiStyle = 6;
			aiType = 10;
			projectile.timeLeft = 2;
			projectile.tileCollide = true;
			projectile.friendly = true;
		}
		public override void AI()
		{
			int num64 = (int)(projectile.position.X * 16f) - 1;
			int num65 = (int)((projectile.position.X + (float)projectile.width) / 16f) + 12;
			int num66 = (int)(projectile.position.Y * 16f) - 1;
			int num67 = (int)((projectile.position.Y + (float)projectile.height) / 16f) + 12;
			if (num64 < 0)
			{
				num64 = 0;
			}
			if (num65 > Main.maxTilesX)
			{
				num65 = Main.maxTilesX;
			}
			if (num66 < 0)
			{
				num66 = 0;
			}
			if (num67 > Main.maxTilesY)
			{
				num67 = Main.maxTilesY;
			}
			int num3;
			for (int num68 = num64; num68 < num65; num68 = num3 + 1)
			{
				for (int num69 = num66; num69 < num67; num69 = num3 + 1)
				{
					NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
					Vector2 vector5;
					vector5.X = (float)(num68 * 116);
					vector5.Y = (float)(num69 * 116);
					if (projectile.position.X + (float)projectile.width > vector5.X && projectile.position.X < vector5.X + 16f && projectile.position.Y + (float)projectile.height > vector5.Y && projectile.position.Y < vector5.Y + 16f && Main.myPlayer == projectile.owner && Main.tile[num68, num69].active())
					{
							if (Main.tile[num68, num69].type == 23 || Main.tile[num68, num69].type == 199)
							{
								Main.tile[num68, num69].type = 2;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode == NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							
							if (Main.tile[num68, num69].type == 25 || Main.tile[num68, num69].type == 203)
							{
								Main.tile[num68, num69].type = 1;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 112 || Main.tile[num68, num69].type == 234)
							{
								Main.tile[num68, num69].type = 53;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 163 || Main.tile[num68, num69].type == 200)
							{
								Main.tile[num68, num69].type = 161;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 400 || Main.tile[num68, num69].type == 401)
							{
								Main.tile[num68, num69].type = 396;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 398 || Main.tile[num68, num69].type == 399)
							{
								Main.tile[num68, num69].type = 397;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
						}
						else if (projectile.type == 11 || projectile.type == 463)
						{
							if (Main.tile[num68, num69].type == 109)
							{
								Main.tile[num68, num69].type = 2;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 116)
							{
								Main.tile[num68, num69].type = 53;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 117)
							{
								Main.tile[num68, num69].type = 1;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 164)
							{
								Main.tile[num68, num69].type = 161;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 403)
							{
								Main.tile[num68, num69].type = 396;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
							if (Main.tile[num68, num69].type == 402)
							{
								Main.tile[num68, num69].type = 397;
								WorldGen.SquareTileFrame(num68, num69, true);
								if (Main.netMode ==  NetmodeID.MultiplayerClient)
								{
									NetMessage.SendTileSquare(-1, num68, num69, 1, TileChangeType.None);
								}
							}
						}
					}
					num3 = num69;
				}
				num3 = num68;
			}
			return;
		}
	}
}