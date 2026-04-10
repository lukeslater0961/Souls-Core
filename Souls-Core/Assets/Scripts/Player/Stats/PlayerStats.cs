using UnityEngine;

public class PlayerStats : MonoBehaviour
{
#region	ScriptableObjects
	[SerializeField]	PlayerStatsSO ps;
#endregion

#region local stats
	public float speed;
	public float sprintSpeed;

	public float stamina;
	public float maxStamina;

	public float health;
	public float maxHealth;

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

		stamina = 10;
		maxStamina = ps.maxStamina;

		sprintSpeed = ps.sprintSpeed;
        speed = ps.speed;
    }
}
