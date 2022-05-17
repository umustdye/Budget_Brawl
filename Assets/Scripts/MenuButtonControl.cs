using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButtonControl : MonoBehaviour
{
    private GameObject main_menu;
    private GameObject credits_menu;
    private GameObject level_select_menu;

    // Start is called before the first frame update
    void Start()
    {
        main_menu = transform.Find("MainMenu").gameObject;
        credits_menu = transform.Find("CreditsMenu").gameObject;
        level_select_menu = transform.Find("LevelSelectMenu").gameObject;

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
        Application.Quit();
    }
}
