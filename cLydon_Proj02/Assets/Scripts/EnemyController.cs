using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private float timerBullet;
    private float maxTimerBullet;
    public GameObject Bullet;

    public float timerMin = 0.5f;
    public float timerMax = 5f;
    public bool canFireBullets = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        timerBullet = 0;
        maxTimerBullet = Random.Range(timerMin, timerMax);

        if (canFireBullets)
            StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0) //takes position in viewport, like where bullet it, if it goes out it deletes the object
        {
            Destroy(this.gameObject);
        }
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.y -= (Bullet.GetComponent<Renderer>().bounds.size.y / 2) + (GetComponent<Renderer>().bounds.size.y / 2);
        GameObject.Instantiate(Bullet, spawnPoint, transform.rotation);
    }


    IEnumerator FireBullet()
    {
        while (Time.timeScale != 0)
        {
            if (timerBullet >= maxTimerBullet)
            {
                // Spawn a bullet
                SpawnBullet();
                timerBullet = 0;
                maxTimerBullet = Random.Range(timerMin, timerMax);
            }

            timerBullet += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
