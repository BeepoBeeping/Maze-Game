
//player.cs is the Monobehaviour and owns the Unity components
//It passes control to the statemachine

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    StateMachine sm;

    //define the actions
    public InputAction moveAction;



    private void Start()
    {
        sm = new StateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        rb = GetComponent<Rigidbody>();

        sm.Init(sm.idleState); //this will be the first state to run 

        //initialise the actions
        moveAction = InputSystem.actions.FindAction("Move");

        
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
