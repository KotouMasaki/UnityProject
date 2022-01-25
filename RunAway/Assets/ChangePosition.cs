using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    //GameObject型を変数pointで宣言します。
    public GameObject point;
    //GameObject型を変数charaで宣言します。
    public GameObject chara;

    //コライダーが乗った時の関数
    private void OnTriggerEnter(Collider other)
    {
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.name == chara.name)
        {
            Debug.Log("hit");
            //Charaが接触したらpointオブジェクトの位置に移動するよ！
            chara.transform.position = new Vector3(0,0,2);

        }
    }
}