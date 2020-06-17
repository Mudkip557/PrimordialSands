using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrimordialSands.Shaders;

namespace PrimordialSands
{

    public class PrimordialSands : Mod
    {
        internal static PrimordialSands instance;
        public static ModHotKey ArtifactToggleHotKey;
        public PrimordialSands()
        {

        }
        public override void Load()
        {
            instance = this;
            ArtifactToggleHotKey = RegisterHotKey("Artifact Toggle Display", "Q");

            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Catacombs_Lvl2"), ItemType("CatacombsMusicBox"), TileType("CatacombsMusicBox"));
            }
        }
        public override void Unload()
        {
            instance = null;
            ArtifactToggleHotKey = null;
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
            {
                if (Main.LocalPlayer.GetModPlayer<PrimordialSandsPlayer>().ZoneSwamp)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/The_Jungles_Den");
                    priority = MusicPriority.BiomeHigh;
                }
            }
            if (PrimordialSandsWorld.OrcsAcquisitionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/OrcinAquisition");
                priority = MusicPriority.BiomeLow;
            }
        }
    }
}