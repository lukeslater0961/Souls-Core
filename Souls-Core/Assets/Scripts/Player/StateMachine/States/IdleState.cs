using UnityEngine;

public class IdleState : BaseState
{
	public override void OnEnter(PlayerStateManager manager)
	{
		Debug.Log("Idle state entered");
	}

	public override void OnUpdate(PlayerStateManager manager)
	{
		if (manager.pc.inputHandler.moveDirection.sqrMagnitude > 0.01)
			manager.SwitchState(PlayerStateManager.moveState);

		if (manager.pc.inputHandler.jumpPressed && manager.pc.mh._isGrounded)
			manager.pc.mh.Jump();
	}

	public override void OnExit(PlayerStateManager manager)
	{
		Debug.Log("Idle State exited");
	}
}
