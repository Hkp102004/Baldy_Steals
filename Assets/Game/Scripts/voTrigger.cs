using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip clip;
    private int voiceCount = 0;
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        if(audioPlayer == null)
        {
            Debug.LogError("Audio source in some of the script is missing dawg");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(voiceCount <= 2)
        {
            if(other.tag == "Player")
            {
                audioPlayer.Play(); //playing the VO for coin using audioSource
                // AudioSource.PlayClipAtPoint(clip,Vector3.zero); // playing the audio using just the clip
                voiceCount++;

            }    
        }
    }
}
