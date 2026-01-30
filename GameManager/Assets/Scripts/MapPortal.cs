using UnityEngine;

public class MapPortal : MonoBehaviour
{
    public int targetMapID;
    public int targetPortalID;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if(collision.CompareTag("Player"))
        {
            Debug.Log("Moving Maps");
            MapNavigation.instance.GoToMap(targetMapID, targetPortalID);
        }
    }

}
