using UnityEngine;

public class AudioEffectPlayer : MonoBehaviour, IWeaponEffect
{
	[SerializeField] AudioSource source;
	[SerializeField] WeaponEvent effectType;

	public void PlayEffect(WeaponEvent weaponEvent)
	{
		if(weaponEvent == effectType)
			source.Play();
	}
}
