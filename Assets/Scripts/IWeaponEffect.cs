
public enum WeaponEvent { Shoot, Reload, FoundTarget, LostTarget, StartShooting, StopShooting }

public interface IWeaponEffect 
{
	void PlayEffect(WeaponEvent weaponEvent);
}