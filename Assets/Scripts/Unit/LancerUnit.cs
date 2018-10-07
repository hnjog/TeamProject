﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerUnit : MonoBehaviour {

	[Header("이동 관련 변수")]
    public float lancerUnitSpeed = 0.7f;                 //유닛 이동속도
    public Rigidbody2D lancerUnitRb;                   //유닛의 리지드바디
    
    [Header("스텟 관련 변수")]
    public int lancerUnitHp = 50;                      //유닛 체력
    public int lancerUnitAttack = 3;                   //유닛 공격력
    public int lancerUnitDepend = 5;                   //유닛 방어력
    public int lancerUnitCost = 120;                     //유닛 코스트
	public int lancerCoolTime = 20;
    

    [Header("Enemy 관련 변수")]
    public GameObject enemyUnit;                       //적 유닛
    public int enemyUnitHp;                            //적 유닛 체력
    public int enemyUnitAttack;                        //적 유닛 공격력
    public GameObject enemyNexus;                      //적 넥서스
    public int enemyNexusHp;                           //적 넥서스 체력

    [Header("Enemy 관련 변수")]
    public bool playerisDie = false;                   //플레이어 유닛 죽음체크

    
    void Update()
    {
        StartCoroutine("Move");
    }

    //이동
    IEnumerator Move()
    {
        transform.Translate(Vector3.right * lancerUnitSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyUnit")        //적 유닛 체크
        {
            enemyUnit = other.gameObject;
            //enemyUnitHp = other.GetComponent<EnemyUnit>().enemyUnitHp;
            //enemyUnitAttack = other.GetComponent<EnemyUnit>().enemyUnitAttack;
        }
        else                                           //적 넥서스 체크
        {
            enemyNexus = other.gameObject;
            //enemyNexusHp = other.GetComponent<EnemyNexus>().enemyNexusHp;
        }
    }
}
