using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
	public static IdleState idleState = new IdleState();
	/*public static MoveState moveState = new MoveState();
	public static RollState rollState = new RollState();
	public static AttackState attackState = new AttackState();*/

	private BaseState currentState = null;

	public PlayerController pc;

	public void SwitchState(BaseState state)
	{
		if (currentState != null)
			currentState.OnExit(this);
		currentState = state;
		currentState.OnEnter(this);
	}

	public void OnUpdateState()
	{
		currentState.OnUpdate(this);
	}
}

