﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitChoose : MonoBehaviour
{
    [Header("Line 관련 변수")]
    public Transform Line1;
    public Transform Line2;
    public Transform Line3;
    public Transform Line4;

    [Header("Prefab 관련 변수")]
    GameObject chosenUnit;                                                 //선택한 유닛(프리팹)

    [Header("생산 관련 변수")]
    public int unitCooltime;
    public int unitCost;
    public float cooltimeChecker = 0;
    bool canSwordCreate = true;                                           // 생산 가능 변수는 따로 두었음
    bool canAchorCreate = true;
    bool canLanceCreate = true;
    bool canShieldCreate = true;
     

    private Vector2 mousePos;
    private RaycastHit2D rayHit;
    //내부 관련 변수
    private GameObject playerUnit;                                         //유닛을 저장할 변수

    [ColorUsage(false, true, 0, 0, 0, 0)]
    public Color color;

    public void UnitChoice()
    {
        UnitCreater.playerUnit = chosenUnit;                               //선택한 유닛의 정보를 UnitCreater로 넘긴다
    }

    private void Update()
    {
        //while
        //마우스 위치
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        //왼쪽 마우스 클릭하는동안
        if (Input.GetMouseButton(0))
        {
            if (rayHit = Physics2D.Raycast(mousePos, Vector2.zero))
            {
                Debug.Log(rayHit.transform.name);
                //왼쪽 마우스 한번 클릭
                if (Input.GetMouseButtonDown(0))
                {
                    if (rayHit.transform.tag == "PlayerUnit")
                    {
                        playerUnit = Instantiate(rayHit.transform.gameObject, mousePos, Quaternion.identity);
                        playerUnit.name = rayHit.transform.name;
                        playerUnit.transform.localScale = new Vector2(9, 9);
                        playerUnit.GetComponent<BoxCollider2D>().enabled = false;
                        //startcorutine
                    }
                }
            }

            if (playerUnit != null)
            {
                playerUnit.transform.position = mousePos;
            }
            else
            {
                return;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (playerUnit != null)
            {
                if (rayHit.transform == null || rayHit.transform.tag == "PlayerUnit")
                {
                    Destroy(playerUnit);
                }
                else
                {
                    switch(playerUnit.name)
                    {
                         case "Sword Unit":
                            playerUnit.GetComponent<SwordUnit>().enabled = true;
                            unitCooltime = playerUnit.GetComponent<SwordUnit>().swordCoolTime;
                            break;
                        case "Achor Unit":
                            playerUnit.GetComponent<AchorUnit>().enabled = true;
                            break;
                        case "Lancer Unit":
                            playerUnit.GetComponent<LancerUnit>().enabled = true;
                            break;
                        case "Shield Unit":
                            playerUnit.GetComponent<ShieldUnit>().enabled = true;
                            break;
                    }
                    
                    //내려놓는 위치의 이름에 따라 지정되는 위치가 차이가 난다.
                    switch (rayHit.transform.name)
                    {
                        case "Line1":
                            playerUnit.transform.position = Line1.position;
                            break;
                        case "Line2":
                            playerUnit.transform.position = Line2.position;
                            break;
                        case "Line3":
                            playerUnit.transform.position = Line3.position;
                            break;
                        case "Line4":
                            playerUnit.transform.position = Line4.position;
                            break;
                    }
                    playerUnit = null;
                }//else 끝
            }//비어 있지 않은가 체크 끝
        }//마우스 떼었을떄 끝
    }// update 끝
    IEnumerator Cooltime()
    {
        
        while (true)
        {

        }
    }

}