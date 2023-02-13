using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTower : MonoBehaviour
{
    private GameObject attackRange;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Instantiate(projectile, currentPosition, transform.rotation);
            Debug.Log("OoOooOOOhhHhh an enemy has entered my attack circle");
        }
    }
}
