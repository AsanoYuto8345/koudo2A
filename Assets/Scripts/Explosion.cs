using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 1f;
    public GameObject explosionEffect;

    void Start()
    {
        StartCoroutine(PlayExplosion());
    }

    IEnumerator PlayExplosion()
    {
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
