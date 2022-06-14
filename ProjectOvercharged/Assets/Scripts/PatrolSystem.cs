using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float starWaitTime;

    public Transform[] moveSpots;
    private int randomShot;

    private void Start()
    {
        randomShot = Random.Range(0, moveSpots.Length);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomShot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomShot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomShot = Random.Range(0, moveSpots.Length);
                waitTime = starWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
