using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�ړ����x")]
    public float speed = 10f;

    [Header("�����i�b�j")]
    public float lifeTime = 5f;

    private Vector3 velocity;   // �����^���̕����x�N�g��

    void Start()
    {
        // ���˒n�_���猩�����_�����𐳋K��
        Vector3 targetDirection = (new Vector3(0,1,0) - transform.position).normalized;

        // ���������^���̑��x�x�N�g��
        velocity = targetDirection * speed;

        // �����ŏ�����
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // ���t���[���A���������^���ňړ�
        transform.position += velocity * Time.deltaTime;
    }
}
