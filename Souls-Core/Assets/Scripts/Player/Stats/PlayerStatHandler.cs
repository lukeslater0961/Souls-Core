using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
#region References
	[SerializeField] private PlayerStats _stats;
#endregion

#region values
	private float staminaRate = 1f;

	public enum Stamina{
		Jump,
		Sprint
	};
#endregion

    void Start()
    {
        _stats = GetComponent<PlayerStats>();
    }

	public void TakeDamage()
	{

	}

	public void SpendStamina(float amount)
	{
		
	}

	public void RegenStamina()
	{
		_stats.stamina = Mathf.Clamp(_stats.stamina + staminaRate * Time.deltaTime, 0, _stats.maxStamina);
	}
}
