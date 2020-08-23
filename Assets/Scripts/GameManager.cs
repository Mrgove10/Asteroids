using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;

    void Start()
    {
        var r = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            var rock = Instantiate(asteroid, new Vector3(r.Next(Config.PosMin, Config.PosMax), 0, r.Next(Config.PosMin, Config.PosMax)), Quaternion.identity);
            var force = new Vector3(r.Next(-10, 10) * 50, 0, r.Next(-10, 10) * 50);
            rock.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}