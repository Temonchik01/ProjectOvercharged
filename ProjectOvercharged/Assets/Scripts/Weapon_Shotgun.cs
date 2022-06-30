using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shotgun : MonoBehaviour
{
    public float offset;
    public Transform firePoint;
    public GameObject bullet;
    public int amountOfBullets;
    public float spread, bulletSpeed;

    private float TimeShots;
    public float startTimeShots;
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        if (TimeShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                TimeShots = startTimeShots;
            }
        }
        else
        {
            TimeShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        for(int i = 0; i < amountOfBullets; i++)
        {
            GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            brb.velocity = (dir + pdir) * bulletSpeed;
        }
    }    
}
