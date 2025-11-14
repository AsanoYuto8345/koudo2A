using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 1f;
    public GameObject explosionEffect;

    void Start()
    {
        explosionEffect.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TriggerExplosion(new Vector3(10f, 5f, 30f));
        }
    }

    public void TriggerExplosion(Vector3 pos)
    {
        StartCoroutine(Explode(pos));
    }

    IEnumerator Explode(Vector3 pos)
    {
        explosionEffect.transform.position = pos;
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(lifeTime);
        explosionEffect.SetActive(false);
    }
}
