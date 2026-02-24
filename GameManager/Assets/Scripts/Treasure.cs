using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Treasure : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;

    public bool collected;

    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

        StartCoroutine(SetSprite());
    }

    private IEnumerator SetSprite()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        collected = GameStateManager.instance.currentMapState.treasureCollected;
        if(collected)
        {
            sp.sprite = openSprite;
        }
        else
        {
            sp.sprite = closedSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collected)
        {
            Interact();
        }
    }

    public void Interact()
    {
        // add coins
        GameStateManager.instance.CollectTreasure();
        collected = true;

        // play sound

        //change sprite
        sp.sprite = openSprite;
    }
}
