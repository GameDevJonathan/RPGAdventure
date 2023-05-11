using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public Rigidbody2D rigidBody { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; } = 12f;
    [field: SerializeField] public float jumpForce { get; private set; } = 15;
    private void Start()
    {

        SwitchState(new PlayerIdleState(this));
    }


    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rigidBody.velocity = new Vector2(xVelocity, yVelocity);
    }




}
