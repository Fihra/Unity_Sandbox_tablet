using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdateDamage()
    {
        damage++;
    }

    public int GetDamage()
    {
        Debug.Log("Attack Damage: " + damage);
        return damage;
    }

    void Start()
    {
        Invoke("SlashLifeSpan", 0.1f);
    }

    void SlashLifeSpan()
    {
        Destroy(gameObject);
    }
}
