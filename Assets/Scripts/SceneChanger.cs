using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneChanger : MonoBehaviour
{
    public GameObject nameInput;

    // function assigned to start button onClick
    public void StartGame()
    {
        // set current player and load scene
        SaveManager.instance.currentPlayer = nameInput.GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }
}
