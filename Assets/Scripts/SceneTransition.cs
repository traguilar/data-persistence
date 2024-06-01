using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public TextMeshProUGUI nameField;
    public void LaunchGame()
    {
        string playerName = nameField.text;
        // Buggy
        if (playerName == "a")
        {
            playerName = DataManager.instance.GetRandomName();
            print("pas de nom choisi");
        }
        DataManager.instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }
}
