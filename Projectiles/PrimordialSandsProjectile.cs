using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace PrimordialSands.Projectiles
{
	public class PrimordialSandsProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Sands");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.height = 44;
			projectile.width = 16;
			projectile.magic = true;
			projectile.tileCollide = false;

		}
		public override void AI()
		{
			
		}
	}
}