using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInputManager : MonoBehaviour
{
    private bool inputReceived;
    private bool attackReady;

    private GameObject attackBox;


    [SerializeField]
    private GameObject slashAttack;

    void Awake()
    {
        attackBox = transform.Find("face").gameObject.transform.Find("AttackBox").gameObject;
        Debug.Log(attackBox);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Attacking");
            RandomSlash();
 
        }
    }

    private void RandomSlash()
    {
        float randomNum = Random.Range(0, 10);

        if(randomNum > 5){
            Instantiate(slashAttack, attackBox.transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
        } else {
            Instantiate(slashAttack, attackBox.transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in Range");
        }
    }
}
