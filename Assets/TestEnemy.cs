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

    public int GetHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    void ShowNumberDamage()
    {

    }

    private void DamageHealth(int damage)
    {
        GameObject numberDamageObject = Instantiate(Resources.Load("NumberDamage") as GameObject);
        
        // numberDamageObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        numberDamageObject.transform.parent = transform.parent;
        Debug.Log("My parent is: ", transform.parent);

        numberDamageObject.transform.position = transform.position;

        numberDamageObject.SetActive(true);

        Destroy(numberDamageObject, 0.5f);
        
        currentHealth -= damage;
        if(currentHealth <= 0)
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
