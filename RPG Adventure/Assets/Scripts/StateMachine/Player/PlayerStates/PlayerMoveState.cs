using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    float moveSpeed;
    Rigidbody2D rb;
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.moveSpeed = stateMachine.moveSpeed;
        this.rb = stateMachine.rigidBody;
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


        SetVelocity(_xInput * moveSpeed, rb.velocity.y);

        if (_xInput == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGroundDectected())
        {
            Debug.Log("button pressed");
            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
            return;
        }

        if (_dashButton)
        {
            stateMachine.SwitchState(new PlayerDashState(stateMachine));
        }

        if (!IsGroundDectected())
        {
            stateMachine.SwitchState(new PlayerAirState(stateMachine));
            return;
        }
    }
}
