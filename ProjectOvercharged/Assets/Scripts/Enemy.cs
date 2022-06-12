using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    [SerializeField]
    GameObject bullet;
    float fireRate;
    float nextFire;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        fireRate = 1f;
        nextFire = Time.time;
    }

    void Update()
    {
        CheakifTimeToFire();
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    void CheakifTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
