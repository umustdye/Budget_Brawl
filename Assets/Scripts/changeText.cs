using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeText : MonoBehaviour
{
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void draw(){
        text.text = "Draw";
    }

    public void win(){

        text.text = "Wins!";
    }
}
