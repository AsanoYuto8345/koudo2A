using UnityEngine;

public class SpawnOnCircle : MonoBehaviour
{
    [Header("中心となるオブジェクト")]
    public Transform center;

    [Header("複製するプレハブ")]
    public GameObject prefab;

    [Header("半径")]
    public float radius = 3f;

    [Header("スポーン間隔（秒）")]
    public float spawnInterval = 1f;

    private float timer = 0f;

    void Update()
    {
        if (center == null || prefab == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandom();
            timer = 0f;
        }
    }

    void SpawnRandom()
    {
        // ランダムな角度 0〜2π
        float angle = Random.Range(0f, Mathf.PI * 2f);

        // 円周上の位置 (XZ平面)
        Vector3 pos = new Vector3(
            Mathf.Cos(angle) * radius,
            0f,
            Mathf.Sin(angle) * radius
        );

        // ワールド座標に変換
        Vector3 spawnPos = center.position + pos;

        // プレハブを生成
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
