using UnityEngine;

public class PlayerController : MonoBehaviour
{

#region Systems
	private PlayerStateManager	playerSM;
	public  InputHandler		inputHandler;
	public	MovementHandler		mh;
#endregion

	void Start()
	{
		Init();

		playerSM.SwitchState(PlayerStateManager.idleState);
	}

	void Init()
	{
		playerSM = GetComponent<PlayerStateManager>();
		inputHandler = GetComponent<InputHandler>();
		mh = GetComponent<MovementHandler>();
	}

	void Update()
	{
		playerSM.OnUpdateState();
		mh.ApplyGravity();
	}
}
