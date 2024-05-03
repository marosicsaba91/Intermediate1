using UnityEngine;

public class MemoryAllocTest : MonoBehaviour
{
	static Collider[] colliders = new Collider[25];

	void Update()
	{
		Vector3[] array = new Vector3[1000];
		Transform[] array2 = FindObjectsOfType<Transform>();

		//-----------------------------
		int count = Physics.OverlapSphereNonAlloc(transform.position, 3, colliders);
		for (int i = 0; i < count; i++)
		{
			Collider c = colliders[i];
		}
	}
}

