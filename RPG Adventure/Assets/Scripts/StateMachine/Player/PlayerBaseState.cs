using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected float _xInput => Input.GetAxisRaw("Horizontal");
    
    
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        stateMachine.rigidBody.velocity = new Vector2(xVelocity, yVelocity);
        stateMachine.FlipController(xVelocity);
    }

    //public void Flip()
    //{
    //    stateMachine.facingDir = stateMachine.facingDir * -1;
    //    stateMachine.facingRight = !stateMachine.facingRight;
    //    stateMachine.transform.Rotate(0, 180, 0);
    //} 

    //public void FlipController(float _x)
    //{
    //    if( _x > 0 && !stateMachine.facingRight)
    //    {
    //        Flip();
    //    }else if (_x < 0 && stateMachine.facingRight)
    //    {
    //        Flip();
    //    }
    //}

    public bool IsGroundDectected() => Physics2D.Raycast(stateMachine.groundCheck.position, Vector2.down, stateMachine.groundCheckDistance, stateMachine.whatIsGround);
    public bool IsWallDectected() => Physics2D.Raycast(stateMachine.wallCheck.position, Vector2.right, stateMachine.wallCheckDistance, stateMachine.whatIsGround);
}
