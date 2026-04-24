using UnityEngine;

public class HealZone : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<PlayerStatHandler>().GiveHealth();
	}
}
