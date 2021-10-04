using Timberborn.GameUI;
using Timberborn.SingletonSystem;
using UnityEngine.UIElements;

namespace BeaversDestiny
{
    class GoalPanel : IPostLoadableSingleton
    {
        private GameLayout _gameLayout;
        private FactionGoalService _factionGoalService;
        private Label _goal1TargetLabel;
        private Label _goal2TargetLabel;

        public GoalPanel(GameLayout gameLayout, FactionGoalService factionGoalService)
        {
            _gameLayout = gameLayout;
            _factionGoalService = factionGoalService;
        }

        public void PostLoad()
        {
            VisualElement root = new VisualElement();

            VisualElement goal1 = new VisualElement();
            Label goal1VerboseLabel = new Label("Goal 1");
            goal1.Add(goal1VerboseLabel);
            _goal1TargetLabel = new Label();
            goal1.Add(_goal1TargetLabel);
            root.Add(goal1);

            VisualElement goal2 = new VisualElement();
            Label goal2VerboseLabel = new Label("Goal 2");
            goal2.Add(goal2VerboseLabel);
            _goal2TargetLabel = new Label();
            goal2.Add(_goal2TargetLabel);
            root.Add(goal2);

            UpdateGoalsTarget();
            _gameLayout.AddTopLeft(root, 5);
        }

        private void UpdateGoalsTarget()
        {
            var goal1 = _factionGoalService.goal1Service.GetGoal();
            _goal1TargetLabel.text = $"{goal1.current}/{goal1.target}";

            var goal2 = _factionGoalService.goal2Service.GetGoal();
            _goal2TargetLabel.text = $"{goal2.current}/{goal2.target}";
        }
    }
}