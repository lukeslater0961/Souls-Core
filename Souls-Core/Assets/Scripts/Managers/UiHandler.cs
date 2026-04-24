using UnityEngine;
using System;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
	[SerializeField] Slider healthSlider;
	[SerializeField] Slider healthEaseSlider;

	[SerializeField] Slider staminaSlider;

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

	void FixedUpdate()
	{
		if (healthEaseSlider.value != healthSlider.value)
			healthEaseSlider.value = Mathf.Lerp(healthEaseSlider.value, healthSlider.value, 0.05f);
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
