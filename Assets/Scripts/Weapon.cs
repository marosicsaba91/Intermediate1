using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[SerializeField] TargetProvider targetProvider;

	protected Agent Target => targetProvider.GetTarget();

	public void PlayEffect(WeaponEvent weaponEvent)
	{
		IWeaponEffect[] allEffectPlayer = GetComponentsInChildren<IWeaponEffect>();
		foreach (IWeaponEffect player in allEffectPlayer)
			player.PlayEffect(weaponEvent);
	}
}