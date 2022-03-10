using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class TheHandClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.TheHand = ClickerSystem.RegisterClickEffect
				(mod, "TheHand", null, null, 0, new Color(255, 3, 62), 
				delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<TheHandPro>(), 
					0, 0, player.whoAmI);
			});
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(item, 10f);
			SetColor(item, new Color(255, 3, 62));
			SetDust(item, 14);
			AddEffect(item, ClickEffect.TheHand);

			item.damage = 12;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 180000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTime = 0;
		}
	}
}
