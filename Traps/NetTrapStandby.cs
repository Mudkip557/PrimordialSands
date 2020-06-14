using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Traps
{
	// This example shows how to have a tile that is cut by weapons, like vines and grass.
	// This example also shows how to spawn a projectile on death like Beehive and Boulder trap.
	internal class NetTrapStandby : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.AnchorTop = AnchorData.Empty;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.addTile(Type);
		}

		public override bool Dangersense(int i, int j, Player player) {
			return true;
		}

		public override bool CreateDust(int i, int j, ref int type) {
			return false;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			//Projectile.NewProjectile((float)(k * 16) + 15.5f, (float)(num4 * 16 + 16), 0f, 0f, 99, 70, 10f, Main.myPlayer, 0f, 0f);
			if (!WorldGen.gen && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Projectile.NewProjectile((i + 1.5f) * 16f, (j + 1.5f) * 16f, 0f, 0f, ProjectileID.Boulder, 70, 10f, Main.myPlayer, 0f, 0f);
			}

			//Item.NewItem(i * 16, j * 16, 48, 48, ItemType<ExampleCutTileItem>());
		}
	}
}
