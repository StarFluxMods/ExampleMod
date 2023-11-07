using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenExampleMod.Customs
{
    public class ExampleItemGroup : CustomItemGroup
    {
        public override string UniqueNameID => "ExampleItemGroup";
        public override GameObject Prefab => MaterialUtils.AssignMaterialsByNames(Mod.Bundle.LoadAsset<GameObject>("ExampleItemGroup"));
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Milk),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.WineBottle)
                },
                Min = 2,
                Max = 2
            }
        };
    }
}