using UnityEngine;

public class PlayerStats : MonoBehaviour
{
#region	ScriptableObjects
	[SerializeField]	PlayerStatsSO ps;
#endregion

#region local stats
	public float speed;
	public float stamina;
	public float currentHealth;
	public float sensitivity;
	public float jumpForce;
#endregion

    void Start()
    {
		currentHealth = ps.maxHealth;
		sensitivity = ps.sensitivity;
		jumpForce = ps.jumpForce;
		stamina = ps.stamina;
        speed = ps.speed;
    }
}
