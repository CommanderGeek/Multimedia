using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();  
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    private void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 10)).x;
        Instantiate(pipe, new Vector3(spawnX, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
