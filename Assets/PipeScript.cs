using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipe;
    public float speed = 15;
    private const float deadZone = -26;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            Debug.Log("Pipe destroyed.");
        }

        if (!bird.alive)
            Destroy(pipe);
    }
}
