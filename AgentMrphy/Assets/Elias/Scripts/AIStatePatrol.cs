using UnityEngine;
using System.Collections;

public class AIStatePatrol : AIState
{
    public AIStatePatrol(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
        Debug.Log("PatrolState");

    }

    public override void OnStateExit(AIState newState)
    {
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
        bot.Move();

        if (bot.IfPlayerVisible())
        {
            Debug.Log("StatePatrol: PlayerVisible");
            OnStateExit(new AIStatePersuit(bot));
            return;
        }

/*        if (Random.Range(0f, 1f) <= bot.IdleStateChance)
        {
            OnStateExit(new AIStateIdle(bot));
            return;
        }*/
    }

    public override void HandleTurnPointEnter()
    {
        OnStateExit(new AIStateIdle(bot));
        //bot.TurnArount();
    }
}
