using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //�E���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //�E������0.01����
            pos.x += 0.01f;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //��������0.01����
            pos.x -= 0.01f;
        }
        //����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�������0.01����
            pos.z += 0.01f;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //��������0.01����
            pos.z -= 0.01f;
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
