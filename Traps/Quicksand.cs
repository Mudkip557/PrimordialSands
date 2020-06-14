
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimordialSands.Traps
{
    public class Quicksand : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            dustType = 54;
            mineResist = 0.65f;
            minPick = 50;
            soundType = SoundID.Dig;
            soundStyle = 2;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Quicksand");
            AddMapEntry(new Color(100, 30, 0), name);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            for (int i1 = 0; i1 < 3; i1++)
            {
                if (Main.rand.NextBool(27))
                {
                    int Index = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 32, 0f, 0f, 0, (default), 1f);
                    Dust dust = Main.dust[Index];
                    Main.dust[Index].alpha = 180;
                    Main.dust[Index].noGravity = true;
                    dust.velocity *= 1.6f;
                }

            }
        }
    }
}