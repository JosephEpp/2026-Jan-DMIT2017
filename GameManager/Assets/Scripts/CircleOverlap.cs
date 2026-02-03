using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CircleOverlap : MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask hitLayers;
    public event Action<Vector3> OnOverlap;

    public string tagToCheck;
    public Color color;
    void Update()
    {
        CustomDebug.DrawDebugCircle(transform.position, radius, color, 50);
    }

    public bool OverlapCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag(tagToCheck))
            {
                OnOverlap?.Invoke(hit.gameObject.transform.position);
                return true;
            }
        }

        return false;
    }

   
}