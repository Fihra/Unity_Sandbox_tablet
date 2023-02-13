using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject resumeButtonUI, quitButtonUI;

    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.currentState = PlayerState.Menu; 
        EventSystem.current.SetSelectedGameObject(resumeButtonUI);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.currentState = PlayerState.InGame;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            

            if(GameManager.instance.currentState != PlayerState.Menu)
            {
                PauseMenu();
            }
            else
            {
                ResumeGame();
            }
            
        }
    }
}
