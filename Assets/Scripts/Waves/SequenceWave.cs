using System;
using System.Collections;
using UnityEngine;

[Serializable]
struct DelayedSpawn
{
	public GameObject prefab;
	public float delay;
}

[CreateAssetMenu(menuName = "TowerDeffense/SequenceWave")]
public class SequenceWave : Wave
{
	[SerializeField] DelayedSpawn[] spawns;

	public override IEnumerator StartWave(Transform tower)
	{
		foreach (DelayedSpawn spawn in spawns)
		{
			yield return new WaitForSeconds(spawn.delay);
			Instantiate(spawn.prefab, tower.position, tower.rotation, tower);
		}
	}
}