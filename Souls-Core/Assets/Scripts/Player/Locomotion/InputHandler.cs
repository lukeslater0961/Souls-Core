using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
	private InputAction move;

	public Vector2 moveDirection;

    void Start()
    {
		move = InputSystem.actions.FindAction("move");
    }

    void Update()
    {

        moveDirection = move.ReadValue<Vector2>();
    }
}
