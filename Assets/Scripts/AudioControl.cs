using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource fillSound, missSound;
    
    public static AudioControl S;
    
    void Awake() {
        S = this;
    }

    public void PlayFill() {
        fillSound.Play();
    }

    public void PlayMiss() {
        missSound.Play();
    }

}
