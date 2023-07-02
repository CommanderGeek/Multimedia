using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public ParticleSystem ps; 

    //audio input
    public AudioSource source;
    public Vector2 minSpeed = new Vector2(0, 0);
    public Vector2 maxSpeed;
    public AudioLoudnessDetection detector;

    public float sensibility = 100;
    public float threshhold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * sensibility;

        if (loudness > threshhold && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.Lerp(minSpeed, maxSpeed, loudness);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        ps.Play();

    }
}
