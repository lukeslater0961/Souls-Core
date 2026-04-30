using UnityEngine;
using System;
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
	private InputAction _jump;
	private InputAction _sprint;
	private InputAction _look;
	private InputAction _lock;
	private InputAction _lightAttack;
	private InputAction _heavyAttack;
#endregion

	public event Action OnLightAttack;
	public event Action OnHeavyAttack;

	public Vector2	moveDirection;
	public Vector2	lookDirection;
	public bool		jumpPressed;
	public bool		sprintPressed;

    void Start()
    {
		_move = InputSystem.actions.FindAction("move");
		_look = InputSystem.actions.FindAction("look");
		_lock = InputSystem.actions.FindAction("lock");
		_sprint = InputSystem.actions.FindAction("sprint");
		_jump = InputSystem.actions.FindAction("jump");

		_lightAttack = InputSystem.actions.FindAction("lightattack");
		_heavyAttack = InputSystem.actions.FindAction("heavyattack");

		_sprint.performed += _ => sprintPressed = true;
		_sprint.canceled += _ => sprintPressed = false;
		_jump.performed += _ => jumpPressed = true;
		_jump.canceled  += _ => jumpPressed = false;
		_lock.performed += _ => OnLockPressed();
		_lightAttack.performed += _ => OnLightAttack?.Invoke();
		_heavyAttack.performed += _ => OnHeavyAttack?.Invoke();

		_statHandler = GetComponent<PlayerStatHandler>();
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
