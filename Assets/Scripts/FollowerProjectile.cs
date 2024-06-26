using UnityEngine;

public class FollowerProjectile : Projectile, IPoolable
{
	[SerializeField] float damage = 10;
	[SerializeField] float speed = 10;
	[SerializeField] Elemental elemental;

	Agent target;

	public GameObject Prefab { get; set; }

	public override void Setup(LauncherWeapon launcher)
	{
		Aimer aimer = launcher.GetComponent<Aimer>();
		target = launcher.GetComponent<TargetProvider>().GetTarget();
		transform.position = aimer.StartPoint;
	}

	void Update()
	{
		if (target == null)
		{
			Pool.Push(Prefab, gameObject);
			return;
		}

		Vector3 tp = target.AimingPoint;
		transform.position = Vector3.MoveTowards(
			transform.position, tp, speed * Time.deltaTime);

		if (transform.position == tp)
		{
			target.Damage(damage, elemental);
			Pool.Push(Prefab, gameObject);
		}
	}
}
