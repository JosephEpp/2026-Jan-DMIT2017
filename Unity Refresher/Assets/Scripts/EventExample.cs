using UnityEngine;
using UnityEngine.Events;

public class EventExample : MonoBehaviour
{
    //events have 2 components
    //  flags
    //  subscribers
    //
    //when a flag is raised, all of the subscribers attached to it are called

    public UnityEvent onCoinCollected;

    int coins = 0;

    [ContextMenu("Collect Coin")]

    public void CollectCoin()
    {
        onCoinCollected?.Invoke();
    }
}
