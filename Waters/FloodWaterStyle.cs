using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace PrimordialSands.Waters
{
	public class FloodWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
			return Main.bgStyle == mod.GetSurfaceBgStyleSlot("FloodBackgroundSurface");
		}

		public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("FloodWaterfallStyle");
		}

		public override int GetSplashDust()
		{
			return mod.DustType("FloodWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/FloodDropplet");
		}

		public override Color BiomeHairColor()
		{
			return Color.Green;
		}
	}
}