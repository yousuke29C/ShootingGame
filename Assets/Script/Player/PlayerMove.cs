using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int PlayerHp;

    //�q�I�u�W�F�N�g�̃T�C�Y�����邽�߂̕ϐ�
    private float Left, Right, Top, Bottom;

    //�J�������猩����ʍ����̍��W������ϐ�
    Vector3 leftBottom;

    //�J�������猩����ʉE���̍��W������ϐ�
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        PlayerHp = 40;

        //�J�����ƃv���C���[�̋����𑪂�(�\����ʂ̎l����ݒ肷�邽�߂ɕK�{)
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //�X�N���[����ʍ����̈ʒu��ݒ肷��
        leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        //�X�N���[����ʉE���̈ʒu��ݒ肷��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //�q�I�u�W�F�N�g�̐��������[�v�������s��
        foreach (Transform child in gameObject.transform)
        {
            //�q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if(child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W���E�[�p�̕ϐ��ɑ������
                Right = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԍ��̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J��X���W�����[�p�̕ϐ��ɑ������
                Left = child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԏ�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z >= Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J��Z���W����[�p�̕ϐ��ɑ������
                Top = child.transform.localPosition.z;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԉ��̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z <= Bottom)
            {
                //�q�I�u�W�F�N�g�̃��[�J��Z���W����[�p�̕ϐ��ɑ������
                Bottom = child.transform.localPosition.z;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        if (PlayerHp >= 0)
        {

            //�X�s�[�h�ϊ�
            if (Input.GetKey(KeyCode.LeftShift))
            {

                //�E���L�[�����͂��ꂽ�Ƃ�
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    //�E������0.01����
                    pos.x += 0.1f;
                }
                //�����L�[�����͂��ꂽ�Ƃ�
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //��������0.01����
                    pos.x -= 0.1f;
                }
                //����L�[�����͂��ꂽ�Ƃ�
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //�������0.01����
                    pos.z += 0.1f;
                }
                //�����L�[�����͂��ꂽ�Ƃ�
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //��������0.01����
                    pos.z -= 0.1f;
                }

            }

            //�E���L�[�����͂��ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //�E������0.01����
                pos.x += 0.1f;
            }
            //�����L�[�����͂��ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //��������0.01����
                pos.x -= 0.1f;
            }
            //����L�[�����͂��ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //�������0.01����
                pos.z += 0.1f;
            }
            //�����L�[�����͂��ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //��������0.01����
                pos.z -= 0.1f;
            }
            transform.position = new Vector3(
                Mathf.Clamp(pos.x, leftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
                pos.y,
                Mathf.Clamp(pos.z, leftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top));
        }
            if (Input.GetKey(KeyCode.R))
            {

                {
                    string activeSceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(activeSceneName);
                }

            }

        if (PlayerHp <= 0)
        {

            //if (Input.GetKey(KeyCode.R))
            //{
            //    PlayerHp = 40;
            //}
        }
    }
    public void Damage()
    {
        //PlayerHp��hp��1�ւ炷
        PlayerHp = PlayerHp - 1;
        //���݂̗̑͂�Console�r���[�ɕ\������
        Debug.Log(PlayerHp);
    }
}
