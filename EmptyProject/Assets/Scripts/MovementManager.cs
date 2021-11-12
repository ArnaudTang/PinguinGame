using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] float speed = .1f;

    // Update is called once per frame
    void Update()
    {
        int xAxisMouv = 0;
        int yAxisMouv = 0;
        int zAxisMouv = 0;


        if (Input.GetKey(KeyCode.Z))
        {
            zAxisMouv++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            zAxisMouv--;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            xAxisMouv--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xAxisMouv++;
        }
        if (Input.GetKey(KeyCode.Space) && this.gameObject.transform.position.y <= 1)
        {
            yAxisMouv++;
        }

        Vector3 mouv = new Vector3(xAxisMouv * speed, yAxisMouv*5, zAxisMouv * speed);
        this.gameObject.transform.Translate(mouv);
    }
}
