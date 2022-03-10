using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class AbhorrentClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.AbhorrentStrike = ClickerSystem.RegisterClickEffect(mod, "AbhorrentStrike", null, null, 8, new Color(95, 105, 45), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<AbhorrentClickerPro>(), damage, knockBack, player.whoAmI);
			});
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(item, 3.00f);
			SetColor(item, new Color(185, 175, 75));
			SetDust(item, 21);
			AddEffect(item, ClickEffect.AbhorrentStrike);

			item.damage = 24;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 242000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddIngredient(ModContent.ItemType<SurfFragment>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
