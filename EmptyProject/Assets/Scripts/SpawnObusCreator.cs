using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObusCreator : MonoBehaviour
{
    GameObject m_plane;
    GameObject m_player;

    [SerializeField] GameObject obus;
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject player;
    [SerializeField] float px = 3000f;
    [SerializeField] float py = 1f;
    [SerializeField] float pz = 50f;

    int count_spawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_plane = Instantiate(terrain);
        m_plane.transform.localScale = new Vector3(px, py, pz);
        m_plane.transform.position = new Vector3(px/2, 0, pz/2);
        m_plane.transform.SetParent(gameObject.transform);

        m_player = Instantiate(player);
        m_player.transform.Rotate(new Vector3(0, 90, 0));
        m_player.transform.position = new Vector3(10, 3, pz/2);
    }

    // Update is called once per frame
    void Update()
    {
        count_spawn++;

        float pos_player = m_player.transform.position.x;

        if (count_spawn == 1)
        {
            count_spawn = 0;
            GameObject new_Obus = Instantiate(obus);
            new_Obus.tag = "Obus";
            float randomX = Random.Range(Mathf.Max(pos_player - 10, 15), pos_player + 500);
            float randomY = Random.Range(80, 100);
            float randomZ = Random.Range(5, pz - 5);
            Vector3 Position = new Vector3(randomX, randomY, randomZ);
            new_Obus.transform.localPosition = Position;
        }
    }
}
