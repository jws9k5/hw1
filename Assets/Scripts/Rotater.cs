//Author: Jonny Stadter
//Date: 9/22/2024
//Rotates the Obstacles
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,45) * Time.deltaTime);
    }
}
