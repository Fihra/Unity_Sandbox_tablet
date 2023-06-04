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

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    float dashSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        newPosition = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);    
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        RotateDirection();
    }
}
