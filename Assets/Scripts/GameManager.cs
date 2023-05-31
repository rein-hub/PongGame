using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    public GameUI gameUI;
    public PlayMode playMode;

    public TMP_Text ModeButtonText;

    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAi
    }

    public void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    public void SwitchPlayMode()
    {
        switch (playMode)
        {
            case PlayMode.PlayerVsPlayer:
                playMode = PlayMode.PlayerVsAi;
                ModeButtonText.text = "Player Vs Ai";
                player2Paddle.GetComponent<Paddle>().BotPaddle(true);
                break;
            case PlayMode.PlayerVsAi:
                playMode = PlayMode.PlayerVsPlayer;
                ModeButtonText.text = "Player Vs Player";
                player2Paddle.GetComponent<Paddle>().BotPaddle(false);
                break;
        }
    }
}
