using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    private float moveSpeed = 2f;
    [SerializeField] private float waitTime;
    [SerializeField] private float moveTime;
    private float timer = 0f;
    private enum State { Moving, Waiting}
    private State state;
    // Start is called before the first frame update
    private void Start()
    {
        direction = direction.normalized;
        state=State.Moving;
        timer = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if(state==State.Moving)
        {
            if(timer>=moveTime)
            {
                state= State.Waiting;
                direction *= -1;
                timer = 0f;
            }
            else
            {
                transform.Translate(direction*moveSpeed*Time.deltaTime);
            }
        }
        else
        {
            if(timer >= waitTime)
            {
                state = State.Moving;
                timer = 0f;
            }
        }
    }
}
