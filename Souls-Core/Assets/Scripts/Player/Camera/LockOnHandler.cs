using UnityEngine;
using System.Collections.Generic;

public class LockOnHandler : MonoBehaviour
{
#region References
	private CameraHandler _camera;
#endregion

	[SerializeField] private LayerMask layer;
	
	void Awake()
	{
		_camera = GetComponent<CameraHandler>();
	}

	public void GetClosestTarget()
	{
		Collider[] targets = Physics.OverlapSphere(transform.position, 20f, layer);
		List<Collider> validTargets = new List<Collider>();
		
		foreach(var target in targets)
		{
			Vector3 targetDirection = target.transform.position - transform.position;
			float angle = Vector3.Angle(_camera.transform.forward, targetDirection);

			if (angle < 90f)
				validTargets.Add(target);
		}
		if (validTargets.Count > 0)
			_camera.LockCamera(validTargets);
	}
}
