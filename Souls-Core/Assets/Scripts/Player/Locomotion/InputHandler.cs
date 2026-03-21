using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
#region References
	[SerializeField] LockOnHandler _lockHandler;
	[SerializeField] public CameraHandler _camera;
#endregion

#region Inputs
	private InputAction _move;
	private InputAction _look;
	private InputAction _lock;
#endregion

	public Vector2 moveDirection;
	public Vector2 lookDirection;
	public bool		jumpPressed;

    void Start()
    {
		_move = InputSystem.actions.FindAction("move");
		_look = InputSystem.actions.FindAction("look");
		_lock = InputSystem.actions.FindAction("lock");

		InputSystem.actions["Jump"].performed += _ => jumpPressed = true;
		InputSystem.actions["Lock"].performed += _ => OnLockPressed();
        InputSystem.actions["Jump"].canceled  += _ => jumpPressed = false;

    }

    void Update()
    {
        moveDirection = _move.ReadValue<Vector2>();
		lookDirection = _look.ReadValue<Vector2>();
    }

	private void OnLockPressed()
	{
		if (_camera._isLocked)
			_camera.UnlockTarget();
		else
			_lockHandler.GetClosestTarget();
	}
}
