using UnityEngine;

public abstract class PeriodicWeapon : Weapon
{
	[SerializeField] float fireRate = 1;

	float lastFireTime;
	protected virtual void Update() 
	{
		if (Target == null) return;

		if (Time.time - lastFireTime >= (1 / fireRate))
		{
			Fire();
			PlayEffect(WeaponEvent.Shoot);

			lastFireTime = Time.time;
		}
	}

	protected abstract void Fire();
}
