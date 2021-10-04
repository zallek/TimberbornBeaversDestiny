using Timberborn.MapIndexSystem;
using Timberborn.SingletonSystem;
using Timberborn.SoilMoistureSystem;
using System.Linq;

namespace BeaversDestiny
{
    public struct Goal
    {
        public int current;
        public int target;
    }

    public interface IGoalService
    {
        string GoalLabel { get; }
        Goal GetGoal();
    }

    class PopulationGoalService : ILoadableSingleton, IGoalService
    {
        public string GoalLabel => "Population";
        public void Load() { }
        public Goal GetGoal()
        {
            return new Goal
            {
                current = 0,
                target = 100,
            };
        }
    }

    class IrrigationGoalService : ILoadableSingleton, IGoalService
    {
        private MapIndexService _mapIndexService;
        private ISoilMoistureService _soilMoistureService;
        public string GoalLabel => "Irrigate the world";
        public IrrigationGoalService(MapIndexService mapIndexService, ISoilMoistureService soilMoistureService)
        {
            _mapIndexService = mapIndexService;
            _soilMoistureService = soilMoistureService;
        }
        public void Load() { }
        public Goal GetGoal()
        {
            return new Goal
            {
                current = Enumerable.Range(0, _mapIndexService.TotalMapSize).Count(index => _soilMoistureService.SoilMoisture(index) > 0),
                target = _mapIndexService.TotalMapSize,
            };
        }
    }

    class PowerTributeGoalService : ILoadableSingleton, IGoalService
    {
        public string GoalLabel => "Power the tribute to Ingenuity";
        public void Load() { }
        public Goal GetGoal()
        {
            return new Goal
            {
                current = 0,
                target = 100,
            };
        }
    }
}