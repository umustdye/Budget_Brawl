using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelect : MonoBehaviour
{
    private GameObject label;
    private GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        label = transform.Find("Label").gameObject;
        slider = transform.Find("Slider").gameObject;
    }

    public void OnSliderChanged()
    {
        GameInfo.num_players = (int)slider.GetComponent<Slider>().value;
        label.GetComponent<TextMeshProUGUI>().text = "Players: " + GameInfo.num_players;
    }
}
