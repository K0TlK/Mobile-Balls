using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private float step = 0.5f;
    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveX(transform.position.x + step, 1f));
        sequence.Append(transform.DOMoveX(transform.position.x, 1f));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}
