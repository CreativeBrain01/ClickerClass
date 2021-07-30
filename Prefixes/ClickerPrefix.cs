using ClickerClass.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ClickerClass.Prefixes
{
	[Autoload(false)]
	public class ClickerPrefix : ModPrefix
	{
		public override string Name { get; }

		internal static List<int> ClickerPrefixes;
		internal float damageMult = 1f;
		internal float radiusBonus = 0;
		internal int clickBonus = 0;
		internal int critBonus = 0;
		internal string displayName;

		public override PrefixCategory Category => PrefixCategory.Custom;

		public ClickerPrefix() { }

		public ClickerPrefix(string name, string displayName, float damageMult, float radiusBonus, int clickBonus, int critBonus)
		{
			Name = name ?? base.Name;
			this.displayName = displayName;
			this.damageMult = damageMult;
			this.radiusBonus = radiusBonus;
			this.clickBonus = clickBonus;
			this.critBonus = critBonus;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(displayName);
		}

		public override void Apply(Item item)
		{
			if (ClickerSystem.IsClickerWeapon(item, out ClickerItemCore clickerItem))
			{
				clickerItem.radiusBoostPrefix = radiusBonus;
				clickerItem.clickBoostPrefix = clickBonus;
			}
		}

		public override void ModifyValue(ref float valueMult) => valueMult *= 1 + radiusBonus * 0.025f;

		public override bool CanRoll(Item item)
		{
			if (ClickerSystem.IsClickerWeapon(item))
			{
				return item.maxStack == 1 && item.damage > 0 && item.useStyle > 0;
			}
			return false;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult = this.damageMult;
			critBonus = this.critBonus;
		}

		internal static void LoadPrefixes(Mod mod)
		{
			ClickerPrefixes = new List<int>();
			AddClickerPrefix(mod, ClickerPrefixType.Elite, "Elite", 1.15f, 0.3f, -1, 2);
			AddClickerPrefix(mod, ClickerPrefixType.Pro, "Pro", 1.1f, 0.2f, 0, 2);
			AddClickerPrefix(mod, ClickerPrefixType.Amateur, "Amateur", 1f, 0.3f, -1, 0);
			AddClickerPrefix(mod, ClickerPrefixType.Novice, "Novice", 1f, 0.2f, 0, 0);
			AddClickerPrefix(mod, ClickerPrefixType.Laggy, "Laggy", 0.9f, -0.2f, 0, 0);
			AddClickerPrefix(mod, ClickerPrefixType.Disconnected, "Disconnected", 0.8f, -0.3f, 1, 0);
		}

		internal static void UnloadPrefixes()
		{
			ClickerPrefixes?.Clear();
			ClickerPrefixes = null;
		}

		internal static void AddClickerPrefix(Mod mod, ClickerPrefixType prefixType, string displayName, float damageMult = 1f, float radiusBonus = 0f, int clickBonus = 0, int critBonus = 0)
		{
			string name = prefixType.ToString();
			mod.AddContent(new ClickerPrefix(name, displayName, damageMult, radiusBonus, clickBonus, critBonus));
			if (mod.TryFind(name, out ModPrefix prefix))
			{
				ClickerPrefixes.Add(prefix.Type);
			}
		}
	}

	public enum ClickerPrefixType : byte
	{
		Elite,
		Pro,
		Amateur,
		Novice,
		Laggy,
		Disconnected
	}
}