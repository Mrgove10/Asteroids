using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //If it touches the walls
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Just in case the bullet is too far
        if (transform.position.x > 30 ||
            transform.position.x < -30 ||
            transform.position.z > 30 ||
            transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
}