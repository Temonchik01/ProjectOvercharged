using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public int dashSpeed;

    bool dash = true;
    int dashCooldown = 60;

    private void FixedUpdate()
    {
        if (dashCooldown == 0)
        {
            dash = true;
        }
        else
        {
            dashCooldown--;
        }

        rb.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.Space) && dash)
        {
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2));
            rb.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            dash = false;
            dashCooldown = 60;
        }
    }
}
