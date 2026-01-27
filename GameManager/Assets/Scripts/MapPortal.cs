using UnityEngine;

public class MapPortal : MonoBehaviour
{
    public int targetMapID;
    public int targetPortalID;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MapNavigation.instance.GoToMap(targetMapID, targetPortalID);
        }
    }
}
