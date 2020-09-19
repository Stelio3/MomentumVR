using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadelBall : MonoBehaviour
{
    Vector3 iniPosition;
    public string hitter;

    int playerScore;

    public bool playing = true;

    [SerializeField] Text playerScoreText;
    // Start is called before the first frame update
    void Start()
    {
        iniPosition = transform.position;
        playerScore = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = iniPosition;

            GameObject.Find("player").GetComponent<PadelPlayer>().Reset();
        }

        if(playing)
        {
            playing = false;
            updateScore(); 
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && playing)
        {
            playerScore++;
        }
        playing = false;
        updateScore();
    }

    void updateScore()
    {
        playerScoreText.text = "Player: " + playerScore;
    }
}
