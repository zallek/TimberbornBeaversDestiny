using Timberborn.MapIndexSystem;
using Timberborn.SoilMoistureSystem;
using System.Linq;

namespace BeaversDestiny
{
    struct MoistureGoal
    {
        public int moisturedSize;
        public int mapSize;
    }

    class GoalService
    {
        private MapIndexService _mapIndexService;
        private ISoilMoistureService _soilMoistureService;

        public MoistureGoal GetMoistureGoal()
        {
            return new MoistureGoal
            {
                moisturedSize = Enumerable.Range(0, _mapIndexService.TotalMapSize).Count(index => _soilMoistureService.SoilMoisture(index) > 0),
                mapSize = _mapIndexService.TotalMapSize,
            };
        }

        public float GetMoistureGoalPct()
        {
            MoistureGoal moistureGoal = GetMoistureGoal();
            return moistureGoal.moisturedSize / moistureGoal.mapSize;
        }
    }
}