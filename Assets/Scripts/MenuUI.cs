using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField PlayerNameInput;
    public TMP_Text BestScoreText;

    public void Start()
    {
        MenuManager.Instance.LoadBestScore();
        BestScoreText.text = "Best Score: " + MenuManager.Instance.BestPlayer + " : " + MenuManager.Instance.BestScore;
    }

    public void StartGame()
    {
        MenuManager.Instance.PlayerName = PlayerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity player 
#endif
    }
}
