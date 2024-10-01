using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : NpcBaseState
{

    public override void EnterState(NpcController npcController)
    {
        npcController.navMeshAgent.isStopped = true;
    }
    public override void UpdateState(NpcController npcController)
    {

    }
}
