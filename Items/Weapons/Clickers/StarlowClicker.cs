using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class StarlowClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.Starlow = ClickerSystem.RegisterClickEffect(mod, "Starlow", null, null, 8, new Color(11, 30, 56), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<DarkClickerPro>(), damage, knockBack, player.whoAmI);
			});
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(item, 3.14f);
			SetColor(item, new Color(11, 30, 56));
			SetDust(item, 14);
			AddEffect(item, ClickEffect.Starlow);

			item.damage = 15;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 18000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
