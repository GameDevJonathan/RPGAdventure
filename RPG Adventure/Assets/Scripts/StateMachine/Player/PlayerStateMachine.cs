using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public Rigidbody2D rigidBody { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; } = 12f;
    [field: SerializeField] public float jumpForce { get; private set; } = 15;
    [field: SerializeField] public Transform groundCheck { get; private set; }
    [field: SerializeField] public float groundCheckDistance;
    [field: SerializeField] public Transform wallCheck { get; private set; }
    [field: SerializeField] public float wallCheckDistance;
    [field: SerializeField] public LayerMask whatIsGround;
    [field: SerializeField] public int facingDir = 1;
    [field: SerializeField] public bool facingRight = true;
    [field: SerializeField] public float stateTimer;
    [field: SerializeField] public float coolDown;


    private void Start()
    {

        SwitchState(new PlayerIdleState(this));
    }

    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        
        
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else
        if (_x < 0 && facingRight)
            Flip();
        
    }




    //public bool IsGroundDectected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (transform.right * wallCheckDistance));
        //Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

}
