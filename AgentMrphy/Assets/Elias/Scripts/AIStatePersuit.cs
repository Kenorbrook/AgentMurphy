using UnityEngine;
using System.Collections;

public class AIStatePersuit : AIState
{
    public AIStatePersuit(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
        Debug.Log("PersuitState");

    }

    public override void OnStateExit(AIState newState)
    {
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
        bot.Run();
        if (bot.CouldShoot)
        {
            //Debug.Log("AIStatePersuit: ShootCheck");
            if (bot.IfTargetInShootRange())
            {
                Debug.Log("AIStatePersuit: PlayerInShootRange");
                OnStateExit(new AIStateShoot(bot));
                return;
            }
        }

        if (bot.IfPlayerVisible() == false)
        {
            OnStateExit(new AIStateIdle(bot));
            return;
        }
    }

    public override void HandleTurnPointEnter()
    {
        OnStateExit(new AIStateIdle(bot));
    }
}
