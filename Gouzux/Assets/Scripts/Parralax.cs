using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public Vector3 movementScale = Vector3.one;
    private Transform _camera;

    void Awake()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Scale(_camera.position, movementScale);
    }
}
