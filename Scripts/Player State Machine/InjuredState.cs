using UnityEngine;

public class InjuredState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {

    }
    public override void UpdateState(PlayerStateManager playerStateManager)
    {
        playerStateManager.playerAnim.SetLayerWeight(1, Mathf.Lerp(playerStateManager.playerAnim.GetLayerWeight(1), 1f, Time.deltaTime * 5f));
        if (!playerStateManager.playerInjured) 
        { 
            playerStateManager.SwitchState(playerStateManager.normalState);
        }
        if (playerStateManager.playerDead)
        {
            playerStateManager.SwitchState(playerStateManager.deadState);
        }
    }
    public override void ExitState(PlayerStateManager playerStateManager) 
    { 

    }
}
