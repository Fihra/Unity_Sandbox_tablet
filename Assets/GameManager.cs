using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { InGame, Menu }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerState currentState;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.InGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
