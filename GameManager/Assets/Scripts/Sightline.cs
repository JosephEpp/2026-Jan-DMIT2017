using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Sightline : MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask hitLayers;
    void Update()
    {
        CustomDebug.DrawDebugCircle(transform.position, radius, Color.red, 50);
    }

    public bool SightlineCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

   
}
