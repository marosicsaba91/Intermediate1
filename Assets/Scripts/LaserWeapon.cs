using System;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] float range = 2;
    [SerializeField] float damageRate = 10;

	[SerializeField] LineRenderer lineRenderer;
	[SerializeField, Min(2)] int laserPointCount = 10; 

    Agent closest = null;

    void Update()
    {
        if (closest != null && !IsInRange(closest))
            closest = null;

        if (closest == null)
            closest = FindClosestAgentInRange();

        if (closest != null)
            closest.Damage(damageRate * Time.deltaTime);

		UpdateLaserVisual();
    }

    Agent FindClosestAgentInRange()
    {
        Agent[] allAgents = FindObjectsOfType<Agent>();

        Vector3 p = transform.position;
        float minDistance = float.MaxValue;
        Agent closest = null;

        foreach (Agent agent in allAgents)
        {
            float distance = Vector3.Distance(agent.transform.position, p);
            if (distance > range) continue;
            if (distance > minDistance) continue;

            minDistance = distance;
            closest = agent;
        }

        return closest;
    }

    bool IsInRange(Agent agent)
    {
        Vector3 p = transform.position;
        float distance = Vector3.Distance(agent.transform.position, p);
        return distance <= range;
	}

	void UpdateLaserVisual()
	{
		lineRenderer.enabled = closest != null;
		if (closest == null) return;

		lineRenderer.positionCount = laserPointCount;
		Vector3 a = transform.position;
		Vector3 b = closest.transform.position;
		Vector3 step = (b - a) / (laserPointCount - 1);

		for (int i = 0; i < laserPointCount; i++)
		{
			lineRenderer.SetPosition(i, a);
			a += step;
		}
	}

	void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (closest != null)
            Gizmos.DrawLine(closest.transform.position, transform.position);
    }
}