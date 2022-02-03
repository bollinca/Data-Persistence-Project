using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public GameObject nameInput;

    public void StartGame()
    {
        SaveManager.playerName = nameInput.GetComponent<TMPro.TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }
}
