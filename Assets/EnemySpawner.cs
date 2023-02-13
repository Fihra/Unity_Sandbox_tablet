using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int randomNum;
    
    private float timer;
    private const float timerSpawner = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    float RandomNumGenerator()
    {
        return Random.Range(-7.0f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= timerSpawner)
        {
            Vector3 newSpawnPoint = new Vector3(RandomNumGenerator(), transform.position.y, transform.position.z);

            Instantiate(enemy, newSpawnPoint, transform.rotation);
            timer = 0;
        }
        // Debug.Log(RandomNumGenerator());
    }
}
