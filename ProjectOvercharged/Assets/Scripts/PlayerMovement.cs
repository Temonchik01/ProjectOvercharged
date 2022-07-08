using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public int health;
    public Weapon weapon;
    public Weapon_Shotgun shotgun;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public GameObject[] guns;
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject weaponHolder;
    public GameObject currentGun;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeaponIndex < totalWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection = moveInput.normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (health <= 0)
        {
             Destroy(gameObject);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
