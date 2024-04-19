using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
	[SerializeField] Agent[] agentPrefabs;
	[SerializeField] int count = 10;
	[SerializeField] float duration = 1;

	[SerializeField] LineRenderer lineRenderer;


	void Start()
	{
		StartCoroutine(SpawnAll());

		NavMeshPath path = new();

		NavMeshAgent navMeshAgent = agentPrefabs[0].GetComponent<NavMeshAgent>();
		EndPoint endPoint = FindAnyObjectByType<EndPoint>();
		Debug.Log(navMeshAgent.areaMask);
		NavMesh.CalculatePath(transform.position, endPoint.transform.position, navMeshAgent.areaMask, path);
		lineRenderer.positionCount = path.corners.Length;
		lineRenderer.SetPositions(path.corners);

		Vector3 global = transform.localToWorldMatrix.MultiplyPoint(Vector3.zero);
		Vector3 local = transform.worldToLocalMatrix.MultiplyPoint(transform.position);

		Debug.Log(global);
		Debug.Log(local);
		Debug.Log(transform.localToWorldMatrix);
		Debug.Log(transform.worldToLocalMatrix);
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
		int randomIndex = Random.Range(0, agentPrefabs.Length);
		Agent agentPrefab = agentPrefabs[randomIndex];
		Agent agent = Instantiate(agentPrefab, transform.position, transform.rotation, transform);
	}
}
