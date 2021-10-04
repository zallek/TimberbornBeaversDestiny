using Timberborn.FactionSystem;
using Timberborn.FactionSystemGame;
using Timberborn.SingletonSystem;

namespace BeaversDestiny
{
    class FactionGoalService : ILoadableSingleton
    {
        private const string FolktailsFactionId = "Folktails";
        private const string IronTeethFactionId = "IronTeeth";

        private FactionService _factionService;
        private PopulationGoalService _populationGoalService;
        private IrrigationGoalService _irrigationGoalService;
        private PowerTributeGoalService _powerTributeGoalService;

        public IGoalService Goal1Service
        {
            get => _populationGoalService;
        }
        public IGoalService Goal2Service
        {
            get
            {
                return _factionService.Current.Id == IronTeethFactionId ? _powerTributeGoalService : _irrigationGoalService;
            }
        }

        public FactionGoalService(FactionService factionService, PopulationGoalService populationGoalService, IrrigationGoalService irrigationGoalService, PowerTributeGoalService powerTributeGoalService)
        {
            _factionService = factionService;
            _populationGoalService = populationGoalService;
            _irrigationGoalService = irrigationGoalService;
            _powerTributeGoalService = powerTributeGoalService;
        }

        public void Load()
        {

        }
    }
}