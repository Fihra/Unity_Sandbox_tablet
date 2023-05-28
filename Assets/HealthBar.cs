using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    SpriteRenderer healthColor;
    private int maxHealth;

    Color halfHealth = Color.yellow;

    private bool almostDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        healthColor = transform.GetComponent<SpriteRenderer>();
        maxHealth = transform.parent.GetComponent<TestEnemy>().GetHealth();
    }

    private int halfHealthCheck()
    {
        float temp = (float)maxHealth/2;
        int tempInt = (int)Mathf.Round(temp);
        return tempInt;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = transform.parent.GetComponent<TestEnemy>().GetHealth();
        transform.localScale = localScale;

        if(transform.parent.GetComponent<TestEnemy>().GetHealth() < halfHealthCheck())
        {
            Debug.Log("Yellow Warning");
            healthColor.color = halfHealth;
        }

        
    }
}
