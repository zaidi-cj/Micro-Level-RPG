using UnityEngine;

public class NormalState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
       // playerStateManager.playerAnim.SetLayerWeight(1, 0);
    }
    public override void UpdateState(PlayerStateManager playerStateManager)
    {
        playerStateManager.playerAnim.SetLayerWeight(1, Mathf.Lerp(playerStateManager.playerAnim.GetLayerWeight(1), 0f, Time.deltaTime * 4f));
        if (playerStateManager.playerInjured)
        {
            playerStateManager.SwitchState(playerStateManager.injuredState);
        }
    }
    public override void ExitState(PlayerStateManager playerStateManager)
    {

    }
}
