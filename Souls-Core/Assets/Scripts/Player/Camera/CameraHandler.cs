using UnityEngine;
using System.Collections.Generic;

public class CameraHandler : MonoBehaviour
{
#region References
	[SerializeField] InputHandler	_input;
	[SerializeField] PlayerStats	_stats;
	[SerializeField] GameObject		_player;
#endregion

#region Values
	private Camera		_camera;
	public  Transform	_transform;
	private float		_maxLockDistance = 35f;

	private Vector2		_look;
	public  Transform	_target;
	public	bool		_isLocked {get; private set;}
#endregion

    void Start()
    {
		_isLocked = false;
		_camera = Camera.main;
    }

    void LateUpdate()
    {
		_transform = _camera.transform;
		transform.position = _player.transform.position;
		RotateCamera();
		LockTarget();
		CheckTargetDistance();
    }

	void RotateCamera()
	{
        if (_input.lookDirection.sqrMagnitude <= 0 || _isLocked)
			return;
		
		_look.y +=  _input.lookDirection.y * _stats.sensitivity;
		_look.x +=  _input.lookDirection.x * _stats.sensitivity;
		_look.y = Mathf.Clamp(_look.y, -40f, 60f);
		this.transform.localRotation = Quaternion.Euler(-_look.y, _look.x, 0);
	}

	public void GetTarget(List<Collider> validTargets)
	{
		Transform closestTarget = null;
		float closestDistance = Mathf.Infinity;

		foreach (var target in validTargets)
		{
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestTarget = target.transform;
			}
		}

		if (closestTarget != null)
		{
			_isLocked = true;
			_target = closestTarget;
		}
	}

	void LockTarget()
	{
		if (_target == null) return;

		Vector3 direction = _target.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(direction);

		_look.x = targetRotation.eulerAngles.y;
		_look.y = targetRotation.eulerAngles.x;
		transform.localRotation = Quaternion.Euler(-_look.y, _look.x, 0);
	}

	public void UnlockTarget()
	{
		_target = null;
		_isLocked = false;
	}

	void CheckTargetDistance()
	{
		if (!_isLocked)
			return;

		float distance = Vector3.Distance(transform.position, _target.position);
		if (distance >= _maxLockDistance)
			UnlockTarget();
	}
}

