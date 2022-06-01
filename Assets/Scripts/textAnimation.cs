using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class textAnimation : textParent
{
    TMP_Text text;
    Mesh mesh;
    Vector3[] vertices;
    TMP_CharacterInfo[] characters;
    private textParent transition;

    public float amplitude = 20.0f;
    public float period = (float)Math.PI * 3.0f;
    public float speed = 5.0f;
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.0f);

    private float textLength;
    int k = 0;

    float timer = 0.0f;
    float threshold = 0.25f;
    float animationSeconds;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        if(next != null){
            transition = next.GetComponent<textParent>();
        }
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gameObject.transform.localScale);
        if(!isAnimationEnd){
            // when time is over, time over string appears
            if(isEnter){
                appear(Time.deltaTime);
            }
            text.ForceMeshUpdate();

            mesh = text.mesh;
            vertices = mesh.vertices;

            // access text as a characterInfo array
            characters = text.textInfo.characterInfo;

            // if the index of characters exceeds the length of text, reset index
            if(k >= characters.Length){
                k = 0;
            }
            // choose character from text
            TMP_CharacterInfo ch = characters[k];

            // find vertices of current character
            // update the position of current character
            for(int j = 0; j < vertices.Length; j++){
                if(ch.vertex_BL.position == vertices[j]){
                    Vector3 offset = wave(Time.time);

                    vertices[j] = vertices[j] + offset;
                }
                if(ch.vertex_BR.position == vertices[j]){
                    Vector3 offset = wave(Time.time);

                    vertices[j] = vertices[j] + offset;
                }
                if(ch.vertex_TL.position == vertices[j]){
                    Vector3 offset = wave(Time.time);

                    vertices[j] = vertices[j] + offset;
                }
                if(ch.vertex_TR.position == vertices[j]){
                    Vector3 offset = wave(Time.time);

                    vertices[j] = vertices[j] + offset;
                }
            }

            // render the updated vertices
            mesh.vertices = vertices;
            text.canvasRenderer.SetMesh(mesh);

            // timer for incrementing index
            // only one character moves at a time
            if(timer >= threshold){
                timer = 0.0f;
                k++;
                // when designated time expires, text disappears
                if(animationSeconds == 0.0f){
                    disappear(0.0f);
                }
                animationSeconds -= threshold;
            }
            else{
                timer += Time.deltaTime;
            }
        }
    }

    Vector3 wave(float time){
        return new Vector3(0, amplitude * Mathf.Cos(time * period), 0);
    }

    // enlarges the text in the middle
    public override void appear(float time){
        if(gameObject.transform.localScale.x < scale.x){
            gameObject.transform.localScale += new Vector3(0.025f, 0.025f, 1.0f);
        }
        else{
            isEnter = false;
        }
    }

    // diminishes the text to 0
    // transition is only used in this function
    public override void disappear(float time){
        // transition occurs here
        // transition => Draw/Player x Win!
        if(next == null){
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            isAnimationEnd = true;

            // to the result screen maybe?
            string menu = "Main_Menu";
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(menu);

            return;
        }

        // if next animation is in Draw/Win state
        changeText eval = transition.GetComponent<changeText>();
        if(eval != null){
            eval.win();
        }
        transition.setAnimationSeconds(2.0f);
        transition.isAnimationEnd = false;
        transition.isEnter = true;

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        isAnimationEnd = true;
    }

    // set the designated time for displaying animations
    public override void setAnimationSeconds(float seconds){
        animationSeconds = seconds;
    }

    private bool isAnimationRunning(){
        return gameObject.transform.localScale != new Vector3(0,0,0);
    }
}
