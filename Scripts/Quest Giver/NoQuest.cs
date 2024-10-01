using UnityEngine;

public class NoQuest : QuestBaseState
{
  //  Color color;
    public override void EnterState(QuestManager questManager)
    {
        questManager.HideImage();
        questManager.questChecked = false;
    }
    public override void UpdateState(QuestManager questManager)
    {
        questManager.CheckClick();
        if (questManager.questChecked)
        {
            questManager.SwitchState(questManager.questAvailable);
        }
    }
}
