using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    [Header("爆発プレハブ（Explosion.cs付き）")]
    public GameObject explosionPrefab;

    [Header("爆発させる距離")]
    public float explosionDistance = 5f;
    public void SpawnExplosion()
    {
        // 自分の forward 方向に explosionDistance 離れた位置
        Vector3 spawnPos = transform.position + transform.forward * explosionDistance;

        // 爆発プレハブを生成
        Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
    }
}
