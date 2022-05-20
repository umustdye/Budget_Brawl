using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    private bool isPaused;

    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("esc pressed");
            if(isPaused){
                // resume the game here
                // remove game menu
                resume();
            }
            else{
                // pause the game here
                // show pause menu
                pause();
            }
        }
    }

    public bool isGamePaused(){
        return isPaused;
    }

    public void resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void toMenu(){
        // TODO: move to the menu onClikc()
    }

    public void quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
