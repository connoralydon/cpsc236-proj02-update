using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private static GameObject powerUpMult;
    

    private Text scoreText;
    private int mult = powerUpMult.GetComponent<PowerUpMultController>().multInit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1) //takes position in viewport, like where bullet it, if it goes out it deletes the object
        {
            scoreText.GetComponent<ScoreController>().score -= 5;
            if (scoreText.GetComponent<ScoreController>().score < 0)
                scoreText.GetComponent<ScoreController>().score = 0;
            scoreText.GetComponent<ScoreController>().UpdateScore();

            Destroy(this.gameObject);
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            scoreText.GetComponent<ScoreController>().score += (mult * 10);
            scoreText.GetComponent<ScoreController>().UpdateScore();
        }        
    }
}
