using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;

    public void GatherWood(int amount)
    {
        wood += amount;
        Debug.Log("Wood gathered: " + wood);
    }

    public void GatherStone(int amount)
    {
        stone += amount;
        Debug.Log("Stone gathered: " + stone);
    }
}
