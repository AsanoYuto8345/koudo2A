using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string[] collisionTags;
    public Renderer shiledRenderer;

    public void activeShield()
    {
        shiledRenderer.enabled = true;
    }

    public void deactivateShield()
    {
        shiledRenderer.enabled = false;
    }
}
