using UnityEngine;

public class MovementHandler : MonoBehaviour
{
#region References
	public  CharacterController _cc;
	private CameraHandler		_camera;
	private PlayerStats			_stats;
#endregion

#region localValues
	private Vector3 _velocity;
	public  bool	_isGrounded;
	
#endregion

	void Awake()
	{
		_cc = GetComponentInChildren<CharacterController>();
		_camera = GetComponentInChildren<CameraHandler>();
		_stats = GetComponent<PlayerStats>();
	}

	public void DoMovement(Vector2 moveDirection)
	{

		//player movement 
		Vector3 camForward = _camera._transform.forward;
		Vector3 camRight = _camera._transform.right;

		camForward.y = 0;
		camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		Vector3 move = camForward * moveDirection.y + camRight * moveDirection.x;
		_cc.Move(move * _stats.speed * Time.deltaTime);
		//to be modified later on , mvoement will be based on camera.right/.forward normalized
	}

	public void ApplyGravity()
	{
		if (_cc.isGrounded)
		{
			_velocity.y = -2f;
			_isGrounded = true;
		}
		else
		{
			_velocity.y += Physics.gravity.y * Time.deltaTime;
			_isGrounded = false;
		}
		_cc.Move(_velocity * _stats.speed * Time.deltaTime);
	}

	public void Jump()
	{
		_velocity.y = _stats.jumpForce;
		_cc.Move(_velocity * Time.deltaTime);
	}
}
