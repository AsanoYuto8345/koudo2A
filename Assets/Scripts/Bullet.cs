using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 10f;

    [Header("寿命（秒）")]
    public float lifeTime = 5f;

    private Vector3 velocity;   // 等速運動の方向ベクトル

    void Start()
    {
        // 発射地点から見た原点方向を正規化
        Vector3 targetDirection = (Vector3.zero - transform.position).normalized;

        // 等速直線運動の速度ベクトル
        velocity = targetDirection * speed;

        // 自動で消える
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 毎フレーム、等速直線運動で移動
        transform.position += velocity * Time.deltaTime;
    }
}
