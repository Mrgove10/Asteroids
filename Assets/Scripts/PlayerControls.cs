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
        Debug.Log(other.name);
        switch (other.name)
        {
            case "Bot":
                break;
            case "Right":
                break;
            case "Left":
                break;
            case "Top":
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
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 10, 0));
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