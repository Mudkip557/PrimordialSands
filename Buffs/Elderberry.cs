using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using PrimordialSands.NPCs;

namespace PrimordialSands.Buffs
{
	public class Elderberry : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Elderberry Effects");
			Description.SetDefault("Your maximum health has temporarily been increased");
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<PrimordialSandsPlayer>().elderberryBuff = true;
		}
	}
}
