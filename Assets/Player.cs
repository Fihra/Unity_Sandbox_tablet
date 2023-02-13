using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 4f; 
    Vector2 movement;
    private Rigidbody2D rb; 
    public GameObject bullet;
    public GameObject WeaponShot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Vertical");
        float moveY = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveY, moveX);
    }

    void Attack()
    {
        if(Input.GetKeyDown("space"))
        {
            Instantiate(bullet, WeaponShot.transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
