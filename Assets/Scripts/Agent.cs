using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;
	[SerializeField] int agentValue = 10;
	[SerializeField] int agentDamage = 1;

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
		GameManager.instance.Damage(agentDamage);
		Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        health -= damage;

        HealthChanged?.Invoke();

        if (health <= 0)
        {
			GameManager.instance.Money += agentValue;
            Destroy(gameObject);
        }
    }
}
