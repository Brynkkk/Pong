using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int winScore;

    private int player1Score = 0;
    private int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText; 

    public void Player1Point()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        CheckScore();
    }

    public void Player2Point()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        CheckScore();
    }

    private void CheckScore()
    {
        if(player1Score == winScore)
        {
            SceneManager.LoadScene("Player1 Win");
        }
        else if(player2Score == winScore)
        {
            SceneManager.LoadScene("Player2 Win");
        }
    }
}
