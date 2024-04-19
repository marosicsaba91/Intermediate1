using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[SerializeField] TargetProvider targetProvider;
	protected Agent Target => targetProvider.GetTarget();

	void Update()
	{
		ChildUpdate();
	}

	protected virtual void ChildUpdate() { }
}