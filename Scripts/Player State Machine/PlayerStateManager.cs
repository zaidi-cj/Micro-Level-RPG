using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour
{
    HealthSystem healthSystem;
    PlayerBaseState currentState;
    public NormalState normalState = new NormalState();
    public InjuredState injuredState = new InjuredState();
    public DeadState deadState = new DeadState();
    public bool playerInjured;
    public bool playerDead;
    public Animator playerAnim;
    public Canvas playerCanvas;
    public Material deathMaterial;
    public SkinnedMeshRenderer SkinnedMeshRenderer;
   // private Material[] materials;
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        playerAnim = GetComponent<Animator>();
        playerCanvas = GetComponentInChildren<Canvas>();
        SkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    private void OnEnable()
    {
        healthSystem.playerInjured += PlayerInjured;
        healthSystem.playerNormal += PlayerNormal;
        healthSystem.playerDead += PlayerDead;
    }
    private void OnDisable()
    {
        healthSystem.playerInjured -= PlayerInjured;
        healthSystem.playerNormal -= PlayerNormal;
        healthSystem.playerDead -= PlayerDead;
    }
    void PlayerInjured()
    {
        playerInjured = true;
    }
    void PlayerNormal()
    {
        playerInjured = false;
    }
    void PlayerDead()
    {
        playerDead = true;
    }

    private void Start()
    {
        currentState = normalState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
        
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
