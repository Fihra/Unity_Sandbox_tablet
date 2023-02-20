using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestData : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject obj = GameObject.Find("EnemyInfo");
            if(obj.activeSelf) {
                obj.SetActive(false);
            }
        }
    }
}
