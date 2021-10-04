using Bindito.Core;

namespace BeaversDestiny
{
    public class PopulationUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<GoalPanel>().AsSingleton();
        }
    }

}