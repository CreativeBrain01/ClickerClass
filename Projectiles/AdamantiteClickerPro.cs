using Terraria;
using Terraria.ID;

namespace ClickerClass.Projectiles
{
	public class AdamantiteClickerPro : ClickerProjectile
	{
		public bool Spawned
		{
			get => projectile.ai[0] == 1f;
			set => projectile.ai[0] = value ? 1f : 0f;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			damage *= 2;
			crit = true;
		}

		public override void AI()
		{
			if (!Spawned)
			{
				Spawned = true;

				Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 71);
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 8; k++)
			{
				Dust dust = Dust.NewDustDirect(projectile.Center, 10, 10, 90, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, default, 1.25f);
				dust.noGravity = true;
			}
		}
	}
}
