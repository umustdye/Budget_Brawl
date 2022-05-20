using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButtonControl : MonoBehaviour
{
    public GameObject main_menu;
    public GameObject credits_menu;
    public GameObject level_select_menu;

    // Start is called before the first frame update
    void Start()
    {
        main_menu = transform.Find("MainMenu").gameObject;
        credits_menu = transform.Find("CreditsMenu").gameObject;
        level_select_menu = transform.Find("LevelSelectMenu").gameObject;

        Debug.Log("level: " + level_select_menu);
        Debug.Log("main: " + main_menu);
        Debug.Log("credits: " + credits_menu);

        main_menu.SetActive(true);
        credits_menu.SetActive(false);
        level_select_menu.SetActive(false);
    }

    public void LevelLoadButton(GameObject level)
    {
        string level_name = level.GetComponent<TextMeshProUGUI>().text;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(level_name);
    }

    public void LevelSelectButton()
    {
        main_menu.SetActive(false);
        level_select_menu.SetActive(true);
    }

    public void CreditsButton()
    {
        main_menu.SetActive(false);
        credits_menu.SetActive(true);
    }

    public void BackButton(GameObject button)
    {
        button.SetActive(false);
        main_menu.SetActive(true);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
