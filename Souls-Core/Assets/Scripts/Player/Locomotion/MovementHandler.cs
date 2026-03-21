using UnityEngine;

public class MovementHandler : MonoBehaviour
{
#region References
	public  CharacterController			_cc;
	[SerializeField] CameraHandler		_cameraRef;
	private PlayerStats					_stats;
#endregion

#region localValues
	private Vector3 _velocity;
	public  bool	_isGrounded;
	private CameraHandler _camera;
	
#endregion

	void Awake()
	{
		_cc = GetComponent<CharacterController>();
		_camera = _cameraRef.GetComponent<CameraHandler>();
		_stats = GetComponent<PlayerStats>();
	}

	public void DoMovement(Vector2 moveDirection)
	{

		//player movement 
		Vector3 camForward = _cameraRef._transform.forward;
		Vector3 camRight = _cameraRef._transform.right;

		camForward.y = 0;
		camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		Vector3 move = camForward * moveDirection.y + camRight * moveDirection.x;
		_cc.Move(move * _stats.speed * Time.deltaTime); 
		Quaternion targetRotation = Quaternion.LookRotation(move);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _stats.rotationSpeed * Time.deltaTime);
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

	public void RotateToTarget()
	{
		Vector3 direction = _camera._target.position - transform.position;
		direction.y = 0f;
		Quaternion targetRotation = Quaternion.LookRotation(direction);		
		transform.rotation =  Quaternion.Slerp(transform.rotation, targetRotation, _stats.rotationSpeed * Time.deltaTime);
	}
}
