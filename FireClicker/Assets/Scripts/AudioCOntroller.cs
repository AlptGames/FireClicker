using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioCOntroller : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;

    public AudioClip clip;
    public AudioSource audio;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void OnOffAudio()
    {
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }

        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }

    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
         audio.volume = slider.value;
    }
}
