using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public enum ResourceType { Wood, Stone }
    public ResourceType resourceType;
    public int resourceAmount = 10;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResourceManager resourceManager = other.GetComponent<ResourceManager>();
            if (resourceManager != null)
            {
                if (resourceType == ResourceType.Wood)
                    resourceManager.GatherWood(resourceAmount);
                else if (resourceType == ResourceType.Stone)
                    resourceManager.GatherStone(resourceAmount);

                Destroy(gameObject); // Destroy the resource object once gathered
            }
        }
    }
}
