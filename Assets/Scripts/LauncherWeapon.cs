using System;
using UnityEngine;

public class LauncherWeapon : PeriodicWeapon
{
	[SerializeField] Projectile projectilePrefab;

	protected override void Fire()
	{
		// Projectile p = Instantiate(projectilePrefab, transform);
		GameObject pGo = Pool.Pop(projectilePrefab.gameObject, transform);

		pGo.GetComponent<Projectile>().Setup(this);
	}
}
