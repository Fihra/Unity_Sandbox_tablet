using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 1.0f;
    private Vector2 movement;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private GameObject projectile;

    private float activeMoveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashLength = 0.5f;
    [SerializeField] private float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentState == PlayerState.InGame)
        {
            InputDash();
            InputMovement();
            InputAttack();
            // Debug.Log(GameManager.instance.currentState);

        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void InputDash()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Pressed Z");
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

    void InputMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX * activeMoveSpeed, moveY * activeMoveSpeed);  
    }

    void Movement()
    {
        if(movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.back, movement);
        }
        rb.velocity = movement;
    }

    void InputAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            Instantiate(projectile, currentPosition, transform.rotation);
        }
    }

}
