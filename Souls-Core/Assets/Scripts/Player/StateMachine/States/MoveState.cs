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
		
		var mode = (manager.pc.inputHandler.isSprinting) 
			? MovementHandler.MoveMode.Sprint 
			: MovementHandler.MoveMode.Walk;

		manager.pc.mh.DoMovement(manager.pc.inputHandler.moveDirection, mode);

		if (mode != MovementHandler.MoveMode.Sprint && manager.pc.stats.stamina < manager.pc.stats.maxStamina)
			manager.pc.statHandler.RegenStamina();
		//call move function in movement system here
	}

	public override void OnExit(PlayerStateManager manager)
	{
		Debug.Log("move State exited");
	}
}
