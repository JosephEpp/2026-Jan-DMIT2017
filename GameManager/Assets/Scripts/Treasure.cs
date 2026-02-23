using UnityEngine;

public class Treasure : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;

    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = closedSprite;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Interact();
        }
    }

    public void Interact()
    {
        // add coins
        GameStateManager.instance.treasure++;

        // play sound

        // ui element update

        //change sprite
        sp.sprite = openSprite;
    }
}
