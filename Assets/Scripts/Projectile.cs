using UnityEngine;

public class Projectile : MonoBehaviour
{

	[SerializeField] float damage = 10;
	[SerializeField] float speed = 10;
	[SerializeField] Elemental elemental;

	Agent target;

	public void Setup(Agent target)
    {
		this.target = target;
    }

	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 tp = target.transform.position;
		transform.position = Vector3.MoveTowards(
			transform.position, tp, speed * Time.deltaTime);

		if (transform.position == tp) 
		{
			target.Damage(damage, elemental);
			Destroy(gameObject);
		}
	}
}
