
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.VersionControl.Asset;

public class ChaseState : EnemyState
{



    protected float speed;
    protected float rotationSpeed;
    protected Vector3 vel;
    protected float magnitude;

    public ChaseState(EnemyScript enemy, EnemyStateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        speed = 1.5f;
        base.Enter();
        xvel = 0.0f;

        Debug.Log("entering chase state");

    }

    public override void Exit()
    {
        Debug.Log("exiting chase state");
        base.Exit();
    }



    public override void Update()
    {

        enemy.animator.SetFloat("speed", enemy.agent.velocity.magnitude / enemy.agent.speed);

        if (enemy.timePassed >= enemy.attackCD)
        {
            if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) <= enemy.attackRange)
            {

                SceneManager.LoadScene("GameOver");
                enemy.timePassed = 0;
            }
        }
        enemy.timePassed += Time.deltaTime;

        if (enemy.newDestinationCD <= 0 && Vector3.Distance(enemy.player.transform.position, enemy.transform.position) <= enemy.aggroRange)
        {
            enemy.newDestinationCD = 0f;
            enemy.agent.SetDestination(enemy.player.transform.position);
        }
        enemy.newDestinationCD -= Time.deltaTime;
        enemy.transform.LookAt(enemy.player.transform);



        if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) >= enemy.aggroRange)
        {
            sm.ChangeState(sm.patrolState);
        }





        //debug move gameObject



        EnemyUIscript.ui.DrawText("ENEMY: This is the chase state.");



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
