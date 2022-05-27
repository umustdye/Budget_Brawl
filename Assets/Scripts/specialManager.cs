using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialManager : MonoBehaviour
{
    // particle game object
    private ParticleSystem particles;

    float timer = 0.0f;
    float specialDuration = 20.0f;

    private bool specialCharged = false;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        stopParticles();
    }

    // Update is called once per frame
    void Update()
    {
        if(particles.isPlaying){
            if(timer >= specialDuration){
                stopParticles();
                dischargeSpecial();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
    }

    public void stopParticles(){
        particles.Stop();
    }

    public void playParticles(){
        particles.Play();
    }

    public void chargeSpecial(){
        specialCharged = true;
    }

    public void dischargeSpecial(){
        specialCharged = false;
    }

    // return true if special is charged, otherwise return false
    public bool isSpecialCharged(){
        return specialCharged;
    }
}
