using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public GameObject nameInput;

    public void StartGame()
    {
        SaveManager.instance.currentPlayer = nameInput.GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }

}
