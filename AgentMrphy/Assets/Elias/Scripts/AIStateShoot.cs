using UnityEngine;
using System.Collections;

public class AIStateShoot : AIState
{
    public AIStateShoot(EnemyController controller) : base(controller) { }


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
        if(bot.IfPlayerVisible()== false)
        {
            OnStateExit(new AIStateIdle(bot));
        }
        if (bot.IfPlayerInShootRange() == false)
        {
            OnStateExit(new AIStatePersuit(bot));
            return;
        }

        //bot.HandleShootInput();
    }

    public override void HandleTurnPointEnter()
    {
        return;
    }
}
