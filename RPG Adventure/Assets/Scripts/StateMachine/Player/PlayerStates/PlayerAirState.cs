using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    Rigidbody2D rb;

    public PlayerAirState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.rb = stateMachine.rigidBody;

    }

    public override void Enter()
    {
        Debug.Log("entering state");
        stateMachine.Animator.Play("JumpFall");
    }
    public override void Tick(float deltaTime)
    {
        Debug.Log("velocity" + rb.velocity.y);
        stateMachine.Animator.SetFloat("yVelocity", rb.velocity.y);
        if (rb.velocity.y == 0)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting state");
    }

}
