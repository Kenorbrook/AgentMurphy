﻿using UnityEngine;
using System.Collections;

public class AIStateIdle : AIState
{
    WaitForSeconds waitTime;
    public AIStateIdle(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
        bot.StartWaiting();
        Debug.Log("IdleState");
    }

    public override void OnStateExit(AIState newState)
    {
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
 /*       if (bot.IfPlayerVisible())
        {
            Debug.Log("PlayerVisible");
            OnStateExit(new AIStatePersuit(bot));
            return;
        }*/
    }

    public override void HandleTurnPointEnter()
    {
        return;
    }

}
