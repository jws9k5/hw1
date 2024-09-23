//Author: Jonny Stadter
//Date: 9/22/2024
//Handles the movement and direction of the obstacles.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D rb2d;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        float x = UnityEngine.Random.Range(-10.0f, 10.0f);
        float y = UnityEngine.Random.Range(-10.0f, 10.0f);
        Vector2 movement = new Vector2(x, y); //Direction and speed of obst will be different each restart.

        rb2d.velocity = movement;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
