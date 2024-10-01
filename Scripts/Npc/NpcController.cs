using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    NpcBaseState currentState;

    public IdleState idleState = new IdleState();
    public PatrolState patrolState = new PatrolState();
    public AttackState attackState = new AttackState();
    public DeathState deathState = new DeathState();
    public PlayerFollowState followState = new PlayerFollowState();
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public Vector3 randomPosition;
    public Vector3 targetPos;
    public string npcName;
    public float distance;
    HealthSystem healthSystem;
    public bool npcDead;
    // public float speed = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        healthSystem = GetComponent<HealthSystem>();
    }
    void Start()
    {

        currentState = idleState;
        currentState.EnterState(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetNpcName();
        
    }
    private void OnEnable()
    {
        healthSystem.playerDead += PlayerDead;

    }
    private void OnDisable()
    {
        healthSystem.playerDead -= PlayerDead; 
    }
    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

    }
    
    public void SwitchState(NpcBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void CheckPlayerDistance()
    {
         distance = Vector3.Distance(player.position, transform.position);
    }
    public void GetNpcName() 
    {
        npcName = gameObject.name;
    }
    public void MoveNPC()
    {
        navMeshAgent.SetDestination(targetPos);
    }
    public void Shoot()
    {
        Vector3 aimDir = (player.position - transform.position).normalized;

        GameObject bullet = ObjectPool.instance.GetPooledObjectOne();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPos.position;
            bullet.transform.rotation = Quaternion.LookRotation(aimDir, Vector3.up);
            bullet.SetActive(true);

        }
       // Instantiate(bullet, bulletSpawnPos.position, Quaternion.LookRotation(aimdir,Vector3.up));
    }
    public void RandomPosition()
    {
        randomPosition = transform.position +new Vector3(Random.Range(-15f,15f),0,Random.Range(-15,15)) ;
    }
    private void OnFootstep()
    {
        //
    }
    void PlayerDead()
    {
        npcDead = true;
    }
    public void AnimationCheck()
    {
        if (navMeshAgent.velocity.sqrMagnitude > 0.1f)
        {
            animator.SetBool("walking", true); // Keep walking if moving
        }
        else
        {
            animator.SetBool("walking", false); // Set to idle if not moving
        }
    }
}
