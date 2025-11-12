using Prototype5;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _titleScreen;

    [SerializeField]
    private int _difficulty;

    private Button _button;

    private GameManager _gameManager;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        _titleScreen.SetActive(false);
        _gameManager.StartGame(_difficulty);
    }
}
