using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    AudioSource footstepPlayer;
    [SerializeField] AudioClip[] footstepClips;
    // Start is called before the first frame update
    void Start()
    {
        footstepPlayer = GetComponent<AudioSource>();


    }

    public void PlayFootstepSound()
    {
        float randomVolume = Random.Range(0.8f, 1f);
        float randomPitch = Random.Range(0.9f, 1.1f);
        int randomClip = Random.Range(0, 2);
        footstepPlayer.clip = footstepClips[randomClip];
        footstepPlayer.pitch = randomPitch;
        footstepPlayer.volume = randomVolume;


        footstepPlayer.Play();

    } 


    // Update is called once per frame
    void Update()
    {
        
    }
}
