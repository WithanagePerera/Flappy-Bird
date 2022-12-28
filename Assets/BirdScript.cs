using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody2D;
    public float flapStrength = 35;
    public LogicManager logic;
    public bool alive = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started.");
        Debug.Log("Bird initialized.");

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive)
            myRigidBody2D.velocity = Vector2.up*flapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        alive = false;
        Debug.Log("Dead called.");
    }
}
