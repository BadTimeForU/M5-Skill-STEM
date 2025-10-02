using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBlock : MonoBehaviour
{
    [SerializeField] Transform Block;
    [SerializeField] Vector3 accelerationBegin;
    [SerializeField] Vector3 velocityBegin;

    Vector3 velocity;
    Vector3 acceleration;
    [SerializeField] float t = 0;

    float yMin;

    enum State { onGround, airBorne };
    State myState = State.onGround;

    void Start()
    {
        velocity = velocityBegin;
        acceleration = accelerationBegin;
        yMin = Block.position.y;
    }


    void Update()
    {
        if (myState == State.onGround)
        {

            velocity = Vector3.zero;
            acceleration = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState = State.airBorne;
                t = 0;
                velocity = velocityBegin;
                acceleration = accelerationBegin;
            }
        }
        ;

        if (myState == State.airBorne)
        {
            t += Time.deltaTime;
            if (Block.position.y < yMin)
            {
                myState = State.onGround;
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
            }

        }
        ;

        velocity += acceleration * Time.deltaTime;
        Block.position += velocity * Time.deltaTime;
    }
}