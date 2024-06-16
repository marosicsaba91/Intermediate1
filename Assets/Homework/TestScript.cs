using UnityEngine;

public class HumanClass
{
	public string name;
	public int age;
	public bool isFemale;

	public void AgeHuman(int years)
	{
		age += years;
	}
}

public struct HumanStruct
{
	public string name;
	public int age;
	public bool isFemale;

	public void AgeHuman(int years)
	{
		age += years;
	}
}

public class TestScript : MonoBehaviour
{
	void Start()
	{
		int a = 1;     // Ért 
		int b = a;
		b++;
		Debug.Log(a);  // 1
		AddTwo(a);
		Debug.Log(a);  // 1


		// ----------------

		int[] c = { 1, 2, 3 };   // Ref
		int[] d = c;
		d[0]++;
		Debug.Log(c[0]);  // 		
	}

	int AddTwo(int num)
	{
		num += 2;
		return num;
	}
}