using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    //�Q�[���I�u�W�F�N�g���C���X�y�N�^�[����Q�Ƃ��邽�߂̕ϐ�
    public GameObject Bulllet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�e�𐶐�����
            Instantiate(Bulllet, transform.position, Quaternion.identity);
        }
    }
}
