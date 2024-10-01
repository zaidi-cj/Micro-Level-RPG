using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : NpcBaseState
{
    public override void EnterState(NpcController npcController)
    {
        npcController.targetPos = npcController.transform.position;
        npcController.MoveNPC();
        npcController.InvokeRepeating("Shoot", 0, 1);


    }
    public override void UpdateState(NpcController npcController)
    {
        npcController.transform.LookAt(npcController.player);
        npcController.CheckPlayerDistance();
        if (npcController.distance > 10) 
        { 
            npcController.SwitchState(npcController.idleState);
            npcController.CancelInvoke();
        }

        npcController.AnimationCheck();
        if (npcController.npcDead)
        {
            npcController.SwitchState(npcController.deathState);
            npcController.CancelInvoke();
        }
    }

}
