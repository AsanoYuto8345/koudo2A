using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string[] collisionTags;
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
