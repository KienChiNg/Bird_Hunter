using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float spawnTime;
    float m_spawnTime;
    public Bird[] m_bird;
    bool m_gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        // SpawnBird();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn()
    {
        while (!m_gameOver)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnBird()
    {
        // m_spawnTime -= Time.deltaTime;
        Vector3 spawnPos = Vector3.zero;
        float randCheck = Random.Range(0f, 1f);
        // Debug.Log(randCheck);
        if (randCheck >= 0.5f)
        {
            // Debug.Log("Covaodaykhong " + Random.Range(-3,Random.Range(1.5f,4f)));
            spawnPos = new Vector3(12, Random.Range(-1.5f, 4f), 0);
        }
        else
        {
            spawnPos = new Vector3(-12, Random.Range(-1.5f, 4f), 0);

        }
        Instantiate(m_bird[Random.Range(0, m_bird.Length)], spawnPos, Quaternion.identity);
    }
}
