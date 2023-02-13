using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private int damage = 1;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("ProjectileLifeSpan", 3.0f);
    }

    private void Update()
    {
        //CHANGE DIRECTION TO CONSIDER ROTATION
        rb.AddForce((Vector2.up * moveSpeed));
    }

    void ProjectileLifeSpan()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
