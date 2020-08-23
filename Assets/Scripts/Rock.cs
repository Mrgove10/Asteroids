using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var currentPosition = transform.position;
        switch (other.name)
        {
            case "Bot":
                transform.position = new Vector3(currentPosition.x, currentPosition.y, Config.PosMax - transform.localScale.z);
                break;
            case "Right":
                transform.position = new Vector3(Config.PosMin + transform.localScale.x, currentPosition.y, currentPosition.z);
                break;
            case "Left":
                transform.position = new Vector3(Config.PosMax - transform.localScale.x, currentPosition.y, currentPosition.z);
                break;
            case "Top":
                transform.position = new Vector3(currentPosition.x, currentPosition.y, Config.PosMin + transform.localScale.z);
                break;
        }
    }
}