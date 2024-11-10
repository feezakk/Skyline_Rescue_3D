using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public TMP_InputField playerNameInputField; // Reference to TextMesh Pro Input Field
    public Button startGame;                     // Reference to the Start Button
    public TMP_Dropdown difficultyDropdown;
    
    public PlayerDataManager playerDataManager; // Reference to the PlayerDataManager script

    private string selectedDifficulty;      // Store the selected difficulty
    public static int score = 0; // Increase score by 10 for each fuel point
    
    public static string playerName = "";

    void Start()
    {
        // Check for null references
        if (playerNameInputField == null)
        {
            Debug.LogError("Player Name Input Field is not assigned in the Inspector!");
        }
        if (startGame == null)
        {
            Debug.LogError("Start Button is not assigned in the Inspector!");
        }
        if (difficultyDropdown == null)
        {
            Debug.LogError("Difficulty Dropdown is not assigned in the Inspector!");
        }

        // Disable the start button initially
        startGame.interactable = false;

        // Add listeners to input field and dropdown to check for changes
        playerNameInputField.onValueChanged.AddListener(delegate { CheckStartConditions(); });
        difficultyDropdown.onValueChanged.AddListener(delegate { OnDifficultyChanged(); });
    }

    // Method called when the Start button is clicked
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(playerNameInputField.text) && !string.IsNullOrEmpty(selectedDifficulty))
        {
            // Save the player name to the PlayerDataManager
            //playerDataManager.SetPlayerName(playerNameInputField.text);

            // Save the selected difficulty to the PlayerDataManager (optional)
            //playerDataManager.SetSelectedDifficulty(selectedDifficulty);

            //Debug.LogError("Loading Scene!");
            
            playerName = playerNameInputField.text;

            Debug.Log("start clicked");

            // Load the game scene
            SceneManager.LoadScene("fwOF_FreeDemo_OldForest");
        }
        else
        {
            Debug.LogError("Player name or difficulty not selected!");
        }
    }

    // Method to update the selected difficulty
    void OnDifficultyChanged()
    {
        selectedDifficulty = difficultyDropdown.options[difficultyDropdown.value].text;
        CheckStartConditions();
    }

    // Check if both player name and difficulty are selected to enable the Start button
    void CheckStartConditions()
    {
        // Enable the start button if the player name is not empty and a difficulty is selected
        startGame.interactable = !string.IsNullOrEmpty(playerNameInputField.text) && difficultyDropdown.value != 0;
    }
}

