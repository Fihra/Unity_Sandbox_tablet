using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private int health = 1;
    public GameObject bullet = null;

    bool isMovingLeft = false;
    bool isMovingRight = false;
    bool endPointHit = false;
    private float cooldownMoveTime = 0;

    private Vector2 rightSide;
    private Vector2 leftSide;

    private void Awake()
    {
        rightSide = new Vector2(7.4f, transform.position.y);
        leftSide = new Vector2(-7.4f, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldownMoveTime+=Time.deltaTime;
        if(cooldownMoveTime >= 0.1f)
        {
            int prob = Random.Range(1, 10);
            // Debug.Log(prob);
            if(prob <= 5)
            {
                isMovingRight = true;
                isMovingLeft = false;
            } 
            else
            {
                isMovingRight = false;
                isMovingLeft = true;
            }

            cooldownMoveTime = 0;
        }

        if(isMovingLeft)
        {
            MoveLeft();
        }
        if(isMovingRight)
        {
            MoveRight();
        }

        MoveDown();

        // if(transform.position.x <= 7.0f)
        // {
        //     Debug.Log("Check Left");
        //     isMovingRight = false;
        //     isMovingLeft = true;
        // }
        // if(transform.position.x >= -7.0f)
        // {
        //     Debug.Log("Check Right");
        //     isMovingLeft = false;
        //     isMovingRight = true;
        // }



        // if(isMovingLeft) 
        // {
        //     if(transform.position.x < 7.0f)
        //     {
        //         MoveLeft();
        //         isMovingLeft = true;
        //     }
        // }
        
        // if(isMovingRight)
        // {
        //     if(transform.position.x > -7.0f)
        //     {
        //         MoveRight();
        //         isMovingRight = true;
        //     }
        // }
  

        // Debug.Log("Should I move?");


   
        // MoveLeft();
        // MoveRight() || MoveLeft();
        // Debug.Log(cooldownMoveTime);
        // MoveRight();
    }

    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f * moveSpeed * Time.deltaTime, transform.position.z); 
    }

    void MoveRight()
    {
        transform.position = Vector2.MoveTowards(transform.position, rightSide, moveSpeed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.position = Vector2.MoveTowards(transform.position, leftSide, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            health--;
            Debug.Log("Current Health: " + health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
