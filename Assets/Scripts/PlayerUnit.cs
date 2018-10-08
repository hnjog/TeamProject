using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour {

    enum State
    {
        Move,
        Attack,
        Die,
    }

    State state = State.Move;

    [Header("이동 관련 변수")]
    public float playerUnitSpeed;                 //플레이어 유닛 이동속도
    
    [Header("스텟 관련 변수")]
    public int playerUnitHp;                       //플레이어 유닛 체력
    public int playerUnitAttack;                   //플레이어 유닛 공격력
    public int playerUnitCost;                     //플레이어 유닛 코스트

    private void Start()
    {
        state = State.Move;
        
    }

    private void Update()
    {
        switch (state)
        {
            case State.Move:
                PlayerUnitMovement();
                break;
            case State.Attack:
                break;
            case State.Die:
            default:
                break;
        }
    }

    public void PlayerUnitMovement()
    {
        transform.Translate(Vector2.right * playerUnitSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        state = State.Attack;
    }
}
