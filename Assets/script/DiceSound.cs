using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSound : MonoBehaviour
{
    AudioSource ads;
    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    public void playSound()
    {

        ads.Play(); 

    }
}
