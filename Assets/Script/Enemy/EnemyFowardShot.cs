using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFowardShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //�ł��o���Ԋu�����߂�
    public float time = 1;

    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;

    //���݂̃^�C�}�[����
    float nowtime = 0;

    private void CreateShotObject(float axis)
    {
        //�x�N�g�����擾
        var direction = player.transform.position - transform.position;

        //�x�N�g����y��������
        direction.y = 0;

        //�������擾
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //�e�𐶐�����
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);

        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����ĂȂ�������
        if (player == null)
        {
            //�v���W�F�N�g��player��T���ď����擾����
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //�^�C�}�[�����炷
        nowtime -= Time.deltaTime;
        
        //�����^�C�}�[��0�ȉ��ɂȂ�����
        if (nowtime <= 0)
        {
            //�e�𐶐�
            CreateShotObject(-transform.localEulerAngles.y);

            //�^�C�}�[��������
            nowtime = time;
        }
    }
}
