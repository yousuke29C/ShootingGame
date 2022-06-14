using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定しておく
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp <= 0)
        {
            //自分で消える
            Destroy(this.gameObject);
        }
    }
    public void Damage()
    {
        //enemyのhpを1へらす
        enemyHp = enemyHp - 1;
        //現在の体力をConsoleビューに表示する
        Debug.Log(enemyHp);
    }
}
