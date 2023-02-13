using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueExisting : MonoBehaviour
{
    public static ContinueExisting instance; 

    void Awake(){
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
