using Timberborn.GameUI;
using UnityEngine.UIElements;

namespace BeaversDestiny
{
    class GoalPanel
    {
        private GameLayout _gameLayout;
        private GoalService _goalService;
        private Label _percentageLabel;

        public GoalPanel(GameLayout gameLayout, GoalService goalService)
        {
            _gameLayout = gameLayout;
            _goalService = goalService;
        }

        public void PostLoad()
        {
            VisualElement root = new VisualElement();

            Label label = new Label("Goal: Irrigate the map");
            root.Add(label);

            Label _percentageLabel = new Label();
            UpdateGoalPercentage();
            root.Add(_percentageLabel);

            _gameLayout.AddTopLeft(root, 5);
        }

        private void UpdateGoalPercentage()
        {
            _percentageLabel.text = $"{_goalService.GetMoistureGoalPct().ToString("F0")}%";
        }
    }
}