using UnityEngine;

public abstract class NpcBaseState 
{
    public abstract void EnterState(NpcController npcController);
    public abstract void UpdateState(NpcController npcController);
}
