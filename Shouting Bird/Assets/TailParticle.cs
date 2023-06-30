using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailParticle : MonoBehaviour
{
    public Transform target; // Referenz zum Flappy Bird-Objekt
    public float followSpeed; // Geschwindigkeit, mit der das Partikel dem Flappy Bird folgt
    public float xOffset; // Der gewünschte Offset-Wert für die X-Achse

    private Vector3 initialOffset; // Initialer Offset zwischen Partikel und Bird

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            // Berechne den initialen Offset zwischen Partikel und Bird
            initialOffset = transform.position - target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Berechne die Zielposition des Partikels basierend auf dem aktuellen Offset und dem gewünschten X-Offset
            Vector3 targetPosition = target.position + initialOffset + new Vector3(xOffset, 0f, 0f);

            // Berechne die neue Position des Partikels basierend auf der Zielposition und der Follow-Geschwindigkeit
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Aktualisiere die Position des Partikels
            transform.position = newPosition;
        }
    }
}
