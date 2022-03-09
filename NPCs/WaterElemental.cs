using ClickerClass.Items;
using ClickerClass.Items.Accessories;
using ClickerClass.Items.Weapons.Clickers;
using ClickerClass.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerClass.NPCs
{
	public class WaterElemental : ModNPC
	{
		public WaterElemental()
		{
		}

		public static bool SpawnNPC(int x, int y, int playerID)
		{
			if(Main.player[playerID].ZoneBeach && Main.rand.Next(16) == 1)
			{
				return true;
			}
			return false;
		}
	}
}
