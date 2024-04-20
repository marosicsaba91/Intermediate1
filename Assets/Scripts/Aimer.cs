using UnityEngine;

public abstract class Aimer : MonoBehaviour
{
	[SerializeField] Transform verticalRotatable;
	[SerializeField] Transform horizontalRotatable;
	[SerializeField] Vector3 localStartPoint;

	[SerializeField] TargetProvider targetProvider;
	[SerializeField] float angularSpeed = 360;

	public Vector3 StartPoint => transform.TransformPoint(localStartPoint);

	void OnValidate()
	{
		if (targetProvider == null)
			targetProvider = GetComponentInChildren<TargetProvider>();
	}

	public abstract Vector3 GetDirection(Agent target);

	void Update()
	{
		Agent target = targetProvider.GetTarget();
		if (target == null) return;

		Vector3 direction = GetDirection(target);
		Quaternion targetRotation = Quaternion.LookRotation(direction);

		Vector3 currentEuler = Vector3.zero;
		if (verticalRotatable != null)
			currentEuler.x = verticalRotatable.rotation.eulerAngles.x;
		if (horizontalRotatable != null)
			currentEuler.y = horizontalRotatable.rotation.eulerAngles.y;
		Quaternion currentRotation = Quaternion.Euler(currentEuler);

		Quaternion rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularSpeed * Time.deltaTime);
		Vector3 euler = rotation.eulerAngles;


		if (verticalRotatable != null)
		{
			Vector3 verticalEuler = verticalRotatable.rotation.eulerAngles;
			verticalEuler.x = euler.x;
			verticalRotatable.rotation = Quaternion.Euler(verticalEuler);
		}

		if (horizontalRotatable != null)
		{
			Vector3 horizontalEuler = horizontalRotatable.rotation.eulerAngles;
			horizontalEuler.y = euler.y;
			horizontalRotatable.rotation = Quaternion.Euler(horizontalEuler);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(StartPoint, 0.1f);
	}
}
