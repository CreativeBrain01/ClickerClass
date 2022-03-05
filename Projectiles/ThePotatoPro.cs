using Microsoft.Xna.Framework;
using Terraria;

namespace ClickerClass.Projectiles
{
	public class ThePotatoPro : ClickerProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ThePotato");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 25;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 300;
		}
	}
}
