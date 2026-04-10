using UnityEngine;
using System.Collections.Generic;

public class LockOnHandler : MonoBehaviour
{
#region References
	private CameraHandler _camera;
#endregion

#region Values
	private float		_maxLockDistance = 35f;
#endregion

	[SerializeField] private LayerMask layer;
	
	void Awake()
	{
		_camera = GetComponent<CameraHandler>();
	}

	public void CheckTargetDistance()
	{
		if (!_camera._isLocked)
			return;

		float distance = Vector3.Distance(_camera.transform.position, _camera._target.position);
		if (distance >= _maxLockDistance)
			UnlockTarget();
	}

	public void UnlockTarget()
	{
		if (_camera._look.y > 180f) _camera._look.y -= 360f;

		_camera._target = null;
		_camera._isLocked = false;
	}

	public void GetTargets()
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
			GetClosestTarget(validTargets);
	}	

	public void GetClosestTarget(List<Collider> validTargets)
	{
		Transform closestTarget = null;
		float closestDistance = Mathf.Infinity;

		foreach (var target in validTargets)
		{
			float distance = Vector3.Distance(_camera.transform.position, target.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestTarget = target.transform;
			}
		}

		if (closestTarget != null)
		{
			_camera._isLocked = true;
			_camera._target = closestTarget;
		}
	}
}
