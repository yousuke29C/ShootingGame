using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    // �v���C���[
    private GameObject player;

    // �e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    // 1��őł��o���e�̐������߂�
    public int bulletWayNum = 3;

    // �ł��o���e�̊Ԋu�𒲐߂���
    public float bulletWaySpace = 30;

    // �ł��o���e�̊p�x�𒲐߂���
    public int bulletWayAxis = 0;

    // �ł��o���Ԋu�����߂�
    public float time = 1;

    // �ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;

    // ���݂��^�C�}�[����
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �^�C�}�[��������
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        // �����v���C���[�̏�񂪓����ĂȂ�������
        if (player == null)
        {
            // �v���W�F�N�g��Player��T���ď����擾����
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // �^�C�}�[�����炷
        nowtime -= Time.deltaTime;

        // �����^�C�}�[��0�ȉ��ɂȂ�����
        if (nowtime < 0)
        {
            // �p�x�����p�̕ϐ�
            float bulletWaySpaceSplit = 175;

            // ���Ŕ��˂���e�����������[�v����
            for (int i = 0; i < bulletWayNum; i++)
            {
                // �e�𐶐�
                CreateShotObject(
                bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                // �p�x�𒲐߂���
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            // �^�C�}�[��������
            nowtime = time;
        }
    }
    private void CreateShotObject(float axis)
    {
        // �e�𐶐�����
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        // EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        // �e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);

        // �e��ł��o���p�x��ύX����
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));

    }
}
