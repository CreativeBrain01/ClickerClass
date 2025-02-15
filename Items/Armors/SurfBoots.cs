﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Armors
{
	[AutoloadEquip(EquipType.Legs)]
	public class SurfBoots : ClickerItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 40000;
			item.rare = 5;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SurfFragment>(), 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SurfFragment>(), 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}