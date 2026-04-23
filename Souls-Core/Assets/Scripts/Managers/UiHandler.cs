using UnityEngine;
using System;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
	[SerializeField] Slider healthSlider;
	[SerializeField] Slider healthEaseSlider;

	[SerializeField] Slider staminaSlider;
	[SerializeField] Slider staminaEaseSlider;

    void Start()
    {
        PlayerStatHandler.OnStaminaUpdated += UpdateStamina;
		PlayerStatHandler.OnHealthUpdated += UpdateHealth;
    }

	void OnDestroy()
	{
		PlayerStatHandler.OnStaminaUpdated -= UpdateStamina;
		PlayerStatHandler.OnHealthUpdated -= UpdateHealth;
	}

	void UpdateHealth(float health)
	{
		if (healthSlider.value != health)
			healthSlider.value = health;
	}

	void UpdateStamina(float stamina)
	{
		if (staminaSlider.value != stamina)
			staminaSlider.value = stamina;
	}
}
