using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip buttonsound;
    public AudioClip connectsound;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void ButtonSound()
    {
        audioSource.clip = buttonsound;
        audioSource.Play();
    }
}
