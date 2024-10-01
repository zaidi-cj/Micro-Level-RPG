using UnityEngine;

public class IdleState : NpcBaseState
{
    float timer;
    public override void EnterState(NpcController npcController)
    {
        timer = 0f;
        npcController.animator.SetBool("walking", false);
        if(npcController.npcName == "Ally")
        {
            npcController.targetPos = npcController.transform.position;
            npcController.MoveNPC();
        }
    }
    public override void UpdateState(NpcController npcController)
    {
        timer += Time.deltaTime;
        npcController.CheckPlayerDistance();

        if (npcController.npcName == "Ally" && npcController.distance > 4)
        {
            npcController.SwitchState(npcController.followState);
        }
        if (npcController.npcName == "Enemy")
        {
            if (npcController.distance < 10)
            {
                npcController.SwitchState(npcController.attackState);
            }
            if (timer > 4)
            {
                npcController.SwitchState(npcController.patrolState);

            }
            npcController.AnimationCheck();
        }
        if (npcController.npcDead)
        {
            npcController.SwitchState(npcController.deathState);
        }

    }

}
        // Check if agent is moving, and update animations
/*        if(npcController.npcName != "Quest Giver")
        {

        }*/

