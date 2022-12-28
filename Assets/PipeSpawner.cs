using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    private float timer = 0;
    public float spawnRate = 2;
    public float heightOffset = 10;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pipe spawner initialized.");
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer += Time.deltaTime;
        else if (timer >= spawnRate && bird.alive)
        {
            spawnPipe();
            timer = 0;
        }
    }

    public void spawnPipe()
    {
        float low = transform.position.y - heightOffset;
        float high = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(low, high), transform.position.z), transform.rotation);
    }
}