using UnityEngine;

public class PlayerController : MonoBehaviour
{

#region Systems
	private PlayerStateManager	playerSM;
	public  InputHandler		inputHandler;
	public	MovementHandler		mh;
	public  PlayerStats			stats;
	public  PlayerStatHandler   statHandler;
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
		stats = GetComponent<PlayerStats>();
		statHandler	= GetComponent<PlayerStatHandler>();	
	}

	void Update()
	{
		playerSM.OnUpdateState();
		mh.ApplyGravity();
	}
}
