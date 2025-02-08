using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest currentQuest;

    public void AcceptQuest(Quest newQuest)
    {
        currentQuest = newQuest;
        Debug.Log("New Quest Accepted: " + currentQuest.questName);
    }

    public void CompleteCurrentQuest()
    {
        if (currentQuest != null && !currentQuest.isCompleted)
        {
            currentQuest.CompleteQuest();
            // Additional logic like rewarding the player, changing relationships, etc.
        }
    }
}
