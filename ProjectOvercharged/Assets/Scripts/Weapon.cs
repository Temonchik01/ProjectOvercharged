using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform firePoint;

    private float TimeShots;
    public float startTimeShots;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (TimeShots <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                Instantiate(bullet, firePoint.position, transform.rotation);
                TimeShots = startTimeShots;
            }
        }
        else
        {
            TimeShots -= Time.deltaTime;
        }
    }    
}
