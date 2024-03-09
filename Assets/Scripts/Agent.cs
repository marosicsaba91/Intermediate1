using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;

    float health;

    public event Action HealthChanged;

    public float HealthRate
    {
        get => health / startHealth;
        private set => health = value * startHealth;
    }
    
    void OnValidate()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        EndPoint ep = FindObjectOfType<EndPoint>();
        navMeshAgent.destination = ep.transform.position;
        HealthRate = 1;
        HealthChanged?.Invoke();
    }

    public void OnHitEndPoint()
    {
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        health -= damage;

        HealthChanged?.Invoke();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
