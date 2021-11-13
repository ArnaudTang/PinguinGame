using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    SpawnObusCreator SpawnObusCreator;
    private void Awake()
    {
        SpawnObusCreator = FindObjectOfType<SpawnObusCreator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obus"))
        {
            Debug.Log("Touché par " + collision.collider.tag);
            SpawnObusCreator.StartGame();
        }
    }
}
