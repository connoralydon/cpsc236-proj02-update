using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private static GameObject pullMult;

    
    private ScoreController scoreText;

    static int multInitMod = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreController>();
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
        if (collision.gameObject.tag == "PowerUp")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);

            multInitMod += 1; //add to multiplier when it hits
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);

            int scoreMult = multInitMod * 10;
            scoreText.GetComponent<ScoreController>().score += scoreMult;
            scoreText.GetComponent<ScoreController>().UpdateScore();

        }
       
    }
}
