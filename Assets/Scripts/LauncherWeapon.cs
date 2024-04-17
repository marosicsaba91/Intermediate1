using UnityEngine;

public class LauncherWeapon : PeriodicWeapon
{
	[SerializeField] Projectile projectilePrefab;

	protected override void Fire() 
	{
		Projectile p = 
			Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);

		p.Setup(Target);
	}
}
