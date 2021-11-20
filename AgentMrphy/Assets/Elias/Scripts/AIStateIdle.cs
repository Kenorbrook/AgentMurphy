using UnityEngine;
using System.Collections;

public class AIStateIdle : AIState
{
    WaitForSeconds waitTime;
    public AIStateIdle(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
        bot.StartWaiting();
    }

    public override void OnStateExit(AIState newState)
    {
        bot.TurnArount();
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
        if (bot.IfPlayerVisible())
        {
            OnStateExit(new AIStatePersuit(bot));
            return;
        }
    }

    public override void HandleTurnPointEnter()
    {
        return;
    }

}
