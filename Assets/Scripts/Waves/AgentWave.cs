using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDeffense/AgentWave")]

public class AgentWave : Wave
{
	[SerializeField] GameObject agentPrefabs;
	[SerializeField] int count = 10;
	[SerializeField] float delay;

	public override IEnumerator StartWave(Transform tower)
	{
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(delay);
			Instantiate(agentPrefabs, tower.position, tower.rotation, tower);
		}
	}
}