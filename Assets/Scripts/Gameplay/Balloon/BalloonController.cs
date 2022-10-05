using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class BalloonController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isActive = false;

    public bool Active => isActive;

    public void SetNewColor()
    {
        spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 0.5f, 0.8f);
    }

    public void SetRandomScale()
    {
        float scale = Random.Range(0.3f, 0.6f);
        transform.localScale = new Vector3(scale, scale);
    }

    public void Burst()
    {
        BalloonSpawner.Instance.ReturnBallon(this);
        gameObject.SetActive(false);
    }
}
