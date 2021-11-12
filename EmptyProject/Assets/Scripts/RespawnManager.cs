using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obus"))
        {
            Debug.Log("Touché par " + collision.collider.tag);
            this.transform.position = new Vector3(10, 3, 25);
            this.transform.Rotate(new Vector3(0, 0, 0));
        }
    }
}
