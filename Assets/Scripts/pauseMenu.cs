using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    private bool isPaused;

    public GameObject pauseMenuUI;
    public GameObject soundUI;

    private GameObject volumeSlider;
    private GameObject volumeText;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = soundUI.transform.GetChild(0).gameObject;
        volumeText = soundUI.transform.GetChild(1).gameObject;
        
        soundUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        isPaused = false;

        volumeSlider.GetComponent<Slider>().value = 0.05f;
        changeVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            // Debug.Log("esc pressed");
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

    public void enableSound(){
        soundUI.SetActive(true);
    }

    public void disableSound(){
        soundUI.SetActive(false);
    }

    public void changeVolume(){
        AudioListener.volume = volumeSlider.GetComponent<Slider>().value;
        volumeText.GetComponent<Text>().text = "Volume: " + (int) (AudioListener.volume*100);
    }

    public void toMenu(){
        // TODO: move to the menu onClick()
        string menu = "Main_Menu";
        Time.timeScale = 1.0f;
        isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menu);
    }

    public void quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
