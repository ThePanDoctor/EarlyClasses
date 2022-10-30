using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace EarlyClasses.Items
{
	public class FlinxFurGreaves : ModItem
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
		}

		public override void UpdateEquip(Player player)
		{
			// Increases move speed by 10%
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
		}
	}
}