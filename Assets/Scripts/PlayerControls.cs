using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;
    public float rotateSpeed = Config.RotateSpeed;
    public float movementSpeed = Config.MovementSpeed;

    public PlayerAudio playerAudio;

    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var currentPosition = transform.position;
        switch (other.name)
        {
            case "Bot":
                transform.position = new Vector3(currentPosition.x, currentPosition.y, Config.PosHyperspaceMax);
                break;
            case "Right":
                transform.position = new Vector3(Config.PosHyperspaceMin, currentPosition.y, currentPosition.z);
                break;
            case "Left":
                transform.position = new Vector3(Config.PosHyperspaceMax, currentPosition.y, currentPosition.z);
                break;
            case "Top":
                transform.position = new Vector3(currentPosition.x, currentPosition.y, Config.PosHyperspaceMin);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            rb.AddRelativeForce(new Vector3(0, Math.Abs(vertical) * movementSpeed, 0));
            playerAudio.PlayThrust();
        }

        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            rb.AddTorque(new Vector3(0, horizontal * rotateSpeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            HyperSpace();
        }
    }

    void Shoot()
    {
        Debug.Log("shoot");
        playerAudio.PlayShoot();
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, Config.bulletSpeed));
    }

    /**
     * HyperSpace teleports the user to a random location on the screen
     * If the payer is teleported on top of an asteroids he looses a life
     */
    void HyperSpace()
    {
        Debug.Log("hyperspace");
        System.Random r = new System.Random();
        var x = r.Next(Config.PosHyperspaceMin, Config.PosHyperspaceMax);
        var z = r.Next(Config.PosHyperspaceMin, Config.PosHyperspaceMax);
        var newPosition = new Vector3(x, 0, z);
        transform.position = newPosition;
    }
}