using UnityEngine;

public class QuestGive : QuestBaseState
{
    public override void EnterState(QuestManager questManager)
    {
        questManager.questImage.sprite = questManager.questGiveImg;
        questManager.questChecked = false;

    }
    public override void UpdateState(QuestManager questManager)
    {
        questManager.CheckClick();
        if (questManager.questChecked)
        {
            questManager.SwitchState(questManager.questComplete);
        }
    }
}
