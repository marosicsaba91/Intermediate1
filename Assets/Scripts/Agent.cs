using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour, IPoolable
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;
	[SerializeField] int agentValue = 10;
	[SerializeField] int agentDamage = 1;
	[SerializeField] Elemental[] immunities;
	[SerializeField] Vector3 localAimingPoint;

	static List<Agent> agents = new ();
	public static IReadOnlyList<Agent> Agents => agents;

	void OnEnable() => agents.Add(this);
	void OnDisable() => agents.Remove(this);



	float health;

	public event Action HealthChanged;

	public Vector3 AimingPoint => transform.TransformPoint(localAimingPoint);

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(AimingPoint, 0.15f);		
	}

	public float HealthRate
    {
        get => health / startHealth;
        private set => health = value * startHealth;
    }
	public GameObject Prefab { get; set; }

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
		Pool.Push(Prefab, gameObject);
		Destroy(gameObject);
	}

	public void Damage(float damage, Elemental elemental = null)
	{
		if (elemental != null && immunities.Contains(elemental)) 
		{
			damage *= elemental.multiplier;
		}

		health -= damage;

        HealthChanged?.Invoke();

        if (health <= 0)
        {
			GameManager.instance.Money += agentValue;
		Pool.Push(Prefab, gameObject);
        }
    }

	public bool IsImmune(Elemental elemental) => immunities.Contains(elemental);
}
