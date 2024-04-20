using UnityEditor.PackageManager;
using UnityEngine;

public class ElementalTargetProvider : TargetProvider
{
	[SerializeField] Elemental elemental;

	public override Agent GetTarget() 
	{
		foreach (Agent agent in Agent.Agents)
		{
			if (!agent.IsImmune(elemental))
				return agent;
		}

		return null;
	}
}