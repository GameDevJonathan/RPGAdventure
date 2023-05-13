using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float _xInput => Input.GetAxisRaw("Horizontal");
    protected bool _dashButton => Input.GetKeyDown(KeyCode.LeftShift);
    
    
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        stateMachine.rigidBody.velocity = new Vector2(xVelocity, yVelocity);
        stateMachine.FlipController(xVelocity);
    }
    public bool IsGroundDectected() => Physics2D.Raycast(stateMachine.groundCheck.position, Vector2.down, stateMachine.groundCheckDistance, stateMachine.whatIsGround);
    public bool IsWallDectected() => Physics2D.Raycast(stateMachine.wallCheck.position, Vector2.right, stateMachine.wallCheckDistance, stateMachine.whatIsGround);
}
