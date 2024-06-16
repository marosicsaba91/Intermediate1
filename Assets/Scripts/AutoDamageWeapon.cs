using UnityEngine;

public class AutoDamageWeapon : PeriodicWeapon
{
	[SerializeField] float damage;

	protected override void Fire()
	{
		if(Target != null)
			Target.Damage(damage);
	}
}