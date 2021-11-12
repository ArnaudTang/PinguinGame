using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obus"))
        {
            // Debug.Log("Destruction de " + collision.collider.tag);
            Destroy(collision.gameObject);
        }
    }
}
    