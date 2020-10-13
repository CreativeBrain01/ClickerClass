using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ClickerClass.Items;

namespace ClickerClass.Projectiles
{
	public class SinisterClickerPro : ClickerProjectile
	{
		public override void SetDefaults()
		{
			isClickerProj = true;
			projectile.width = 8;
			projectile.height = 8;
			projectile.penetrate = 1;
			projectile.timeLeft = 10;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.extraUpdates = 3;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			player.statLife += 5;
			player.HealEffect(5);
		}
	}
}