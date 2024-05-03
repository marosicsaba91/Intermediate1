
using UnityEngine;

public class ParticleEffectPlayer : MonoBehaviour, IWeaponEffect
{
	[SerializeField] new ParticleSystem particleSystem;
	[SerializeField] WeaponEvent effectType;
	public void PlayEffect(WeaponEvent weaponEvent)
	{
		if (weaponEvent == effectType)
			particleSystem.Play();
	}
}