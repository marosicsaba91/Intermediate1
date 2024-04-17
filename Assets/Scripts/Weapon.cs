using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[SerializeField] TargetP targetProvider;
	protected Agent Target => targetProvider.GetTarget();

	void Update()
	{
		ChildUpdate();
	}

	protected virtual void ChildUpdate() { }
}