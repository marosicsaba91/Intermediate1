using System;
using UnityEngine;

public abstract class Drawable : MonoBehaviour 
{
	[SerializeField] LineRenderer lineRenderer;
	[SerializeField] float sizeMultiplier;

	void OnValidate()
	{
		if (lineRenderer == null)
			lineRenderer = GetComponent<LineRenderer>();

		UpdateLinePoints();
	}

	void Start()
	{
		UpdateLinePoints();
	}

	public void UpdateLinePoints()
	{
		if (lineRenderer == null) return;
		Vector3[] points = ModifyPositions();
		lineRenderer.positionCount = points.Length;
		lineRenderer.SetPositions(points);
	}

	protected abstract Vector3[] GetPositions();
	Vector3[] ModifyPositions() 
	{
		Vector3[] points = GetPositions();
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = points[i] * sizeMultiplier;
		}
		return points;
	}

	void OnDrawGizmosSelected()
	{
		Vector3[] points = ModifyPositions();

		for (int i = 0; i < points.Length - 1; i++)
		{
			int i2 = i + 1;
			Vector3 p1 = points[i];
			Vector3 p2 = points[i2];
			Gizmos.DrawLine(p1, p2);
		}
	}
}