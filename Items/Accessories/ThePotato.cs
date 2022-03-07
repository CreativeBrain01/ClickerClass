using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ClickerClass.Items.Accessories
{
	public class ThePotato : ClickerItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.ThePotato = ClickerSystem.RegisterClickEffect
				(mod, "ThePotato", "ThePotato", null, 6, new Color(255, 255, 255, 0), delegate 
				(Player player, Vector2 position, int type, int damage, float knockBack)
			{
				int potato = ModContent.ProjectileType<ThePotatoPro>();
				Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, potato, 25, 3f, player.whoAmI, Main.rand.Next(Main.projFrames[potato]));
			});

			Tooltip.SetDefault("Whatever you do," + "\n" + 
				"don't reveal your plans on YouTube," + "\n" + 
				"you fool, you absolute buffoon.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 25000;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<ClickerPlayer>().EnableClickEffect(ClickEffect.ThePotato);
		}
	}
}
