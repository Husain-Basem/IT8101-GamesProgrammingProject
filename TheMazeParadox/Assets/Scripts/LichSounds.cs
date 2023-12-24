using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichSounds : MonoBehaviour
{
    // variables
    public AudioSource source;
    public AudioClip[] clips;
    // used to deteremine the time to play a sound every 10 seconds
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // pick a random number in the size of the audio clip array
            AudioClip randomClip = clips[Random.Range(0, clips.Length)];

            // play clip
            source.PlayOneShot(randomClip);
        }
    }
}
