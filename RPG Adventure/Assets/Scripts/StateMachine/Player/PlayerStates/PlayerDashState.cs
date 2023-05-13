using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.stateTimer = 1.5f;
        
    }
    public override void Tick(float deltaTime)
    {
        stateMachine.stateTimer -= Time.deltaTime;

        if(stateMachine.stateTimer < 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
        
    }

    public override void Exit()
    {
        
    }

}
