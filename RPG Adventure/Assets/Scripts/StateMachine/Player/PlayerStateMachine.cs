using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [SerializeField] private float _horizontal;
    [field: SerializeField] public Rigidbody2D rigidBody { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 12f;
    private void Start()
    {
        
        SwitchState(new PlayerIdleState(this));
    }

    public float xInput()
    {
        return _horizontal = Input.GetAxisRaw("Horizontal");
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rigidBody.velocity = new Vector2(xVelocity, yVelocity);
    }
    
    
}
