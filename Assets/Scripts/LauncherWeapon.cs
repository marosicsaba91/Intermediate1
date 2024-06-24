using UnityEngine;

public class LauncherWeapon : PeriodicWeapon
{
	[SerializeField] Projectile projectilePrefab;
	[SerializeField] Aimer aimer;

	void OnValidate()
	{
		if (aimer == null)
			aimer = GetComponentInChildren<Aimer>();
	}

	protected override void Fire()
	{
		Vector3 direction = aimer.GetDirection(Target);
		Quaternion rotation = Quaternion.LookRotation(direction);
		Vector3 position = aimer.StartPoint;
		GameObject pGo = Pool.Pop(projectilePrefab.gameObject, position, rotation, transform);
		pGo.GetComponent<Projectile>().Setup(this);
	}
}
