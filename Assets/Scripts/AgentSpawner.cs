using System;
using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] Agent agentPrefab;
    [SerializeField] int count = 10;
    [SerializeField] float duration = 1;

    void Start()
    {
        StartCoroutine(SpawnAll());
    }

    IEnumerator SpawnAll() 
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(duration);
            Spawn();
        }
    }

    void Spawn()
    {
        Agent agent = Instantiate(agentPrefab, transform.position, transform.rotation, transform);
    }
}
