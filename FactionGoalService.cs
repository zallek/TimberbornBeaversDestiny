using Timberborn.SingletonSystem;

namespace BeaversDestiny
{
    class FactionGoalService : ILoadableSingleton
    {
        public IGoalService goal1Service;
        public IGoalService goal2Service;

        public FactionGoalService(PopulationGoalService populationGoalService, IrrigationGoalService irrigationGoalService)
        {
            goal1Service = populationGoalService;
            goal2Service = irrigationGoalService;
        }

        public void Load()
        {
        }
    }
}