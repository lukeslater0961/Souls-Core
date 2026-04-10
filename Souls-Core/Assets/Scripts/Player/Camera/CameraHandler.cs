using UnityEngine;
using System.Collections.Generic;

public class CameraHandler : MonoBehaviour
{
#region References
	[SerializeField] InputHandler	_input;
	[SerializeField] PlayerStats	_stats;
	[SerializeField] GameObject		_player;
	[SerializeField] LockOnHandler	_lockHandler;
#endregion

#region Values
	private Camera		_camera;
	public  Transform	_transform;

	public Vector2		_look;
	public  Transform	_target;
	public	bool		_isLocked {get; set;}

	[SerializeField]
	[Range(0f, 10f)]
	private float sphereRadius = .3f;
	private float _armLength = 5f;
	private float _outSpeed = 10f;
	private float _inSpeed = 20f;
	public LayerMask _occluders;
	private float _currentLength;

#endregion

    void Start()
    {
		_isLocked = false;
		_camera = Camera.main;
		_currentLength = _armLength;
    }

    void LateUpdate()
    {
		_transform = _camera.transform;
		transform.position = _player.transform.position + new Vector3(0, 3f, 0);
		RotateCamera();
		LockToTarget();
		_lockHandler.CheckTargetDistance();
		CameraBoom();
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

	void CameraBoom()
	{
		Vector3 origin = transform.position;
		Vector3 direction = -_camera.transform.forward;
		float target = _armLength;

		if (Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hit, _armLength, _occluders))
			target = hit.distance;

		float speed = (target < _currentLength) ? _inSpeed : _outSpeed;
		_currentLength = Mathf.Lerp(_currentLength, target, speed * Time.deltaTime);
		_camera.transform.position = origin + direction * _currentLength;
	}

	void LockToTarget()
	{
		if (_target == null) return;

		Vector3 direction = _target.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(direction);

		_look.x = targetRotation.eulerAngles.y;
		_look.y = targetRotation.eulerAngles.x;
		transform.localRotation = Quaternion.Euler(-_look.y, _look.x, 0);
	}
}

