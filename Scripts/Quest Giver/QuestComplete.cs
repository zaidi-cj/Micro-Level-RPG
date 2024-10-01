using UnityEngine;

public class QuestComplete : QuestBaseState
{
    public override void EnterState(QuestManager questManager)
    {
        questManager.questImage.sprite = questManager.questCompleteImg;
        questManager.questChecked = false;

    }
    public override void UpdateState(QuestManager questManager)
    {
        questManager.CheckClick();
        if (questManager.questChecked)
        {
            questManager.SwitchState(questManager.noQuest);
        }
    }
}
