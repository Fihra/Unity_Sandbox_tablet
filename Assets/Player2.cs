using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody2D rb;

    //For rotating character
    [SerializeField]
    private float rotationSpeed = 100f;
    private float horizontal;
    private float vertical;
    private Vector2 newPosition;

    [SerializeField]
    private int attackPower = 1;

    private float activeMoveSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    float dashSpeed = 1f;

    [SerializeField]
    float dashCooldown = 1f;

    [SerializeField]
    float dashLength = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    private void RotateDirection()
    {

        if(newPosition != Vector2.zero)
        {
            //Parameters: desired forward direction, 
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, newPosition);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Debug.Log("Dashing");
        Debug.Log("Dash Counter: " + dashCounter);
        Debug.Log("Dash Cool Counter: " + dashCoolCounter);
        {
            if(dashCounter <= 0 && dashCoolCounter <= 0) 
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        newPosition = new Vector2(horizontal * activeMoveSpeed, vertical * activeMoveSpeed);

        Dash();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * activeMoveSpeed, vertical * activeMoveSpeed);
        RotateDirection();
    }
}
