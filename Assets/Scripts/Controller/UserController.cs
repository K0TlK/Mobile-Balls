using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class UserController : Singleton<UserController>
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float rayDistance = 1f;

    private Vector3 direction;

    public UnityEvent BallonWasReterned;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        direction = mainCamera.transform.position;
    }


    void Update()
    {
        if (CheckClick())
        {
            OnDrag();
        }
    }

    private bool CheckClick()
    {
        bool isClick = Input.GetMouseButton(0);
        return isClick;
    }

    private void OnDrag()
    {
        Vector3 tmp = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, rayDistance));
        Debug.DrawRay(tmp, direction, Color.red);
        RaycastHit2D[] hits = Physics2D.RaycastAll(tmp, direction);

        foreach (RaycastHit2D obj in hits)
        {
            if (obj.collider.TryGetComponent<BalloonController>(out BalloonController balloonController))
            {
                PointerCounter.Instance.AddPoint();
                balloonController.Burst();
                BallonWasReterned.Invoke();
            }
        }
    }
}
