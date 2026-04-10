using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsSO : ScriptableObject 
{
	public float maxHealth;
	public float sprintSpeed;
	public float maxStamina;
	public float speed;
	public float sensitivity;
	public float jumpForce;
	public float rotationSpeed;
}
