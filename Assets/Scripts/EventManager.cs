using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventManager : MonoBehaviour
{
    //TODO Set OVRPlayerController
    [SerializeField] private Transform _player;
    //TODO Set RightHandAnchor
    [SerializeField] private Transform _controller;

    private LineRenderer _lineRenderer;

    private List<Vector3> _points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //initialize Line Renderer
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) // A Button Pressed
        {
            _lineRenderer.enabled = true;
        }

        if (OVRInput.Get(OVRInput.RawButton.A))     //A Button is being Down
        {
            _lineRenderer.positionCount = 2; //set point size and two points 
            _lineRenderer.SetPosition(0, _controller.position);
            _lineRenderer.SetPosition(1, _controller.position + _controller.forward * 10.0f);

            if (GetIntersection_RayToFloor(out Vector3 tmp))
                _lineRenderer.material.color = Color.green;
            else
                _lineRenderer.material.color = Color.red;
        }

        if (OVRInput.GetUp(OVRInput.RawButton.A)) //A Button released
        {
            _lineRenderer.enabled = false;
            if (GetIntersection_RayToFloor(out Vector3 pos))
                _player.position = pos + new Vector3(0, _player.position.y, 0); // Teleport!
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) //Pressed
        {
            //initialize _points and _lineRenderer
            _lineRenderer.enabled = true;
            _points.Clear();
            _points.Add(_controller.position);
            _lineRenderer.startWidth = 0.03f;
            _lineRenderer.endWidth = 0.03f;
            _lineRenderer.material.color = Color.green;
        }

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) //being pressed
        {
            _points.Add(_controller.position);
            _lineRenderer.positionCount = _points.Count;
            for (int i = 0; i < _points.Count; ++i)
                _lineRenderer.SetPosition(i, _points[i]);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) //Pressed
        {
            //Create stroke Object
            CreateStroke();
            //Clear _points and _lineRenderer
            _points.Clear();
            _lineRenderer.positionCount = 0;
            _lineRenderer.enabled = false;
        }
    }

    private bool GetIntersection_RayToFloor(out Vector3 pos)
    {
        pos = new Vector3(0, 0, 0);
        if (_controller.transform.forward.y >= 0) return false;

        float t = -_controller.position.y / _controller.forward.y;
        pos = _controller.position + t * _controller.forward;

        float dist = (_player.position - pos).magnitude;
        if (dist >= 10.0f) return false;//too far
        return true;
    }

    void CreateStroke()
    {
        //generate GameObject (name:stroke) and set material
        GameObject stroke = new GameObject("Stroke");
        stroke.AddComponent<LineRenderer>();
        LineRenderer line = stroke.GetComponent<LineRenderer>();
        line.material = _lineRenderer.material;
        line.startWidth = _lineRenderer.startWidth;
        line.endWidth = _lineRenderer.endWidth;

        //set one by one (are there better way??)
        line.positionCount = _points.Count;
        for (int i = 0; i < _points.Count; ++i)
            line.SetPosition(i, _points[i]);
    }
}