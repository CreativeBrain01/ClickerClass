﻿using Terraria;
using Terraria.ModLoader;

namespace ClickerClass.Buffs
{
	public class WaveSpeed : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.20f;
		}
	}
}