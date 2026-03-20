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
	public bool		jumpPressed;

    void Start()
    {
		move = InputSystem.actions.FindAction("move");
		look = InputSystem.actions.FindAction("look");

		InputSystem.actions["Jump"].performed += _ => jumpPressed = true;
        InputSystem.actions["Jump"].canceled  += _ => jumpPressed = false;
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
		lookDirection = look.ReadValue<Vector2>();
    }
}
