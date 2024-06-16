using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPractice : MonoBehaviour
{
	[SerializeField] Cell[,] map;

    void Start()
    {
		int[] array = new int[10];
		List<int> list = new (100);     // Kapacitás
		LinkedList<int> linked = new();
		Queue<int> queue = new();
		Stack<int> stack = new();
		HashSet<int> hashSet = new();

		//---------------------------

		Debug.Log(list.Count);   // 0
		list.Add(99);
		list.Add(99);
		list.Add(99);
		list.Add(99);
		list.Add(99);
		Debug.Log(list.Count);    // 5
		Debug.Log(list.Capacity); // 100


		queue.Enqueue(12);
		int first = queue.Dequeue();

		stack.Push(33);
		int last = stack.Peek();   // Nem csökken a kollekció
		last = stack.Pop();        // Ki is vesszük

		hashSet.Add(22);
		hashSet.Add(32);
		hashSet.Add(252);
		hashSet.Add(99);
		hashSet.Add(22);

		Debug.Log(hashSet.Count);  // 4

		// ---------------------------

		Dictionary<string, Vector3> dictionary = new();

		dictionary.Add("Origin", Vector3.zero);
		dictionary.Add("Right", Vector3.right);
		dictionary.Add("Up", Vector3.up);

		Vector3 v1 = dictionary["Right"];
		Vector3 v2 = dictionary["Back"];   // Exception

		if (dictionary.ContainsKey("Forward"))         // Konstans idejû keresés
		{
			Vector3 v3 = dictionary["Forward"];
			Debug.Log(v3);
		}

		if(dictionary.TryGetValue("Forward", out Vector3 dvalue))    // Ugyanaz, csak gyorsabb
			Debug.Log(dvalue);


		if (dictionary.ContainsValue(Vector3.forward)) // Lineáris idejû keresés
		{
			Vector3 v3 = dictionary["Forward"];
		}

		foreach (string key in dictionary.Keys) { }
		foreach (Vector3 value in dictionary.Values) { }
		foreach (KeyValuePair<string, Vector3> kvp in dictionary) 
		{
			Debug.Log($"Key: {kvp.Key}    Value: {kvp.Value}");
		}

		foreach ((string key, Vector3 value) in dictionary)   // Jobb
		{
			Debug.Log($"Key: {key}    Value: {value}");
		}

		// ------------------------------------------

		int[,] ints = new int[10,10]; 

	}
}

enum CellBase { Road, None }
enum Content { Tower1, Tower2, Tower3 }

[Serializable]
struct Cell
{
	public CellBase cellBase;
	public Content content;
}