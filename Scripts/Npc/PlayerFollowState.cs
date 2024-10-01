using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowState : NpcBaseState
{
    public override void EnterState(NpcController npcController)
    {
        npcController.animator.SetBool("walking", true); // Keep walking if moving
    }
    public override void UpdateState(NpcController npcController)
    {
        npcController.targetPos = npcController.player.transform.position;
        npcController.CheckPlayerDistance();

        if (npcController.distance > 4)
        {
            npcController.MoveNPC();
        }
        else 
        {
            npcController.SwitchState(npcController.idleState);
        }
        if (npcController.npcDead)
        {
            npcController.SwitchState(npcController.deathState);
        }
    }
}
