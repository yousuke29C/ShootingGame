using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp <= 0)
        {
            //�����ŏ�����
            Destroy(this.gameObject);
        }
    }
    public void Damage()
    {
        //enemy��hp��1�ւ炷
        enemyHp = enemyHp - 1;
        //���݂̗̑͂�Console�r���[�ɕ\������
        Debug.Log(enemyHp);
    }
}
