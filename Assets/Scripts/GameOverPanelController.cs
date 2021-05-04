using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    void Start()
    {
        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        GameController.singleton.NewGame();
        SceneManager.LoadScene("GameScene");
    }
}
