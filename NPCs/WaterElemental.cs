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

		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Water Elemental");
            Main.npcFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 200;
        }

        public override void SetDefaults() {
			npc.
            npc.width = 114;
            npc.height = 36;
            npc.aiStyle = 16;
			npc.damage = 70;
            npc.defense = 35;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            animationType = NPCID.Shark;
        }

		public static bool SpawnNPC(int x, int y, int playerID)
		{
			if(Main.hardMode && Main.player[playerID].ZoneBeach && Main.rand.Next(16) == 1)
			{
				return true;
			}
			return false;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.Hitbox, ModContent.ItemType<SurfFragment>(), 1);
			Item.NewItem(npc.Hitbox, ItemID.SharkFin, Main.rand.Next(2));
		}
	}
}
