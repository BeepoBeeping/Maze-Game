using UnityEngine;


//Handles initialisation of states, switching of states
//It handles calling Update and FixedUpdate for the currently active state

public class EnemyStateMachine
{
    public EnemyState currentState, lastState;

    //declare all states here
    public EnemyIdleState enemyIdleState;
    public PatrolState patrolState;
    public ChaseState chaseState;




    //constructor
    public EnemyStateMachine( EnemyScript enemy )
    {
        //initialise all states here
        enemyIdleState = new EnemyIdleState(enemy, this);
        patrolState = new PatrolState(enemy, this);
        chaseState = new ChaseState(enemy, this);

    }

    public void Init(EnemyState startingState)
    {
        currentState = startingState;
        lastState = null;
        startingState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.Exit();

        lastState = currentState;
        currentState = newState;
        newState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}
