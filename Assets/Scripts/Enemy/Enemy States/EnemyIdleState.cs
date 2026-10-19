
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using System.Collections;

public class EnemyIdleState : EnemyState
{
    // constructor
    public EnemyIdleState( EnemyScript enemy, EnemyStateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        // this method is called when the state begins
        Debug.Log("entering idle state");
    }

    public override void Exit()
    {
        // this method is called when the state has finished
        Debug.Log("exiting idle state");
        //you should disable any running coroutines here
        enemy.StopAllCoroutines();
    }


    public override void Update()
    {
        if(Vector3.Distance(enemy.player.transform.position, enemy.transform.position) <= enemy.susRange)
        {
            sm.ChangeState(sm.patrolState);
        }



        //example of running a coroutine from a state and not directly from the monobehaviour


        EnemyUIscript.ui.DrawText("ENEMY: This is the idle state.");



    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
    }


    public IEnumerator IdleCo()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 1");

            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine step 2");

            Debug.Log("Coroutine repeat " + (i+1));

        }
        yield break;
    }




}
