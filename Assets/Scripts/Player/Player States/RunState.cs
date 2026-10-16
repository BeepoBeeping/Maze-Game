
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;
    protected Vector3 vel;
    protected float magnitude;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 1.5f;
        base.Enter();
        xvel = 0.0f;

        Debug.Log("entering running state");

    }

    public override void Exit()
    {
        Debug.Log("exiting running state");
        base.Exit();
    }



    public override void Update()
    {


        

        ReadInput();

        Vector3 vel;

        //magnitude = the player's speed
        float magnitude = player.rb.linearVelocity.magnitude;


        if (player.moveAction.IsPressed())
        {
            vel = player.transform.forward * 5f;
        }
        else
        {
            vel = player.transform.forward * 0f;
        }


        player.rb.linearVelocity = new Vector3(vel.x, player.rb.linearVelocity.y, vel.z);

        if (magnitude <= 0.5f)
        {
            sm.ChangeState(sm.idleState);
        }




        //debug move gameObject



        UIscript.ui.DrawText("This is the running state.");



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }
    public override void OnTriggerExit(Collider collision)
    {

    }



    public override void FixedUpdate()
    {

    }
}
