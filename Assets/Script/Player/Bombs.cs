using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    //����������p�[�e�B�N����ݒ�
    public GameObject particle;

    void Start()
    {

    }
    void Update()
    {
        //�L�[�{�[�h��B�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.B))
        {
            //�^�O�������I�u�W�F�N�g�����ׂĎ擾����
            GameObject[] enemyBulletObjects =
                GameObject.FindGameObjectsWithTag("EnemyBullet");

            //��Ŏ擾�������ׂẴI�u�W�F�N�g�����ł�����
            for (int i = 0; i < enemyBulletObjects.Length; i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }
            //�p�[�e�B�N�����������I�u�W�F�N�g�𐶐�����
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
};