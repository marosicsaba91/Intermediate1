using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDeffense/ComplexWave")]

public class ComplexWave : Wave
{
	[SerializeField] Wave[] waves;
	[SerializeField] float delay;

	public override IEnumerator StartWave(Transform tower)
	{
		foreach (Wave wave in waves)
		{
			yield return new WaitForSeconds(delay);
			yield return wave.StartWave(tower);
		}
	}
}