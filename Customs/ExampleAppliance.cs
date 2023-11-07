using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenExampleMod.Customs
{
    public class ExampleAppliance : CustomAppliance
    {
        public override string UniqueNameID => "ExampleAppliance";
        public override GameObject Prefab => MaterialUtils.AssignMaterialsByNames(Mod.Bundle.LoadAsset<GameObject>("ExampleAppliance"));
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemHolder(),
            new CNoBadProcesses()
        };

        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>
        {
            new Appliance.ApplianceProcesses
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Speed = 2.5f,
                IsAutomatic = true,
                Validity = ProcessValidity.Generic
            }
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (
                Locale.English,
                LocalisationUtils.CreateApplianceInfo("Example Appliance", "This is an Example Appliance!", new List<Appliance.Section>(), new List<string>())
            )
        };

        public override void OnRegister(Appliance gameDataObject)
        {
            HoldPointContainer container = gameDataObject.Prefab.AddComponent<HoldPointContainer>();
            container.HoldPoint = GameObjectUtils.GetChildObject(gameDataObject.Prefab, "HoldPoint").transform;
        }
    }
}