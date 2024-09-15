using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject targetsParent; // Assign the "Targets" GameObject here
    public Text timerText;
    public Text scoreMessageText; // Reference to the Score Message UI Text
    public int totalTargets = 5;

    private float timer;
    private int targetsHit;
    private LevelManager levelManager; // Reference to LevelManager

    void Start()
    {
        timer = 0f;
        targetsHit = 0;
        scoreMessageText.gameObject.SetActive(false); // Hide the message initially
        levelManager = FindObjectOfType<LevelManager>(); // Find LevelManager in the scene
    }

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerText();

        if (targetsHit >= totalTargets)
        {
            StopTimer();
        }
    }

    public void TargetHit()
    {
        targetsHit++;
    }

    void UpdateTimerText()
    {
        timerText.text = $"Time: {Mathf.Round(timer)}s";
    }

    void StopTimer()
    {
        scoreMessageText.text = $"You got {Mathf.Round(timer)} seconds!";
        scoreMessageText.gameObject.SetActive(true);
        Time.timeScale = 0; // Pause the game

        // Proceed to the next level
        if (levelManager != null)
        {
            levelManager.LoadNextLevel();
        }
    }
}
