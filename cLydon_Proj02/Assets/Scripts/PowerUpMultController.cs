using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpMultController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    public int multInit = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0) //takes position in viewport, like where bullet it, if it goes out it deletes the object
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);

            multInit += 1; //double multiplier when it hits
        }
    }
}
