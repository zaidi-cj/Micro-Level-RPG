using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PatrolState : NpcBaseState
{
    float timer;

    public override void EnterState(NpcController npcController)
    {
        timer = 0;
        npcController.RandomPosition();
        npcController.targetPos = npcController.randomPosition;

        npcController.animator.SetBool("walking", true); // Keep walking if moving

    }
    public override void UpdateState(NpcController npcController)
    {
        timer += Time.deltaTime;
        npcController.CheckPlayerDistance();

        if (timer < 10)
        {
            npcController.MoveNPC();
        }
        if(npcController.navMeshAgent.remainingDistance <= 1)
        {
            npcController.SwitchState(npcController.idleState);

        }

        if (npcController.distance < 10)
        {

            npcController.SwitchState(npcController.attackState);
        }

        npcController.AnimationCheck();
        if (npcController.npcDead)
        {
            npcController.SwitchState(npcController.deathState);
        }
    }


}


