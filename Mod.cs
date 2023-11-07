using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using System.Linq;
using System.Reflection;
using KitchenExampleMod.Customs;
using UnityEngine;

namespace KitchenExampleMod
{
    public class Mod : BaseMod, IModSystem
    {
        public const string MOD_GUID = "com.exampleauthor.examplemod";
        public const string MOD_NAME = "ExampleMod";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "ExampleAuthor";
        public const string MOD_GAMEVERSION = ">=1.1.4";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
            Logger = InitLogger();

            AddGameDataObject<ExampleAppliance>();
            AddGameDataObject<ExampleItemGroup>();
            AddGameDataObject<ExampleDish>();
        }
    }
}

