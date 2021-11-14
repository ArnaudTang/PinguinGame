using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObusCreator : MonoBehaviour
{
    GameObject bombContainer;
    GameObject m_plane;
    GameObject m_player;
    GameObject objects;

    ScoreSetter scoreSetter;

    bool hasSpawned = false;

    [SerializeField] GameObject[] toSpawn;
    [SerializeField] int spawn_step = 3;

    [SerializeField] GameObject obus;
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject player;
    [SerializeField] float px = 3000f;
    [SerializeField] float py = 1f;
    [SerializeField] float pz = 50f;


    protected float score; //Score = Distance parcourus en X
    protected float bestScore = 0f; //Score = Distance parcourus en X

    int count_spawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_plane = Instantiate(terrain);
        terrain.transform.localScale = new Vector3(px, py, pz);
        terrain.transform.position = new Vector3(px / 2, 0, pz / 2);
        m_plane.transform.SetParent(gameObject.transform);

        Material mat = Resources.Load("Grass") as Material;
        m_plane.GetComponent<MeshRenderer>().materials[0] = mat;        

        StartGame();
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
            float randomX = Random.Range(Mathf.Max(pos_player - 10, 15), px);
            float randomY = Random.Range(80, 100);
            float randomZ = Random.Range(3, pz - 3);
            Vector3 Position = new Vector3(randomX, randomY, randomZ);
            new_Obus.transform.localPosition = Position;
            new_Obus.transform.SetParent(bombContainer.transform);      
        }

        if (m_player.transform.position.z < 0) {
            m_player.transform.position= new Vector3(m_player.transform.position.x, m_player.transform.position.y, 0);
         }
        if (m_player.transform.position.z > 50) {
            m_player.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, 50);
        }

        if (m_player.transform.position.x < 0) {
            m_player.transform.position = new Vector3(0, m_player.transform.position.y, m_player.transform.position.z);
        }

        if (m_player.transform.position.x > score) {
            score = m_player.transform.position.x;
            if(score > bestScore) { bestScore = score; }
            scoreSetter.setScore(score, bestScore);
        }



    }

    public void StartGame()
    {
        Debug.Log("Start game");

        if(hasSpawned)
        {
            Destroy(m_player);
            Destroy(bombContainer);
            Destroy(objects);
        }

        score = 0f;
        hasSpawned = true;
        bombContainer = new GameObject("BombContainer");
        m_player = Instantiate(player);
        m_player.transform.Rotate(new Vector3(0, 90, 0));
        m_player.transform.position = new Vector3(10, 3, pz / 2);
        scoreSetter = FindObjectOfType<ScoreSetter>();

        float pos_y = 0f;

        objects = new GameObject("objects");

        for (int i = 10; i <= px; i = i + spawn_step)
        {
            float randomZ = Random.Range(2, pz - 2);
            int randomIndex = Mathf.FloorToInt(Random.Range(0, toSpawn.Length));
            GameObject new_obj = Instantiate(toSpawn[randomIndex]);
            Vector3 position = new Vector3(i, pos_y, randomZ);
            new_obj.transform.localPosition = position;
            new_obj.tag = "Terrain";
            new_obj.transform.SetParent(objects.transform);
        }
    }
}
