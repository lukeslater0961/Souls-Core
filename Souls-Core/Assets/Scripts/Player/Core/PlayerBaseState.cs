using UnityEngine;

public abstract class BaseState
{
	public abstract void OnEnter(PlayerStateManager manager);
	public abstract void OnUpdate(PlayerStateManager manager);
	public abstract void OnExit(PlayerStateManager manager);
}
