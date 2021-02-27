using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    static GameFlowManager m_instance = null;
    public static GameFlowManager Instance { get { return m_instance; } }

    public GameObject GameOverCanvas;
    public float SpawnDelay = 2;

    public EnemySpawn m_enemySpawn;
    private bool gameIsEnd = false;

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else
            Destroy(this);
    }

    
    void Start()
    {
        //m_enemySpawn = GetComponent<EnemySpawn>();
        if (!gameIsEnd && m_enemySpawn)
            Invoke("StartSpawn", SpawnDelay);
    }

    void Update()
    {
        if (gameIsEnd && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void StartSpawn()
    {
        m_enemySpawn?.StartSpawn();
    }

    public void GameOver()
    {
        m_enemySpawn?.StopSpawn();
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in Enemies)
            Destroy(e);
        GameOverCanvas.SetActive(true);
        gameIsEnd = true;
        Debug.Log("Game Over");
    }
}
