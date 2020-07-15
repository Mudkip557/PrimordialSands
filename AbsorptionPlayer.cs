using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using PrimordialSands.Items;

namespace PrimordialSands
{
	public class AbsorptionPlayer : ModPlayer
	{
		public static AbsorptionPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<AbsorptionPlayer>();
		}
		public float absorptionDamage = 1f;
		public float absorptionKnockback = 0f;
		public int absorptionCrit = 0;
		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			absorptionDamage = 1f;
			absorptionKnockback = 0f;
			absorptionCrit = 0;
		}
	}
}
