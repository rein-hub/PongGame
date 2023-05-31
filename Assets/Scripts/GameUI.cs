using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("Score UI")]
    public GameObject player1Text;
    public GameObject player2Text;
    public GameObject menuObject;

    private int player1Score;
    private int player2Score;

    public void player1Scored()
    {
        player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        GameObject.Find("GameManager").GetComponent<GameManager>().ResetPosition();
    }

    public void player2Scored()
    {
        player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        GameObject.Find("GameManager").GetComponent<GameManager>().ResetPosition();
    }

    public void OnStartGameButtonClicked()
    {
        menuObject.SetActive(false);
        GameObject.Find("ball").GetComponent<Ball>().Reset();
    }

    public void OnSwitchModeButtonClicked()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SwitchPlayMode();
    }
}
