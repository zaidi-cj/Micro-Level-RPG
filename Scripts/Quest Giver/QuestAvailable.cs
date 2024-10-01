using UnityEngine;

public class QuestAvailable : QuestBaseState
{
    public override void EnterState(QuestManager questManager)
    {
        questManager.questImage.sprite = questManager.questAvailableImg;
        questManager.ShowImage();
        questManager.questChecked = false;

    }
    public override void UpdateState(QuestManager questManager)
    {
        questManager.CheckClick();
        if (questManager.questChecked)
        {
            questManager.SwitchState(questManager.questGive);
        }
    }
}
