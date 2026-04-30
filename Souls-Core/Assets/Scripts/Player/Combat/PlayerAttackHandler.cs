using UnityEngine;
using System.Collections.Generic;

public enum AttackType
{
    LightAttack1,
    LightAttack2,
    HeavyAttack1,
    HeavyAttack2
}

public class PlayerAttackHandler : MonoBehaviour
{
	private static readonly Dictionary <AttackType, int> _animHashes = new(){
		{AttackType.LightAttack1, Animator.StringToHash("LightAttack1")},
		{AttackType.LightAttack2, Animator.StringToHash("LightAttack2")},
		{AttackType.HeavyAttack1, Animator.StringToHash("HeavyAttack1")},
		{AttackType.HeavyAttack2, Animator.StringToHash("HeavyAttack2")}
	};

	private AttackType[] _lightAttacks = {
		AttackType.LightAttack1
	//	AttackType.LightAttack2
	};

	private AttackType[] _heavyAttacks = {
		AttackType.HeavyAttack1
		//AttackType.HeavyAttack2
	};

	private int			_lightAttackIndex;
	private int			_heavyAttackIndex;

#region References
	private Animator    _animator;
#endregion

    void Start()
    {
		_animator = GetComponent<Animator>();
		GetComponent<InputHandler>().OnLightAttack += LightAttack;
		GetComponent<InputHandler>().OnHeavyAttack += HeavyAttack;

		_lightAttackIndex = 0;
		_heavyAttackIndex = 0;
    }

	void LightAttack()
	{
		Debug.Log($"performing light attack on {_lightAttackIndex}:{_lightAttacks.Length}");
		PerformAttack(_lightAttacks[_lightAttackIndex]);

		_lightAttackIndex += 1;
		if (_lightAttackIndex > _lightAttacks.Length - 1)
			_lightAttackIndex = 0;
	}	

	void HeavyAttack()
	{
		Debug.Log($"performing heavy attack on {_heavyAttackIndex}");
		PerformAttack(_heavyAttacks[_heavyAttackIndex]);

		_heavyAttackIndex += 1;
		if (_heavyAttackIndex > _heavyAttacks.Length - 1)
			_heavyAttackIndex = 0;
	}

	void PerformAttack(AttackType attack)
	{
		_animator.Play(_animHashes[attack]);
	}
}
