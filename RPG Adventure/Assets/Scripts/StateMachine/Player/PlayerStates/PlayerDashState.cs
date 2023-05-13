using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    Rigidbody2D rb;
    float gravity;
    public PlayerDashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.rb = stateMachine.rigidBody;
        this.gravity = rb.gravityScale;
    }

    public override void Enter()
    {
        Debug.Log("Entered Dash State");
        stateMachine.Animator.Play("Dash");
        stateMachine.dashTimer = stateMachine.dashduration;
        rb.gravityScale = 0;

    }
    public override void Tick(float deltaTime)
    {
        stateMachine.dashTimer -= Time.deltaTime;
        //SetVelocity(stateMachine.dashSpeed * stateMachine.getDashDirection(), rb.velocity.y);
        SetVelocity(stateMachine.dashSpeed * stateMachine.getDashDirection(), 0);

        if (stateMachine.dashTimer < 0)
        {
            if (IsGroundDectected())
                stateMachine.SwitchState(new PlayerIdleState(stateMachine));
            else
                stateMachine.SwitchState(new PlayerAirState(stateMachine));
        }

    }

    public override void Exit()
    {
        SetVelocity(0, 0);
        rb.gravityScale = gravity;
        Debug.Log("Leaving Dash State");
    }

}
