using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestBaseState
{
    public abstract void EnterState(QuestManager questManager);
    public abstract void UpdateState(QuestManager questManager);
}
