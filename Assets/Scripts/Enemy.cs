using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("弾のプレハブ")]
    public GameObject bulletPrefab;

    [Header("発射ポイント")]
    public Transform firePoint;

    [Header("弾の速度")]
    public float bulletSpeed = 10f;

    [Header("発射間隔")]
    public float fireInterval = 2f;

    private float timer = 0f;

    void Update()
    {
        // (0,0,0) の方向へ向く
        Vector3 targetPos = Vector3.zero; // 目的地が常に原点
        Vector3 direction = (targetPos - transform.position);

        direction.y = 0f; // 水平回転だけにしたい時（不要なら消してOK）

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // 一定間隔で弾を撃つ
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            FireBullet();
            timer = 0f;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + new Vector3(0,1,0), firePoint.rotation);
    }
}
