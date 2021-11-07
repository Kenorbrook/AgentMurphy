using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateCloseAttack : AIState
{
    public AiStateCloseAttack(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
        Debug.Log("ShootState");
    }

    public override void OnStateExit(AIState newState)
    {
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
        if (bot.IfPlayerVisible() == false)
        {
            OnStateExit(new AIStateIdle(bot));
        }
        if (bot.IfTargetInCloseRange() == false)
        {
            OnStateExit(new AIStatePersuit(bot));
            return;
        }

        bot.HandleShootInput();
    }

    public override void HandleTurnPointEnter()
    {
        return;
    }
}
