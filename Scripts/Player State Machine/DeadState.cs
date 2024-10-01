using System;
using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadState : PlayerBaseState
{
    float timer;
    float dissolveValue;
    float deadTime = 9;
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        playerStateManager.StartCoroutine(Death(playerStateManager));

    }
    public override void UpdateState(PlayerStateManager playerStateManager)
    {
        timer += Time.deltaTime;
    }
    public override void ExitState(PlayerStateManager playerStateManager)
    {
       playerStateManager.gameObject.SetActive(false);
      
    }
  
    
    IEnumerator Death(PlayerStateManager playerStateManager)
    {
        playerStateManager.playerAnim.SetBool("IsDead", true);
        playerStateManager.playerCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        while (timer < deadTime)
        {

            if (playerStateManager.gameObject.tag == "Player")
            {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (playerStateManager.gameObject.tag == "Enemy")
            {
                Material[] materials = playerStateManager.SkinnedMeshRenderer.materials;
                materials[0] = playerStateManager.deathMaterial;
                materials[1] = playerStateManager.deathMaterial;
                materials[2] = playerStateManager.deathMaterial;
                playerStateManager.SkinnedMeshRenderer.materials = materials;
                dissolveValue = Mathf.Lerp(dissolveValue, 1, Time.deltaTime * 1.5f);
                playerStateManager.deathMaterial.SetFloat("_DissolveValue", dissolveValue);
            }
            yield return null;
        }
       // yield return new WaitForSeconds(5f);
        ExitState(playerStateManager);
    }


}
