using UnityEngine;

public class BallisticProjectile : Projectile
{
	[SerializeField] Rigidbody rigidBody;

	public override void Setup(LauncherWeapon launcher)
	{
		Aimer aimer = launcher.GetComponent<Aimer>();
		TargetProvider tp = launcher.GetComponent<TargetProvider>();

		Vector3 velocity = aimer.GetDirection(tp.GetTarget());
		rigidBody.velocity = velocity;
		rigidBody.rotation = Quaternion.LookRotation(velocity);
		rigidBody.position = aimer.StartPoint;		
	}

	void FixedUpdate()
	{
		rigidBody.rotation = Quaternion.LookRotation(rigidBody.velocity);
	}
}
