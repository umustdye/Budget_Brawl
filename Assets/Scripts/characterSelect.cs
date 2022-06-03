using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSelect : MonoBehaviour
{
    public Color normal;
    public GameObject display;

    Sprite blue;
    Sprite red;

    // Start is called before the first frame update
    void Start()
    {
        normal.a = 1.0f;
        ColorBlock colors = gameObject.GetComponent<Button>().colors;
        colors.normalColor = normal;
        colors.selectedColor = colors.normalColor;
        Color newPressed = (normal - Color.gray);
        newPressed.a = 1.0f;
        colors.pressedColor = newPressed;
        colors.highlightedColor = normal + Color.gray;
        colors.disabledColor = colors.highlightedColor;
        gameObject.GetComponent<Button>().colors = colors;

        blue = Resources.Load<Sprite>("Dr.Big_Apple");
        red = Resources.Load<Sprite>("Female_Humanoid");

        PlayerPrefs.SetInt("Player1", 0);
        PlayerPrefs.SetInt("Player2", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void p1SelectBlue(){
        // 0 is blue guy
        PlayerPrefs.SetInt("Player1", 0);
        display.transform.rotation = Quaternion.Euler(0, 0, 0);
        display.GetComponent<Image>().sprite = blue;
    }

    public void p1SelectRed(){
        // 1 is red guy
        PlayerPrefs.SetInt("Player1", 1);
        display.transform.rotation = Quaternion.Euler(0, 180, 0);
        display.GetComponent<Image>().sprite = red;
    }

    public void p2SelectBlue(){
        // 0 is blue guy
        PlayerPrefs.SetInt("Player2", 0);
        display.transform.rotation = Quaternion.Euler(0, 180, 0);
        display.GetComponent<Image>().sprite = blue;
    }

    public void p2SelectRed(){
        // 1 is red guy
        PlayerPrefs.SetInt("Player2", 1);
        display.transform.rotation = Quaternion.Euler(0, 0, 0);
        display.GetComponent<Image>().sprite = red;
    }
}
