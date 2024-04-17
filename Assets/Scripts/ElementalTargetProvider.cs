using UnityEngine;

public class ElementalTargetProvider : TargetP
{
	[SerializeField] Elemental elemental;

	public override Agent GetTarget() 
	{
		foreach (Agent agent in FindObjectsOfType<Agent>())
		{
			if (!agent.IsImmune(elemental))
				return agent;
		}

		return null;
	}
}
