using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ClickerClass.Items
{
	public class SurfFragment : ClickerItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 20;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 5;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}