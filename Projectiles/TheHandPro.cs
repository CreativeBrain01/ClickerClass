using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerClass.Projectiles
{
	public class TheHandPro : ClickerProjectile
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
			projectile.timeLeft = 20;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}

		public override void AI()
		{
			projectile.position = Main.MouseWorld;
			Vector2 mousePos = Main.MouseWorld;
			Player player = Main.player[0];

			if (!player.dead)
			{
				int grabRadius = 10 * 16; //16 == to world coordinates
				int fullhdgrabRadius = (int)(grabRadius * 0.5625f);

				Rectangle grabRect = new Rectangle((int)mousePos.X - grabRadius, (int)mousePos.Y - fullhdgrabRadius, player.width + grabRadius * 2, player.height + fullhdgrabRadius * 2);

				int grabbedItems = 0;

				for (int j = 0; j < Main.maxItems; j++)
				{
					Item item = Main.item[j];
					if (item.active && item.noGrabDelay == 0 && !ItemLoader.GrabStyle(item, player) && ItemLoader.CanPickup(item, player) && (player.ItemSpace(item)))
					{
						bool canGrabNetMode = true;
						//All: item.ownIgnore == -1 && item.keepTime == 0
						//Client: (above) && item.owner != 255 
						if (Main.netMode != NetmodeID.SinglePlayer)
						{
							if (item.instanced) canGrabNetMode &= item.owner == player.whoAmI;
						}

						if (canGrabNetMode && grabRect.Intersects(item.getRect()))
						{
								grabbedItems++;
								//so it can go through walls
								item.beingGrabbed = true;

								//velocity, higher = more speed
								float velo = 16; //16 ideal

								Vector2 distance = mousePos - item.Center;
								Vector2 normalizedDistance = distance;

								//adjustment term, increases velocity the closer to the player it is (0..2)
								float length = distance.Length();
								velo += 2 * (1 - length / grabRadius);

								if (length > 0)
								{
									normalizedDistance /= length;
								}
								normalizedDistance *= velo;

								//acceleration, higher = more acceleration
								int accel = -(20 - 41); //20 ideal

								item.velocity = (item.velocity * (accel - 1) + normalizedDistance) / (float)accel;

								if (Main.netMode != NetmodeID.Server)
								{
									float dustChance = length < player.height ? 0.7f / (player.height - length) : 0.7f;
									dustChance *= (11f - grabbedItems) / 10f;
									if (Main.rand.NextFloat() < dustChance - 0.02f)
									{
										Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 204, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
										dust.noGravity = true;
										dust.noLight = true;
									}
								}
							
						}
					}
				}
			}
		}
	}
}
