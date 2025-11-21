using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 1f;
    public GameObject explosionEffect;

    public General general;

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
        StartCoroutine(PlayExplosion());
    }

    IEnumerator PlayExplosion()
    {
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("爆発衝突");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (general != null) general.score += 100;
            Destroy(collision.gameObject);
        }
    }
}
