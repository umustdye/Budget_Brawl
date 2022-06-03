using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSelect : MonoBehaviour
{
    public Color normal;
    public Image display;

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

        p1SelectBlue();
        p2SelectRed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void p1SelectBlue(){
        // 0 is blue guy
        PlayerPrefs.SetInt("Player1", 0);
    }

    public void p1SelectRed(){
        // 1 is red guy
        PlayerPrefs.SetInt("Player1", 1);
    }

    public void p2SelectBlue(){
        // 0 is blue guy
        PlayerPrefs.SetInt("Player2", 0);
    }

    public void p2SelectRed(){
        // 1 is red guy
        PlayerPrefs.SetInt("Player2", 1);
    }
}
