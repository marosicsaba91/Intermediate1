using UnityEngine;

public class GravityModifier : MonoBehaviour
{
	[SerializeField] Vector3 gravity;

	public Vector3 Gravity => gravity;

	void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out Rigidbody rigidbody)) 
		{
			rigidbody.velocity += gravity * Time.fixedDeltaTime;
		}
	}
}
