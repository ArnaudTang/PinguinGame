using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObusCreator : MonoBehaviour
{
    GameObject bombContainer;
    GameObject m_plane;
    GameObject m_player;
    GameObject trees;

    ScoreSetter scoreSetter;

    bool hasSpawned = false;

    [SerializeField] GameObject obus;
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tree;
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
        m_plane.transform.localScale = new Vector3(px, py, pz);
        m_plane.transform.position = new Vector3(px/2, 0, pz/2);
        m_plane.transform.SetParent(gameObject.transform);
        trees = new GameObject("trees");

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
            float randomZ = Random.Range(2, pz - 2);
            Vector3 Position = new Vector3(randomX, randomY, randomZ);
            new_Obus.transform.localPosition = Position;
            new_Obus.transform.SetParent(bombContainer.transform);
           
            
            //float tree_pos_x = 20f;
            float tree_pos_y = 1.5f;
            float left_tree_pos_z = -10f;
            float right_tree_pos_z = 60f;
            
            
            for (int i = 0; i <= px; i = i + 200) 
            {
                GameObject new_left_tree = Instantiate(tree);
                GameObject new_right_tree = Instantiate(tree);
                Vector3 right_tree_position = new Vector3(i, tree_pos_y, right_tree_pos_z);
                Vector3 left_tree_position = new Vector3(i, tree_pos_y, left_tree_pos_z);
                new_right_tree.transform.localPosition = right_tree_position;
                new_left_tree.transform.localPosition = left_tree_position;
                new_left_tree.transform.SetParent(trees.transform);
                new_right_tree.transform.SetParent(trees.transform);
            }
            
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
        }

        score = 0f;
        hasSpawned = true;
        bombContainer = new GameObject("BombContainer");
        m_player = Instantiate(player);
        m_player.transform.Rotate(new Vector3(0, 90, 0));
        m_player.transform.position = new Vector3(10, 3, pz / 2);
        scoreSetter = FindObjectOfType<ScoreSetter>();
    }
}
