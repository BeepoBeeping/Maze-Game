
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEditor.VersionControl.Asset;


public class PatrolState : EnemyState
{
    protected float speed;
    protected float rotationSpeed;
    protected Vector3 vel;
    protected float magnitude;
    protected float giveUpTime;
    protected bool givenUp;
   

    public PatrolState(EnemyScript enemy, EnemyStateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering patrol state");
    }

    public override void Exit()
    {
        Debug.Log("exiting patrol state");
        base.Exit();
    }



    public override void Update()
    {
        if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) <= enemy.aggroRange)
        {            
            sm.ChangeState(sm.chaseState);
            Exit();
        }





        //debug move gameObject



        EnemyUIscript.ui.DrawText("ENEMY: This is the patrol state.");



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }
    public override void OnTriggerExit(Collider collision)
    {

    }



    public override void FixedUpdate()
    {
        if (!enemy.nav.pathPending && enemy.nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    public void GoToNextPoint()
    {

            if (enemy.points.Length == 0)
            {
                return;
            }
            enemy.nav.destination = enemy.points[enemy.destPoint].position;
            enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;    
    }
}
