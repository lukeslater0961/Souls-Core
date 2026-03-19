using UnityEngine;

public class IdleState : BaseState
{
	public override void OnEnter(PlayerStateManager manager)
	{
		Debug.Log("Idle state entered");
	}

	public override void OnUpdate(PlayerStateManager manager)
	{
		Debug.Log($"movement vector = {manager.pc.inputHandler.moveDirection}");
	}

	public override void OnExit(PlayerStateManager manager)
	{
		Debug.Log("Idle State exited");
	}
}
