using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] float damageRate = 10;

	[SerializeField] LineRenderer lineRenderer;
	[SerializeField, Min(2)] int laserPointCount = 10; 

    Agent closest = null;

	protected virtual void Update()
	{
        if (closest != null)
            closest.Damage(damageRate * Time.deltaTime);

		UpdateLaserVisual();
    }

	void UpdateLaserVisual()
	{
		lineRenderer.enabled = closest != null;
		if (closest == null) return;

		lineRenderer.positionCount = laserPointCount;
		Vector3 a = transform.position;
		Vector3 b = closest.AimingPoint;
		Vector3 step = (b - a) / (laserPointCount - 1);

		for (int i = 0; i < laserPointCount; i++)
		{
			lineRenderer.SetPosition(i, a);
			a += step;
		}
	}
}