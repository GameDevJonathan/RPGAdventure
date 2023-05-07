using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    float moveSpeed;
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.moveSpeed = stateMachine.moveSpeed;
    }

    public override void Enter()
    {
        Debug.Log("move state");
        stateMachine.Animator.Play("Move");
    }

    public override void Exit()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.SetVelocity(stateMachine.xInput() * moveSpeed, stateMachine.rigidBody.velocity.y) ;
        if (stateMachine.xInput() == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }

    }
}
