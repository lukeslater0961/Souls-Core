using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

#region Inputs
	private InputAction move;
	private InputAction look;
#endregion

	public Vector2 moveDirection;
	public Vector2 lookDirection;

    void Start()
    {
		move = InputSystem.actions.FindAction("move");
		look = InputSystem.actions.FindAction("look");
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
		lookDirection = look.ReadValue<Vector2>();
    }
}
