using ClickerClass.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.Items.Armors
{
	[AutoloadEquip(EquipType.Head)]
	public class SurfVisor : ClickerItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 45000;
			item.rare = 5;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
			clickerPlayer.clickerCrit += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SurfShirt>() && legs.type == ModContent.ItemType<SurfBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = LangHelper.GetText("SetBonus.Surf");
			player.GetModPlayer<ClickerPlayer>().setSurf = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SurfFragment>(), 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SurfFragment>(), 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}