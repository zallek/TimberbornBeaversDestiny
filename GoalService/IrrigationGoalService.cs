using Timberborn.MapIndexSystem;
using Timberborn.SingletonSystem;
using Timberborn.SoilMoistureSystem;
using System;
using System.Linq;

namespace BeaversDestiny
{
    class IrrigationGoalService : ILoadableSingleton, IGoalService
    {
        private enum Stage
        {
            Stage1,
            Stage2,
            Stage3,
        }

        private Stage _currentStage = Stage.Stage1;
        private MapIndexService _mapIndexService;
        private ISoilMoistureService _soilMoistureService;

        public IrrigationGoalService(MapIndexService mapIndexService, ISoilMoistureService soilMoistureService)
        {
            _mapIndexService = mapIndexService;
            _soilMoistureService = soilMoistureService;
        }

        public void Load() { }

        private int GetTarget(Stage stage)
        {
            int totalMapSize = _mapIndexService.TotalMapSize;
            int targetPct = stage switch
            {
                Stage.Stage1 => 40,
                Stage.Stage2 => 70,
                _ => 100,
            };

            return targetPct * totalMapSize / 100;
        }

        public Goal GetGoal()
        {
            int totalMapSize = _mapIndexService.TotalMapSize;

            return new Goal
            {
                current = Enumerable.Range(0, totalMapSize).Count(index => _soilMoistureService.SoilMoisture(index) > 0),
                target = GetTarget(_currentStage),
            };
        }
    }
}