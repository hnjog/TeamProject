using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    [Header("Line 관련 변수")]
    public Transform[] LineTfs = new Transform[4];

    /// <summary>
    /// 내부 관리 변수
    /// </summary>
    private Vector2        mousePos;                         //마우스 포지션 
    private RaycastHit2D   rayHit;                           
    private GameObject     playerUnit;                       //유닛을 저장할 변수

    private void Update()
    {
        //마우스 위치
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //왼쪽 마우스 클릭하는동안
        if (Input.GetMouseButton(0))
        {
            if (rayHit = Physics2D.Raycast(mousePos, Vector2.zero))
            {
                //왼쪽 마우스 한번 클릭
                if (Input.GetMouseButtonDown(0))
                {
                    if (rayHit.transform.tag == "PlayerUnit")
                    {
                        playerUnit = Instantiate(rayHit.transform.gameObject, mousePos, Quaternion.identity);
                        playerUnit.name = rayHit.transform.name;
                        playerUnit.transform.localScale = new Vector2(9f, 9f);
                        playerUnit.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
            }

            if (playerUnit != null)
            {
                playerUnit.transform.position = mousePos;
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
                    //내려놓는 위치의 이름에 따라 지정되는 위치가 차이가 난다.
                    switch (rayHit.transform.name)
                    {
                        case "Line1":
                            playerUnit.transform.position = LineTfs[0].position;
                            break;
                        case "Line2":
                            playerUnit.transform.position = LineTfs[1].position;
                            break;
                        case "Line3":
                            playerUnit.transform.position = LineTfs[2].position;
                            break;
                        case "Line4":
                            playerUnit.transform.position = LineTfs[3].position;
                            break;
                    }

                    playerUnit.transform.tag = "Untagged";
                    playerUnit.GetComponent<BoxCollider2D>().enabled = true;
                    playerUnit.GetComponent<BoxCollider2D>().isTrigger = true;
                    switch(playerUnit.name)
                    {
                        case "Sword":
                            playerUnit.GetComponent<BoxCollider2D>().offset = new Vector2(0.2f, 0);
                            //playerUnit.GetComponent
                            break;
                    }

                    playerUnit.GetComponent<PlayerUnit>().enabled = true;
                    playerUnit = null;

                }//else 끝
            }//비어 있지 않은가 체크 끝
        }//마우스 떼었을떄 끝
    }// update 끝
}