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

    [System.Serializable]
    class SaveData
    {
        public string name;
        public string score;
    }

    private void Start()
    {
        button.onClick.AddListener(LoadGameStart);
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
}
