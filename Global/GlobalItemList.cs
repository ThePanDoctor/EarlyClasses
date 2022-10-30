using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EarlyClasses.Global
{
	public class GlobalItemList : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.FlinxFurCoat)
			{
				item.defense = 3;
			}

		}
		
		// Tests if an armor set is being used
		public override string IsArmorSet(Item head, Item body, Item legs) 
		{
			// Checking for gold armor pieces
			if (head.type == ItemID.AncientGoldHelmet || head.type == ItemID.GoldHelmet && body.type == ItemID.GoldChainmail && legs.type == ItemID.GoldGreaves) 
			{
				return "GoldSet";
			}

			if (head.type == ItemID.PlatinumHelmet && body.type == ItemID.PlatinumChainmail && legs.type == ItemID.PlatinumGreaves) 
			{
				return "PlatinumSet";
			}
			
			// In case no if passes
			return "";
		}

		public override void UpdateArmorSet(Player player, string set)
		{
			if(set == "GoldSet" || set == "PlatinumSet") 
			{
				// If golden set is worn, add 10% melee damage.
				player.setBonus += "\nIncreases melee damage by 10%";
				player.GetDamage(DamageClass.Melee) += 0.1f;
			}
		}
	}
}