using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace EarlyClasses.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagicalGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;

			Item.value = Item.buyPrice(gold: 2);
			Item.rare = ItemRarityID.Green;

			Item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			// Increases max mana by 20
			player.statManaMax2 += 20;
		}

		public override void AddRecipes()
		{
			// Recipe with gold
			CreateRecipe() 
				.AddIngredient(ItemID.GoldBar, 6)
				.AddIngredient(ItemID.Silk, 5)
				.AddIngredient(ItemID.ManaCrystal, 1)
				.AddTile(TileID.Anvils)
				.Register();

			// Same but with platinum
			CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 6)
				.AddIngredient(ItemID.Silk, 5)
				.AddIngredient(ItemID.ManaCrystal, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
