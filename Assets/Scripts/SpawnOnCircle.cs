using UnityEngine;

public class SpawnOnCircle : MonoBehaviour
{
    [Header("中心となるオブジェクト")]
    public Transform center;

    [Header("複製するプレハブ")]
    public GameObject prefab;

    [Header("配置する数")]
    public int count = 8;

    [Header("半径")]
    public float radius = 3f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        if (center == null || prefab == null)
        {
            Debug.LogError("centerまたはprefabが設定されていません");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            // 円周上の角度を計算
            float angle = i * Mathf.PI * 2f / count;

            // 半径分ずらした座標 (X-Z 平面)
            Vector3 pos = new Vector3(
                Mathf.Cos(angle) * radius,
                0f,
                Mathf.Sin(angle) * radius
            );

            // ワールド位置に変換
            Vector3 spawnPos = center.position + pos;

            // プレハブを生成
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
