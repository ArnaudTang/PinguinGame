using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObusCreator : MonoBehaviour
{
    GameObject m_Plane;
    [SerializeField] GameObject obus;
    float px = 50f;
    float py = 10f;
    float pz = 10f;

    private void Awake()
    {
        
            
    }
    // Start is called before the first frame update
    void Start()
    {
    
        m_Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        m_Plane.transform.localScale = new Vector3(px, py, pz);
        m_Plane.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject new_Obus = Instantiate(obus);
        float randomX = Random.Range(0,px);
        float randomY = Random.Range(10, 30);
        float randomZ = Random.Range(0, pz);
        Vector3 Position = new Vector3 (randomX,randomY,randomZ);
        new_Obus.transform.localPosition = Position;
    }
}
