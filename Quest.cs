using UnityEngine;

public class Quest
{
    public string questName;
    public string questDescription;
    public bool isCompleted;

    public Quest(string name, string description)
    {
        questName = name;
        questDescription = description;
        isCompleted = false;
    }

    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log("Quest Completed: " + questName);
    }
}
