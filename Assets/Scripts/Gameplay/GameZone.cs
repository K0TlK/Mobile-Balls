using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameZone : MonoBehaviour
{
    private void Start()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(VisibleZoneManager.Instance.Width * 2 + 2,
                                                         VisibleZoneManager.Instance.Height * 2 + 2);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BalloonController>(out BalloonController balloonController))
        {
            balloonController.Burst();
        }
        else
        {
            Debug.LogWarning($"{collision.gameObject.name} leave scene");
        }
    }
}
