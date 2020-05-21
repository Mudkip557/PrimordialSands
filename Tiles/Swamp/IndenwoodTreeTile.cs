using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace PrimordialSands.Tiles.Swamp
{
	public class IndenwoodTreeTile : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("PrimordialSands");
			}
		}

        public override int CreateDust()
		{
			return mod.DustType("IndenwoodDust");
		}

		public override int GrowthFXGore()
		{
			return mod.GetGoreSlot("Gores/IndenwoodTreeFX");
		}

		public override int DropWood()
		{
			return mod.ItemType("Indenwood");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/Swamp/IndenwoodTreeTile");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/Swamp/IndenwoodTreeTile_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/Swamp/IndenwoodTreeTile_Branches");
		}
	}
}