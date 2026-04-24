using UnityEngine;

public class DamageZone : MonoBehaviour
{
	public float damage = 10f;
	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<PlayerStatHandler>().TakeDamage(damage);
	}
}
