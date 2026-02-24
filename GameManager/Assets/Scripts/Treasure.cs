using UnityEngine;

public class Treasure : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;

    public bool collected = false;

    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

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

        // play sound

        //change sprite
        sp.sprite = openSprite;
    }
}
