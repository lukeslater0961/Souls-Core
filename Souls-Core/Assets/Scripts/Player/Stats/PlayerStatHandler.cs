using UnityEngine;
using System;

public class PlayerStatHandler : BaseStatsHandler
{
#region values
	private float staminaRate = 20f;
	public  float jumpCost { get; private set; } = 10f;
	public  float sprintCost {get ; private set;} = 5f;

	float	regenDelay = 10f;
	float   regenTimer = 0f;
	float	exhaustThreshold = 0.1f;
	bool	isExhausted;

	public enum Stamina{
		Jump,
		Sprint
	};
#endregion

#region Events
	public static event Action<float> OnHealthUpdated;
	public static event Action<float> OnStaminaUpdated;
#endregion


	public void GiveHealth()
	{
		_stats.health = _stats.maxHealth;
		OnHealthUpdated?.Invoke(_stats.health);
	}

	public void TakeDamage(float amount)
	{
		_stats.health = Mathf.Clamp(_stats.health - amount, 0, _stats.maxHealth);
		OnHealthUpdated?.Invoke(_stats.health);
	}

	public bool HasEnoughStamina()
	{
		if (isExhausted)
			return false;

		return _stats.stamina >= sprintCost * Time.deltaTime;
	}

	public void SpendStamina(float amount)
	{
		_stats.stamina = Mathf.Clamp(_stats.stamina - amount * Time.deltaTime, 0, _stats.maxStamina);
		OnStaminaUpdated?.Invoke(_stats.stamina);

		regenTimer = 0f;
		if (_stats.stamina <= exhaustThreshold)
			isExhausted = true;
	}

	public void RegenStamina()
	{
		if (_stats.stamina >= _stats.maxStamina) return;

		_stats.stamina = Mathf.Clamp(_stats.stamina + staminaRate * Time.deltaTime, 0, _stats.maxStamina);
		OnStaminaUpdated?.Invoke(_stats.stamina);
		regenTimer += Time.deltaTime;

		if (regenTimer > regenDelay)
			isExhausted = false;
	}
}
