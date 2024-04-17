using System;
using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] float damageRate = 10;

	[SerializeField] LineRenderer lineRenderer;
	[SerializeField, Min(2)] int laserPointCount = 10; 

    protected override void ChildUpdate()
    {
        if (Target != null)
            Target.Damage(damageRate * Time.deltaTime);

		UpdateLaserVisual();
    }

	void UpdateLaserVisual()
	{
		lineRenderer.enabled = Target != null;
		if (Target == null) return;

		lineRenderer.positionCount = laserPointCount;
		Vector3 a = transform.position;
		Vector3 b = Target.transform.position;
		Vector3 step = (b - a) / (laserPointCount - 1);

		for (int i = 0; i < laserPointCount; i++)
		{
			lineRenderer.SetPosition(i, a);
			a += step;
		}
	}
}