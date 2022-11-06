using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EarlyClasses.Items;

namespace EarlyClasses.Global
{
	public class GlobalItemList : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.FlinxFurCoat)
			{
				item.defense = 3; // Changes Flinx fur coat from 1 defense to 3
			}
		}

		public override void AddRecipes() 
		{
			Recipe.Create(ItemID.FlinxFurCoat, 1)
			.AddIngredient(ItemID.GoldBar, 8)
			.AddIngredient(ItemID.FlinxFur, 3)
			.AddIngredient(ItemID.Silk, 5)
			.AddTile(TileID.Anvils)
			.Register();
			// Adds cheaper recipes to the Flinx Fur Coat
			// Above uses gold, below uses platinum
			Recipe.Create(ItemID.FlinxFurCoat, 1)
			.AddIngredient(ItemID.PlatinumBar, 8)
			.AddIngredient(ItemID.FlinxFur, 3)
			.AddIngredient(ItemID.Silk, 5)
			.AddTile(TileID.Anvils)
			.Register();
		}

		// Tests if an armor set is being used
		public override string IsArmorSet(Item head, Item body, Item legs) 
		{
			// Checking for gold armor pieces
			if (head.type == ItemID.AncientGoldHelmet || head.type == ItemID.GoldHelmet && body.type == ItemID.GoldChainmail && legs.type == ItemID.GoldGreaves) 
			{
				return "GoldSet";
			}
			
			// Checking for platinum armor pieces
			if (head.type == ItemID.PlatinumHelmet && body.type == ItemID.PlatinumChainmail && legs.type == ItemID.PlatinumGreaves) 
			{
				return "PlatinumSet";
			}

			if (head.type == ModContent.ItemType<FlinxFurHeadpiece>() && body.type == ItemID.FlinxFurCoat && legs.type == ModContent.ItemType<FlinxFurGreaves>())
			{
				return "FlinxSet";
			}
			
			// In case no if passes
			return "";
		}

		public override void UpdateArmorSet(Player player, string set)
		{
			if(set == "GoldSet" || set == "PlatinumSet") 
			{
				// If golden or platinum set is worn, add 15% melee damage.
				player.setBonus += "\nIncreases melee damage by 15%";
				player.GetDamage(DamageClass.Melee) += 0.15f;
			}

			if (set == "FlinxSet")
			{
				// If the full set is worn, get immunity to chilled and frozen, and gain 10% whip speed
				player.setBonus = "Increases whip speed by 10%\nGrants immunity to Frozen and Chilled";
				
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frozen] = true;

				player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.1f;
			}
		}
	}
}