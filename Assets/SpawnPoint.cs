using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private float timer;
    [SerializeField]
    private float spawner = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;

        if(timer >= spawner)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
