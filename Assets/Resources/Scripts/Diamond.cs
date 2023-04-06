using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Destroy diamon if it goes off screen on the left
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
        else
        {
            // Rotate the diamond as ti moves through the screen
            transform.Translate(-SkyscraperSpawner.speed * Time.deltaTime, 0, 0, Space.World);
        }
        transform.Rotate(0, 5f, 0, Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        // If diamond spawns where a building exists, destroy the diamond
        if (other.tag == "building")
        {
            Destroy(gameObject);
        }

        // Add 5 points to player total if helicopter touched diamond
        other.transform.parent.GetComponent<HeliController>().AddToCoinTotal(5);
        Destroy(gameObject);
    }
}
