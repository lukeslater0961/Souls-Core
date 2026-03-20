using UnityEngine;

public class MoveState : BaseState
{

	public override void OnEnter(PlayerStateManager manager)
	{
		Debug.Log("move state entered");
	}

	public override void OnUpdate(PlayerStateManager manager)
	{
		if (manager.pc.inputHandler.moveDirection.sqrMagnitude == 0)
			manager.SwitchState(PlayerStateManager.idleState);

		if (manager.pc.inputHandler.jumpPressed && manager.pc.mh._isGrounded)
			manager.pc.mh.Jump();

		manager.pc.mh.DoMovement(manager.pc.inputHandler.moveDirection);
		//call move function in movement system here
	}

	public override void OnExit(PlayerStateManager manager)
	{
		Debug.Log("move State exited");
	}
}
