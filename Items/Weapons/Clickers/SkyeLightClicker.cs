using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class SkyeLightClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.SkyeLight = ClickerSystem.RegisterClickEffect(mod, "SkyeLight", null, null, 8, new Color(255, 3, 62), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<DarkClickerPro>(), damage, knockBack, player.whoAmI);
			});
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(item, 4.3f);
			SetColor(item, new Color(255, 3, 62));
			SetDust(item, 14);
			AddEffect(item, ClickEffect.SkyeLight);

			item.damage = 45;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 18000;
			item.rare = 1;
		}
	}
}
