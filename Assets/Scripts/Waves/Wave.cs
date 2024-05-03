using System.Collections;
using UnityEngine;

public abstract class Wave : ScriptableObject
{
	public abstract IEnumerator StartWave(Transform tower);
}
