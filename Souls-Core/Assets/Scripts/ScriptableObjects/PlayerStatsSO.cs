using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsSO : ScriptableObject 
{
	public float maxHealth;
	public float stamina;
	public float speed;
	public float sensitivity;
	public float jumpForce;
}
