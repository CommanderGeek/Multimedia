using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityFromAudioClip : MonoBehaviour
{

    public AudioSource source;
    public Vector2 minSpeed;
    public Vector2 maxSpeed;
    public AudioLoudnessDetection detector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip);

        transform.localScale = Vector2.Lerp(minSpeed, maxSpeed, loudness);
    }
}
