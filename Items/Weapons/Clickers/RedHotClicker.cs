using ClickerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class RedHotClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.Inferno = ClickerSystem.RegisterClickEffect(Mod, "Inferno", null, null, 8, new Color(255, 125, 0), delegate (Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<RedHotClickerPro>(), 0, knockBack, player.whoAmI);
			});
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(Item, 2.6f);
			SetColor(Item, new Color(255, 125, 0));
			SetDust(Item, 174);
			AddEffect(Item, ClickEffect.Inferno);

			Item.damage = 12;
			Item.width = 30;
			Item.height = 30;
			Item.knockBack = 1f;
			Item.value = 27000;
			Item.rare = 3;
		}

		public override void AddRecipes()
		{
			CreateRecipe(1).AddIngredient(ItemID.HellstoneBar, 8).AddTile(TileID.Anvils).Register();
		}
	}
}
