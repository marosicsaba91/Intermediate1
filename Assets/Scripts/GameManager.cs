using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] int startLives = 100;
	[SerializeField] int startMoney = 100;

	public static GameManager instance;

	void Awake()
	{
		instance = this;
	}

	float gameTime;
	int lives;
	int money;

	public int Money
	{
		get => money;
		set
		{
			money = Mathf.Max(0, value);
			Debug.Log($"Money: {money}");
		}
	}

	void Start()
	{
		lives = startLives;
		money = startMoney;
	}

	public void Damage(int damage) 
	{
		lives -= damage;
		Debug.Log($"Gamer Lives: {lives}");

		if (lives <= 0) 
		{
			Debug.Log("Game Over");
		}
	}
}
