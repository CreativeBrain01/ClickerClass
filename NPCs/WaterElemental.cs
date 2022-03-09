﻿using ClickerClass.Items;
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
            npc.width = 114;
            npc.height = 36;
            npc.aiStyle = 16;
			npc.noGravity = true;
			npc.stepSpeed = 500f;
			npc.damage = 70;
            npc.defense = 35;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 100f;
            animationType = NPCID.Shark;
        }

		/*
		public static bool SpawnNPC(int x, int y, int playerID)
		{
			if(Main.hardMode && Main.player[playerID].ZoneBeach && Main.rand.Next(50) == 1)
			{
				return true;
			}
			return false;
		}
		*/

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if(Main.hardMode == true && 
				Main.raining == true &&
				spawnInfo.spawnTileY <= Main.worldSurface && 
				spawnInfo.player.ZoneBeach && spawnInfo.water == true &&
				!NPC.AnyNPCs(ModContent.NPCType<WaterElemental>()))
			{
				return 0.1f;
			}
			else
			{
				return 0.0f;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.Hitbox, ModContent.ItemType<SurfFragment>(), 1);
			Item.NewItem(npc.Hitbox, ItemID.SharkFin, Main.rand.Next(2));
		}

        public override void AI()
        {
            base.AI();

			npc.TargetClosest();
			if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 position = npc.Center;
				Vector2 targetPosition = Main.player[npc.target].Center;
				Vector2 direction = targetPosition - position;
				direction.Normalize();
				float speed = 10f;
				int type = ProjectileID.GreenLaser;
				int damage = 30; //If the projectile is hostile, the damage passed into NewProjectile will be applied doubled, and quadrupled if expert mode, so keep that in mind when balancing projectiles
				Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
			}
        }
    }
}
