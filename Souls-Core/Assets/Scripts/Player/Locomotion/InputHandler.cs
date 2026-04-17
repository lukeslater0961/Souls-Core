using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
#region References
	[SerializeField] LockOnHandler				_lockHandler;
	[SerializeField] public CameraHandler		_camera;
	private					PlayerStatHandler	_statHandler;
#endregion

#region Inputs
	private InputAction _move;
	private InputAction _sprint;
	private InputAction _look;
	private InputAction _lock;
#endregion

	public Vector2	moveDirection;
	public Vector2	lookDirection;
	public bool		jumpPressed;
	public bool		sprintPressed;

    void Start()
    {
		_move = InputSystem.actions.FindAction("move");
		_look = InputSystem.actions.FindAction("look");
		_lock = InputSystem.actions.FindAction("lock");
		_statHandler = GetComponent<PlayerStatHandler>();

		InputSystem.actions["Sprint"].performed += _ => sprintPressed = true;
		InputSystem.actions["Sprint"].canceled += _ => sprintPressed = false;
		InputSystem.actions["Jump"].performed += _ => jumpPressed = true;
		InputSystem.actions["Jump"].canceled  += _ => jumpPressed = false;
		InputSystem.actions["Lock"].performed += _ => OnLockPressed();
    }

    void Update()
    {
        moveDirection = _move.ReadValue<Vector2>();
		lookDirection = _look.ReadValue<Vector2>();
    }

	private void OnLockPressed()
	{
		if (_camera._isLocked)
			_lockHandler.UnlockTarget();
		else
			_lockHandler.GetTargets();
	}
}
