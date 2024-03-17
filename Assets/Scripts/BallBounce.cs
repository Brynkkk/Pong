using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;

    public GameObject hitSFX;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPos = transform.position;
        Vector3 racketPos = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPos.y - racketPos.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Player2ScoreArea")
        {
            scoreManager.Player1Point();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if(collision.gameObject.name == "Player1ScoreArea")
        {
            scoreManager.Player2Point();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
