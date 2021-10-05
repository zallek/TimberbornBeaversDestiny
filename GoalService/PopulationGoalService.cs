using Timberborn.MapIndexSystem;
using Timberborn.Population;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace BeaversDestiny
{
    class PopulationGoalService : ILoadableSingleton, IGoalService
    {
        private enum Stage
        {
            Stage1,
            Stage2,
            Stage3,
        }

        private Stage _currentStage = Stage.Stage1;
        private MapIndexService _mapIndexService;
        private PopulationService _populationService;

        public PopulationGoalService(MapIndexService mapIndexService, PopulationService populationService)
        {
            _mapIndexService = mapIndexService;
            _populationService = populationService;
        }

        public void Load() { }

        private int GetTarget(Stage stage)
        {
            Vector3 mapSize = _mapIndexService.MapSize;
            float goalFactor = stage switch
            {
                Stage.Stage1 => Config.PopulationGoalStage1Factor,
                Stage.Stage2 => Config.PopulationGoalStage2Factor,
                _ => Config.PopulationGoalStage3Factor,
            };
            int ceillingFactor = stage == Stage.Stage1 ? 1 : MathExtensions.NumberOfDigits(GetTarget(Stage.Stage1));

            return MathExtensions.Ceiling(mapSize.x * mapSize.y * goalFactor, ceillingFactor);
        }

        public Goal GetGoal()
        {
            return new Goal
            {
                label = "Increase population",
                current = _populationService.GlobalPopulationData.NumberOfBeavers,
                target = GetTarget(_currentStage),
            };
        }
    }
}