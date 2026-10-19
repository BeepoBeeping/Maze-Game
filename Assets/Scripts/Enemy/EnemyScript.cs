
//player.cs is the Monobehaviour and owns the Unity components
//It passes control to the statemachine

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    EnemyStateMachine sm;
    public GameObject player;
    public NavMeshAgent agent;
    public Animator animator;
    public Transform[] points;
    public NavMeshAgent nav;
    public float newDestinationCD = 0.5f;
    public float timePassed;
    public int destPoint;

    [Header("Enemy")]
    [SerializeField] public float attackCD = 3f;
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public float aggroRange = 4f;
    [SerializeField] public float susRange = 12f;

    //define the actions
    public InputAction moveAction;



    private void Start()
    {
        sm = new EnemyStateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        rb = GetComponent<Rigidbody>();

        sm.Init(sm.patrolState); //this will be the first state to run 

        //initialise the actions

        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


    }

    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();

        /*UIscript.ui.DrawText("Current state= " + sm.currentState + "  Last state= " + sm.lastState);*/

    }

    private void FixedUpdate()
    {
        //do not put any of your own methods here - they go in the state files
        sm.FixedUpdate();
    }

    //add your additional collision handling here
    void OnCollisionEnter(Collision collision)
    {
        sm.currentState.OnCollisionEnter(collision);
    }
    void OnTriggerEnter(Collider collision)
    {
        sm.currentState.OnTriggerEnter(collision);
    }
    void OnTriggerExit(Collider collision)
    {
        sm.currentState.OnTriggerExit(collision);
    }



}
