using System.Collections.Generic;
using UnityEngine;

interface IPoolable
{
	GameObject Prefab { get; set; }
}


static class Pool
{
	static Dictionary<GameObject, Stack<GameObject>> sleepers = new();

	public static GameObject Pop(GameObject prefab, Transform parent)
	{
		GameObject poppedObject = Pop(prefab);
		poppedObject.transform.parent = parent;
		return poppedObject;
	}

	public static GameObject Pop(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
	{
		GameObject poppedObject = Pop(prefab);
		poppedObject.transform.parent = parent;
		poppedObject.transform.SetPositionAndRotation(position, rotation);
		return poppedObject;
	}

	public static GameObject Pop(GameObject prefab)
	{
		Stack<GameObject> stack;
		if (!sleepers.TryGetValue(prefab, out stack) || stack.Count == 0)
		{
			GameObject newGo = Object.Instantiate(prefab);
			foreach (IPoolable poolable in newGo.GetComponents<IPoolable>())
				poolable.Prefab = prefab;

			return newGo;
		}
		else
			return stack.Pop();
	}

	public static void Push(GameObject prefab, GameObject item)
	{
		Stack<GameObject> stack;
		if (!sleepers.TryGetValue(prefab, out stack))
		{
			stack = new Stack<GameObject>();
			sleepers.Add(prefab, stack);
		}

		stack.Push(item);
	}
}