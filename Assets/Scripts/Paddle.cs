using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public bool isBot;
    public float speed;
    public Rigidbody2D rb;
    public GameObject ball;
    public AudioSource hit;
    public float rotationSpeed;
    public float aiDeadzone = 1f;

    private Quaternion targetRotation;
    private Vector3 startPosition;

    private float movement = 0f;
    private float moveSpeedMultiplier = 1f;

    void Start()
    {
        startPosition = transform.position;
    }

    public void BotPaddle(bool a)
    {
        if (a && !isPlayer1)
        {
            isBot = true;
        }
        else
        {
            isBot = false;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
            Move(movement);

            Vector2 movementDirection = new Vector2(0, movement);
            if (movementDirection != Vector2.zero)
            {
                if(movementDirection == new Vector2(0,1))
                {
                    targetRotation = Quaternion.Euler(0, 0, -5);
                }
                else
                {
                    targetRotation = Quaternion.Euler(0, 0, 5);
                }
            }
            else targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            if (isBot)
            {
                
                Vector2 ballPos = ball.transform.position;
                
                if(Mathf.Abs(ballPos.y - transform.position.y) > aiDeadzone)
                {
                    movement = ballPos.y > transform.position.y ? 1 : -1;
                }

                if(Random.value < 0.01f)
                {
                    moveSpeedMultiplier = Random.Range(0.7f, 1.2f);
                }

                Move(movement);
            }
            else
            {
                movement = Input.GetAxisRaw("Vertical2");
                Move(movement);
            }
            
            Vector2 movementDirection = new Vector2(0, movement);
            if (movementDirection != Vector2.zero)
            {
                if (movementDirection == new Vector2(0, 1))
                {
                    targetRotation = Quaternion.Euler(0, 0, 5);
                }
                else
                {
                    targetRotation = Quaternion.Euler(0, 0, -5);
                }
            }
            else targetRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Move(float movement)
    {
        Vector2 velo = rb.velocity;
        velo.y = speed * moveSpeedMultiplier * movement;
        rb.velocity = velo;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hit.pitch = Random.Range(0.5f, 1.0f);
            hit.Play();
            GameObject.Find("Main Camera").GetComponent<Shake>().ScreenShake(0.2f);
            //GameObject.Find("ball").GetComponent<Ball>().Boost(2f);
            if (rb.transform.localScale.y >= 0.6)
            {
                rb.transform.localScale -= new Vector3(0, 0.2f, 0);
            }
        }
    }

    public void Reset()
    {
        rb.transform.localScale = new Vector3(0.5f, 3f, 1);
    }

}
