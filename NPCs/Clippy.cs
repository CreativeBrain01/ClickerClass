using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using ClickerClass.Items.Weapons.Clickers;

namespace ClickerClass.NPCs {
    [AutoloadHead]
    class Clippy: ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Clippy");
            Main.npcFrameCount[npc.type] = 23;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 2;
            NPCID.Sets.AttackTime[npc.type] = 23;
            NPCID.Sets.AttackAverageChance[npc.type] = 10;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Clothier;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            foreach (var p in Main.player) {
                if (p.active) return true;
            }
            return false;
        }

        public static bool vanilla;

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            vanilla = firstButton;
            shop = true;
        }

        public override string GetChat() {
            var dialog = new WeightedRandom<string>();
            dialog.Add("Hi im Clippy.");
            dialog.Add("It looks like your trying to write a letter, do you need help with that?");
            return dialog.Get();
        }

		public override string TownNPCName()
		{
			switch (Main.rand.Next(15))
			{
				case 0: return "Clippy";
				case 1: return "Clippy";
				case 2: return "Clippy";
				case 3: return "Clippy";
				case 4: return "Clippy";
				case 5: return "Clippy";
				case 6: return "Clippy";
				case 7: return "Clippy";
				case 8: return "Clippy";
				case 9: return "Clippy";
				case 10: return "Clippy";
				case 11: return "Clippy";
				case 12: return "Clippy";
				case 13: return "Clippy";
				case 14: return "This annoying piece of shit";
			}
			return "ERROR";
		}


		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            if (Main.hardMode) {
                damage = 60;
                knockback = 3;
            } else {
                damage = 20;
                knockback = 2;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.MagnetSphereBall;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
            multiplier = 7;
        }

		public override void NPCLoot()
		{
			Item.NewItem(npc.Hitbox, ModContent.ItemType<TheHandClicker>(), 1);
		}
	}
}
