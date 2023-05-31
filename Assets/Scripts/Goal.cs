using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;
    public GameObject ball;
    public GameObject particle;
    public AudioSource goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                // Player 1 scores
                GameObject.Find("Canvas").GetComponent<GameUI>().player1Scored();
                particle.transform.position = new Vector3(9,ball.transform.position.y,0);
                particle.transform.rotation = Quaternion.Euler(0, -90, 0);
                GoalFunct();
            }
            else
            {
                // Player 2 scores
                GameObject.Find("Canvas").GetComponent<GameUI>().player2Scored();
                particle.transform.position = new Vector3(-9, ball.transform.position.y, 0);
                particle.transform.rotation = Quaternion.Euler(0, 90, 0);
                GoalFunct();
            }
        }
    }

    private void GoalFunct()
    {
        GameObject.Find("Main Camera").GetComponent<Shake>().ScreenShake(2f);
        goal.pitch = Random.Range(0.5f, 1.0f);
        goal.Play();
    }
}
