using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenExampleMod.Customs
{
    public class ExampleDish : CustomDish
    {
        public override string UniqueNameID => "ExampleDish";
        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("ExampleDish", "This is an Example Dish", "Eww! Examples?"))
        };
        
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override List<string> StartingNameSet => new List<string> {
            "Example Me Up!",
            "Modding Workshop",
            "Wilk"
        };
        
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Milk),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.WineBottle)
        };
        
        public override GameObject IconPrefab => MaterialUtils.AssignMaterialsByNames(Mod.Bundle.LoadAsset<GameObject>("ExampleItemGroup"));
        public override GameObject DisplayPrefab => MaterialUtils.AssignMaterialsByNames(Mod.Bundle.LoadAsset<GameObject>("ExampleItemGroup"));
        
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<ExampleItemGroup>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override bool IsAvailableAsLobbyOption => true;
        
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine Wine and Milk.... mmm Wilk" }
        };

        public override bool RequiredNoDishItem => true;
    }
}