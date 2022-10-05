using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleZoneManager : Singleton<VisibleZoneManager>
{
    [SerializeField] private Camera mainCamera;
    private float height;
    private float width;
    public float Height => height;
    public float Width => width;


    private void Awake()
    {
        height = mainCamera.orthographicSize;
        width = mainCamera.orthographicSize * mainCamera.aspect;
        Debug.Log($"{height}:{width} => {height / mainCamera.orthographicSize}:{width / mainCamera.orthographicSize}");
    }
}
