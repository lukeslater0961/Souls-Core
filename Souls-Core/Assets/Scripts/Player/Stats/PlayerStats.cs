using UnityEngine;

public class PlayerStats : BaseStats
{
#region	ScriptableObjects
	[SerializeField]	PlayerStatsSO ps;
#endregion

#region local stats
	public float sprintSpeed;
	public float sensitivity;
	public float jumpForce;
	public float rotationSpeed;
#endregion

    void Start()
    {
		rotationSpeed = ps.rotationSpeed;
		jumpForce = ps.jumpForce;
		sensitivity = ps.sensitivity;

		health = ps.maxHealth;
		maxHealth = ps.maxHealth;

		stamina = ps.maxStamina;
		maxStamina = ps.maxStamina;

		sprintSpeed = ps.sprintSpeed;
        speed = ps.speed;
    }
}
