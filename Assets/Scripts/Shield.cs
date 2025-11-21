using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string[] collisionTags;
    public Renderer shiledRenderer;

    public wvoid activeShield()
    {
        shiledRenderer.enabled = true;
    }

    public void deactivateShield()
    {
        shiledRenderer.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in collisionTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Destroy(collision.gameObject);
                break;
            }
        }
    }
}
