using UnityEngine;
using System.Collections.Generic;

public class CameraHandler : MonoBehaviour
{
#region References
	private InputHandler	_input;
	private PlayerStats		_stats;
#endregion

#region Values
	private Camera		_camera;
	public  Transform	_transform;
	private Vector2		_look;
#endregion

    void Start()
    {
		_camera = Camera.main;
        _input = GetComponentInParent<InputHandler>();
		_stats = GetComponentInParent<PlayerStats>();
    }

    void LateUpdate()
    {
		_transform = _camera.transform;
        if (_input.lookDirection.sqrMagnitude <= 0)
			return;
		
		_look.y +=  _input.lookDirection.y * _stats.sensitivity;
		_look.x +=  _input.lookDirection.x * _stats.sensitivity;
		_look.y = Mathf.Clamp(_look.y, -40f, 60f);
		this.transform.localRotation = Quaternion.Euler(-_look.y, _look.x, 0);
    }

	public void LockCamera(List<Collider> validTargets)
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
			Debug.Log($"closest is {closestTarget}");
	}
}

