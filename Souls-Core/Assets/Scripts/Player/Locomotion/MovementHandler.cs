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
		Vector3 moveDir = new Vector3(moveDirection.x, 0f, moveDirection.y);
		cc.Move(moveDir * speed * Time.deltaTime);
		//to be modified later on , mvoement will be based on camera.right/.forward normalized
	}
}
