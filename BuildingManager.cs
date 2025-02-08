using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject housePrefab;
    public Transform playerTransform;
    public ResourceManager resourceManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))  // Press B to build
        {
            if (resourceManager.wood >= 10 && resourceManager.stone >= 5)  // Example cost
            {
                BuildHouse();
                resourceManager.GatherWood(-10);  // Deduct resources
                resourceManager.GatherStone(-5);
            }
        }
    }

    void BuildHouse()
    {
        Instantiate(housePrefab, playerTransform.position + new Vector3(2, 0, 0), Quaternion.identity);
    }
}
