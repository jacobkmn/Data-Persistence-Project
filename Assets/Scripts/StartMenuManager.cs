using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public string playerName;
    public GameObject inputField;
    public Button button;
    public Text Record;
    public Text RecordHolder;

    private void Start()
    {
        button.onClick.AddListener(LoadGameStart);

        Record.text = "Record: " + DataManager.instance.BestScore.ToString();
        RecordHolder.text = "Set By: " + DataManager.instance.BestScoreHolder;
    }

    void LoadGameStart()
    {
        playerName = inputField.GetComponent<Text>().text;
        if (playerName != "")
        {
            DataManager.instance.currentPlayerName = playerName;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
