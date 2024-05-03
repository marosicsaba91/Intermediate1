using System;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] new Camera camera;
	[SerializeField, Range(0,360)] float yaw = 45;
	[SerializeField, Range(-90, 90)] float pitch = 45;
	[SerializeField, Range(-90, 90)] float roll = 0;
	[SerializeField] float cameraHeight = 10;
	[SerializeField] float rotationSpeed = 100;
	[SerializeField] float minPitch = 10;
	[SerializeField] float maxPitch = 80;

	[SerializeField] float smoothTime = 0.5f;

	Vector3 targetPoint;
	Vector3 velocity;

	void Start()
	{
		targetPoint = target.position;
		UpdateCamera(targetPoint);
	}

	void LateUpdate()
	{
		if (target == null) return;
		if (camera == null) return;

		HandleInput();
		HandleTarget();
		UpdateCamera(targetPoint);
	}
	void HandleInput()
	{
		float inputX = Input.GetAxis("Mouse X");
		float inputY = Input.GetAxis("Mouse Y");
		yaw += inputX * rotationSpeed * Time.deltaTime;
		pitch -= inputY * rotationSpeed * Time.deltaTime;
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
		yaw %= 360;
		if (yaw < 0)
			yaw += 360;
	}

	void HandleTarget() 
	{
		targetPoint = Vector3.SmoothDamp(
			targetPoint,
			target.position, 
			ref velocity, 
			smoothTime);
	}

	void UpdateCamera(Vector3 targetPoint)
	{
		float fov = camera.fieldOfView;
		float distance = cameraHeight / 2 / Mathf.Tan(fov * Mathf.Deg2Rad / 2);

		Quaternion rotation = Quaternion.Euler(pitch, yaw, roll);
		Vector3 direction = rotation * Vector3.forward;
		Vector3 position = targetPoint - direction * distance;

		transform.SetPositionAndRotation(position, rotation);
	}

}
