using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpStraightManager : MonoBehaviour
{

    private float timer;
    private float maxTimer;
    public GameObject powerUpStraight;


    public float timerMin = 20f;
    public float timerMax = 30f;




    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(timerMin, maxTimer);

        StartCoroutine(SpawnPowerUpStraightTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPowerUpStraight()
    {
        float y = 1.25f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0));
        spawnPoint.z = 0;

        //adjust x-axis position
        float dist = (this.transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        Vector3 powerUpStraightSize = powerUpStraight.GetComponent<Renderer>().bounds.size;
        spawnPoint.x = Mathf.Clamp(spawnPoint.x, leftBorder + powerUpStraightSize.x * 2, rightBorder - powerUpStraightSize.x * 2);

        GameObject.Instantiate(powerUpStraight, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnPowerUpStraightTimer()
    {
        while (Time.timeScale != 0)
        {
            if (timer >= maxTimer)
            {
                //spawn an enemy
                SpawnPowerUpStraight();
                timer = 0;
                maxTimer = Random.Range(timerMin, maxTimer);
            }

            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

   
}

