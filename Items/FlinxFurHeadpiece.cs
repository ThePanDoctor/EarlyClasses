using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace EarlyClasses.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class FlinxFurHeadpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;

			Item.value = Item.buyPrice(gold: 2);
			Item.rare = ItemRarityID.Green;

			Item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			// Increase whip speed by 5%
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.05f;
		}

		public override void AddRecipes()
		{
			// Recipe with gold
			CreateRecipe() 
				.AddIngredient(ItemID.GoldBar, 3)
				.AddIngredient(ItemID.Silk, 2)
				.AddIngredient(ItemID.FlinxFur, 1)
				.AddTile(TileID.Anvils)
				.Register();

			// Same but with platinum
			CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 3)
				.AddIngredient(ItemID.Silk, 2)
				.AddIngredient(ItemID.FlinxFur, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}