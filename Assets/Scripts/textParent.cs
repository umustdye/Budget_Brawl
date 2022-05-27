using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class textParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        isAnimationEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void appear(float time);

    public abstract void disappear(float time);

    public abstract void setAnimationSeconds(float time);

    public bool isEnter;
    public bool isAnimationEnd;

    public GameObject next;
}
