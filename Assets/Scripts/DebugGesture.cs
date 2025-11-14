using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugGesture : MonoBehaviour
{
    public GestureAction[] ges;
    public TextMeshProUGUI debugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string text = "";
        foreach (var gesture in ges)
        {
            text += "Gesture: " + gesture.gestureName + "\nActive: " + gesture.isGestureActive + '\n';
        }
        debugText.text = text;
    }
}
