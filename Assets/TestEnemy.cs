using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 3;

    [SerializeField]
    private float moveSpeed = 10f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void DamageHealth(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Slash"))
        {
            DamageHealth(other.GetComponent<Slash>().GetDamage());
        }
    }

}
