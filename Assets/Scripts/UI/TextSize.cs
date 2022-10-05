using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSize : MonoBehaviour
{
    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        RectTransform rect = GetComponent<RectTransform>();
        sequence.Append(rect.DOSizeDelta(new Vector2(0, 150),1));
        sequence.Append(rect.DOSizeDelta(new Vector2(0, 200), 1));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}
