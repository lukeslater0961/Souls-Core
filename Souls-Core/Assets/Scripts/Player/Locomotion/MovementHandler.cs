using UnityEngine;
using System;

public class MovementHandler : MonoBehaviour
{
#region References
	[SerializeField] CameraHandler		_cameraRef;
	public  CharacterController			_cc;
	private PlayerStats					_stats;
	private PlayerStatHandler			_statHandler;
	private Animator					_animator;
#endregion

#region localValues
	private Vector3			_velocity;
	public  bool			_isGrounded;
	private CameraHandler	_camera;
	
	public enum MoveMode
	{
		Walk,
		Sprint
	};

#endregion

	void Awake()
	{
		_cc = GetComponent<CharacterController>();
		_camera = _cameraRef.GetComponent<CameraHandler>();
		_stats = GetComponent<PlayerStats>();
		_statHandler = GetComponent<PlayerStatHandler>();
		_animator = GetComponent<Animator>();
	}

	public void DoMovement(Vector2 moveDirection, bool isSprinting)
	{
		//player movement 
		MoveMode mode = (isSprinting && _statHandler.HasEnoughStamina()) ? MoveMode.Sprint : MoveMode.Walk;
		float playerVelocity = (mode == MoveMode.Walk) ? _stats.speed : _stats.sprintSpeed;
		_animator.SetFloat("Speed", playerVelocity, 0.1f, Time.deltaTime);

		UpdateStamina(mode);

		Vector3 camForward = _cameraRef._transform.forward;
		Vector3 camRight = _cameraRef._transform.right;

		camForward.y = 0;
		camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		Vector3 move = camForward * moveDirection.y + camRight * moveDirection.x;
		_cc.Move(move * playerVelocity * Time.deltaTime);
		
		if (_camera._isLocked && mode == MoveMode.Walk)
		{
			RotateToTarget();
			return; // Rotate character to target when locked and walking
		}

		if (move == Vector3.zero) return;
		Quaternion targetRotation = Quaternion.LookRotation(move);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _stats.rotationSpeed * Time.deltaTime);
	}

	void UpdateStamina(MoveMode mode)
	{
		if (mode == MoveMode.Sprint)
		{
			_statHandler.SpendStamina(_statHandler.sprintCost);
			return;
		}
		
		_statHandler.RegenStamina();
	}

	public void RotateToTarget()
	{
		Vector3 direction = _camera._target.position - transform.position;
		direction.y = 0f;
		Quaternion targetRotation = Quaternion.LookRotation(direction);		
		transform.rotation =  Quaternion.Slerp(transform.rotation, targetRotation, _stats.rotationSpeed * Time.deltaTime);
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
