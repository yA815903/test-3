using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public InputField playerNameField;
    public Slider strengthSlider;
    public Slider agilitySlider;
    public Slider wisdomSlider;

    public Text confirmationText;

    // Character data storage
    private string playerName;
    private int strength;
    private int agility;
    private int wisdom;

    public void ConfirmCharacterCreation()
    {
        playerName = playerNameField.text;
        strength = (int)strengthSlider.value;
        agility = (int)agilitySlider.value;
        wisdom = (int)wisdomSlider.value;

        // Save data using PlayerPrefs (or another save system)
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("Strength", strength);
        PlayerPrefs.SetInt("Agility", agility);
        PlayerPrefs.SetInt("Wisdom", wisdom);

        confirmationText.text = "Character Created: " + playerName;
    }
}
using System.Collections;
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

public class QuestGiver : MonoBehaviour
{
    public QuestManager questManager;
    public Quest sampleQuest;

    public void OfferQuest()
    {
        questManager.AcceptQuest(sampleQuest);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public InputField playerNameField;
    public Slider strengthSlider;
    public Slider agilitySlider;
    public Slider wisdomSlider;

    public Text confirmationText;

    // Character data storage
    private string playerName;
    private int strength;
    private int agility;
    private int wisdom;

    public void ConfirmCharacterCreation()
    {
        playerName = playerNameField.text;
        strength = (int)strengthSlider.value;
        agility = (int)agilitySlider.value;
        wisdom = (int)wisdomSlider.value;

        // Save data using PlayerPrefs (or another save system)
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("Strength", strength);
        PlayerPrefs.SetInt("Agility", agility);
        PlayerPrefs.SetInt("Wisdom", wisdom);

        confirmationText.text = "Character Created: " + playerName;
    }
}
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
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestManager questManager;
    public Quest sampleQuest;

    public void OfferQuest()
    {
        questManager.AcceptQuest(sampleQuest);
    }
}
public class QuestGiver : MonoBehaviour
{
    public QuestManager questManager;

    private void Start()
    {
        Quest sampleQuest = new Quest("Defend the Kingdom", "Help King Alfred defend his kingdom from Viking raiders.");
        questManager.AcceptQuest(sampleQuest);
    }

    // For NPC interaction
    public void OfferQuest()
    {
        questManager.CompleteCurrentQuest(); // Complete a quest
    }
}
public Text questLogText;

public void AcceptQuest(Quest newQuest)
{
    currentQuest = newQuest;
    questLogText.text = "Quest: " + currentQuest.questName + "\n" + currentQuest.questDescription;
}
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // You can trigger death animations or game over screen here.
    }
}
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died.");
        // Optionally, add animations or effects for death.
        Destroy(gameObject); // Destroy enemy on death.
    }
}
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 10;  // Set the damage of the player’s attack
    public float attackRange = 2.0f;  // The range of the attack
    public LayerMask enemyLayer;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Left mouse button or a key
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int attackDamage = 5;  // Set enemy attack damage
    public float attackRange = 1.5f;  // Enemy attack range
    public LayerMask playerLayer;

    public void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
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
