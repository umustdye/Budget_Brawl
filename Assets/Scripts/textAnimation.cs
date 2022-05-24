using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class textAnimation : MonoBehaviour
{
    TMP_Text text;
    Mesh mesh;
    Vector3[] vertices;
    TMP_CharacterInfo[] characters;
    public textRoundStart transition;

    public float amplitude = 20.0f;
    public float period = (float)Math.PI * 3.0f;
    public float speed = 5.0f;
    public Vector3 scale = new Vector3(1.5f, 1.5f, 1.0f);

    public bool isTimeOver = false;

    private float textLength;
    int k = 0;

    float timer = 0.0f;
    float threshold = 0.25f;
    float animationSeconds;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        disappear();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeOver){
            appear();
        }

        text.ForceMeshUpdate();

        mesh = text.mesh;
        vertices = mesh.vertices;

        characters = text.textInfo.characterInfo;

        //for(int i = 0; i < characters.Length; i++){
        if(k >= characters.Length){
            k = 0;
        }
        TMP_CharacterInfo ch = characters[k];

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
        //}      

        mesh.vertices = vertices;
        text.canvasRenderer.SetMesh(mesh);

        if(timer >= threshold){
            timer = 0.0f;
            k++;
            if(animationSeconds == 0.0f){
                disappear();
            }
            animationSeconds -= threshold;
        }
        else{
            timer += Time.deltaTime;
        }
    }

    Vector3 wave(float time){
        return new Vector3(0, amplitude * Mathf.Cos(time * period), 0);
    }

    public void appear(){
        if(gameObject.transform.localScale.x < scale.x){
            gameObject.transform.localScale += new Vector3(0.025f, 0.025f, 1.0f);
        }
        else{
            isTimeOver = false;
        }
    }

    public void disappear(){
        // transition occurs here
        transition.isEnter = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void setAnimationSeconds(float seconds){
        animationSeconds = seconds;
    }
}
