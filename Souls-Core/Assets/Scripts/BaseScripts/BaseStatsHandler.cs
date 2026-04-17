using UnityEngine;

public class BaseStatsHandler : MonoBehaviour
{
#region References
	public BaseStats _stats {get ; private set;}
#endregion

	void Start()
	{
		_stats = GetComponent<BaseStats>();
	}
}
