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
        if (player1Score == winScore)
        {
            GameObject player2 = GameObject.Find("Player2");
            Animator player2Animator = player2.GetComponent<Animator>();
            player2Animator.SetTrigger("death");
            StartCoroutine(WaitForAnimation(player2Animator, "Player1 Win"));
        }
        else if (player2Score == winScore)
        {
            GameObject player1 = GameObject.Find("Player1");
            Animator player1Animator = player1.GetComponent<Animator>();
            player1Animator.SetTrigger("death");
            StartCoroutine(WaitForAnimation(player1Animator, "Player2 Win"));
        }
    }

    private IEnumerator WaitForAnimation(Animator animator, string sceneName)
    {
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        SceneManager.LoadScene(sceneName);
    }
}
