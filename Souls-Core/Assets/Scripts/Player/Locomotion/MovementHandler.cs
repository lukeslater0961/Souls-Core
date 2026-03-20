using UnityEngine;

public class MovementHandler : MonoBehaviour
{
	private float speed = 10f;
	//create scriptable object for movement stats

#region References
	private CharacterController cc;
	private CameraHandler _camera;
#endregion

	void Awake()
	{
		cc = GetComponentInChildren<CharacterController>();
		_camera = GetComponentInChildren<CameraHandler>();
	}

	public void DoMovement(Vector2 moveDirection)
	{
		Vector3 camForward = _camera._transform.forward;
		Vector3 camRight = _camera._transform.right;

		camForward.y = 0;
		camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		Vector3 move = camForward * moveDirection.y + camRight * moveDirection.x;
		cc.Move(move * speed * Time.deltaTime);

		//to be modified later on , mvoement will be based on camera.right/.forward normalized
	}
}
