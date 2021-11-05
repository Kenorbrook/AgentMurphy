using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    protected EnemyController bot;
    public AIState(EnemyController controller)
    {
        bot = controller;
        OnStateEnter();
    }
    public abstract void OnStateEnter();
    public virtual void OnStateExit(AIState newState)
    {
        bot.SetState(newState);
    }

    public abstract void StateUpdate();

    public abstract void HandleTurnPointEnter();
}
