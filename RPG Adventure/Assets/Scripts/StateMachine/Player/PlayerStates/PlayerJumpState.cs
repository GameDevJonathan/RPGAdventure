using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    Rigidbody2D rb;
    float jumpforce;
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.rb = stateMachine.rigidBody;
        this.jumpforce = stateMachine.jumpForce;
    }

    public override void Enter()
    {
        Debug.Log("entering state jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpforce );
        stateMachine.Animator.Play("JumpFall");
        
    }
    public override void Tick(float deltaTime)
    {
        stateMachine.Animator.SetFloat("yVelocity", rb.velocity.y);
        if (rb.velocity.y < 0)
        {
            stateMachine.SwitchState(new PlayerAirState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        
    }

}
