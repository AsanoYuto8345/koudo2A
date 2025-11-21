using UnityEngine;

public class Bullet : MonoBehaviour
{
    public General general;
    [Header("�ړ����x")]
    public float speed = 10f;

    [Header("�����i�b�j")]
    public float lifeTime = 5f;

    private Vector3 velocity;   // �����^���̕����x�N�g��

    void Start()
    {
        if (general == null)
        {
            // 名前が "General" の GameObject を探す
            GameObject obj = GameObject.Find("General");

            if (obj != null)
            {
                // General コンポーネントを取得して代入
                general = obj.GetComponent<General>();
            }
            else
            {
                Debug.LogError("GameObject 'General' がシーン内に見つかりません");
            }
        }
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

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("球判定");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに当たってる");
            if (general != null) general.score -= 100;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Shield"))
        {
            Debug.Log("シールドに当たってる");
            if (general != null) general.score += 100;
            Destroy(this.gameObject);
        }
    }
}
