using Timberborn.GameUI;
using Timberborn.SingletonSystem;
using UnityEngine;
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

            VisualElement goal1 = createGoalVisualElement(out _goal1TargetLabel);
            root.Add(goal1);

            VisualElement goal2 = createGoalVisualElement(out _goal2TargetLabel);
            root.Add(goal2);

            UpdateGoalsTarget();
            _gameLayout.AddTopLeft(root, 5);
        }

        private VisualElement createGoalVisualElement(out Label targetLabel)
        {
            VisualElement root = new VisualElement();
            root.style.color = Color.white;

            Label objectiveLabel = new Label("Goal");
            root.Add(objectiveLabel);
            targetLabel = new Label();
            root.Add(targetLabel);
            return root;
        }

        private void UpdateGoalsTarget()
        {
            var goal1 = _factionGoalService.Goal1Service.GetGoal();
            _goal1TargetLabel.text = $"{goal1.current}/{goal1.target}";

            var goal2 = _factionGoalService.Goal2Service.GetGoal();
            _goal2TargetLabel.text = $"{goal2.current}/{goal2.target}";
        }
    }
}