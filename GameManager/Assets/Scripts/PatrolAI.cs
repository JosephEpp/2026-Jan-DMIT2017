using System.Collections;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public Vector2 maxRange;
    private Vector2 startingPosition;
    public Vector2 newPosition;
    private void Start()
    {
        startingPosition = transform.position;
    }
    [ContextMenu("gegesga")]
    public void GetRandomPositionInRange()
    {
        newPosition = new Vector2(Random.Range(startingPosition.x - maxRange.x, startingPosition.x + maxRange.x), 
            Random.Range(startingPosition.y - maxRange.y, startingPosition.y + maxRange.y));

        StartCoroutine(PatrolCoroutine(newPosition));
    }


    private IEnumerator PatrolCoroutine(Vector3 newPos)
    {
        bool inRange = false;
        while (!inRange)
        {
            Vector2 moveDir = newPos - transform.position;
            moveDir.Normalize();
            GetComponent<Rigidbody2D>().linearVelocity = moveDir * 2.0f;
            inRange = (Vector2.Distance(transform.position, newPos) < 1.0f);
            if (inRange) GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            yield return null;
        }
        yield return null;
       
    }
}
