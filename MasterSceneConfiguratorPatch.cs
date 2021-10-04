using Bindito.Core;
using HarmonyLib;
using Timberborn.MasterScene;

namespace BeaversDestiny
{
    class MasterSceneConfiguratorPatch
    {
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        public static class ConfigurePatch
        {
            private static void Postfix(IContainerDefinition containerDefinition)
            {
                containerDefinition.Bind<PowerTributeGoalService>().AsSingleton();
                containerDefinition.Bind<IrrigationGoalService>().AsSingleton();
                containerDefinition.Bind<PopulationGoalService>().AsSingleton();
                containerDefinition.Bind<FactionGoalService>().AsSingleton();
                containerDefinition.Bind<GoalPanel>().AsSingleton();
            }
        }
    }
}