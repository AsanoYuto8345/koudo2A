using UnityEngine;

public class Enemy : MonoBehaviour
{
    public General general;
    [Header("�e�̃v���n�u")]
    public GameObject bulletPrefab;

    [Header("���˃|�C���g")]
    public Transform firePoint;

    [Header("�e�̑��x")]
    public float bulletSpeed = 10f;

    [Header("���ˊԊu")]
    public float fireInterval = 2f;

    private float timer = 0f;

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
    }


    void Update()
    {
        // (0,0,0) �̕����֌���
        Vector3 targetPos = Vector3.zero; // �ړI�n����Ɍ��_
        Vector3 direction = (targetPos - transform.position);

        direction.y = 0f; // ������]�����ɂ��������i�s�v�Ȃ������OK�j

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // ���Ԋu�Œe������
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            FireBullet();
            timer = 0f;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + new Vector3(0, 1, 0), firePoint.rotation);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            if (general != null) general.score += 100;
            Destroy(gameObject);
        }
    }
}
