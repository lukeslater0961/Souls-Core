using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerStateManager playerSM;
	public  InputHandler inputHandler;
	//private 
	
	void Start()
	{
		Debug.Log("player controller strat");
		playerSM = GetComponent<PlayerStateManager>();
		playerSM.SwitchState(PlayerStateManager.idleState);
	}

	void Update()
	{
		playerSM.OnUpdateState();
	}
}
