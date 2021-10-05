using Timberborn.SingletonSystem;

namespace BeaversDestiny
{
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