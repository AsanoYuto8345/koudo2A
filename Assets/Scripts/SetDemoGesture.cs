using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDemoGesture : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] demoGestures;
    // Start is called before the first frame update
    void Start()
    {
        SetDemoGestureByIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDemoGestureByIndex(int index)
    {
        if (index >= 0 && index < demoGestures.Length)
        {
            GameObject obj = Instantiate(demoGestures[index]);
            obj.transform.parent = camera.transform;
            obj.transform.localPosition = new Vector3(-3f, 0f, 3f);
        }
    }
}
