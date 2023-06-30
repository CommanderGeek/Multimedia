using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailManager : MonoBehaviour
{
    public GameObject tailParticlePrefab;
    public Transform birdTransform;
    public float spawnRate;
    public float destroyDelay;
    public float birdXOffset = -5f; // negativer X-Offset
    public float particleOffset = 0.1f; // Offset-Wert für die Partikel
    public int numParticles = 10; // Gesamtanzahl der Partikel

    private List<GameObject> tailParticles; // Liste zur Verfolgung der erzeugten Partikel

    void Start()
    {
        tailParticles = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnTailParticles();
        }
    }

    void SpawnTailParticles()
    {
        GameObject previousParticle = null; // Referenz auf das vorherige Partikel

        for (int i = 0; i < numParticles; i++)
        {
            // Berechne den xOffset für den aktuellen Partikel (negativer X-Offset)
            float particleXOffset = birdXOffset - (i * particleOffset);

            // Berechne die Zielposition des Partikels mit dem entsprechenden xOffset
            Vector3 targetPosition = birdTransform.position + new Vector3(particleXOffset, 0f, 0f);

            // Erzeuge das Partikelobjekt an der Zielposition
            GameObject tailParticle = Instantiate(tailParticlePrefab, targetPosition, Quaternion.identity);

            // Weise dem Partikel das Flappy Bird-Objekt als Ziel zu
            TailParticle tailParticleScript = tailParticle.GetComponent<TailParticle>();
            tailParticleScript.target = birdTransform;

            if (previousParticle != null)
            {
                // Weise dem vorherigen Partikel das aktuelle Partikelobjekt als Ziel zu
                TailParticle previousParticleScript = previousParticle.GetComponent<TailParticle>();
                previousParticleScript.target = tailParticle.transform;
            }

            tailParticles.Add(tailParticle); // Füge das Partikel zur Liste hinzu

            previousParticle = tailParticle; // Setze das aktuelle Partikel als vorheriges Partikel
        }
    }

    // Methode zum Zerstören aller erzeugten Partikel
    public void DestroyTailParticles()
    {
        foreach (GameObject tailParticle in tailParticles)
        {
            Destroy(tailParticle, destroyDelay);
        }
        tailParticles.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rigidbody"))
        {
            SpawnTailParticles();
        }
    }
}
