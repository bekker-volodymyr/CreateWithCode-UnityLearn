using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype5
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreTMP;
        private int _score;

        [SerializeField]
        private GameObject _gameOverPanel;
        public bool IsGameActive = true;

        [SerializeField]
        private List<GameObject> _prefabs;

        [SerializeField]
        private float _spawnRate = 1f;

        private IEnumerator SpawnObjects()
        {
            while (IsGameActive)
            {
                yield return new WaitForSeconds(_spawnRate);
                Instantiate(_prefabs[Random.Range(0, _prefabs.Count)]);
                //UpdateScore(5);
            }
        }

        public void UpdateScore(int scoreAdd)
        {
            _score += scoreAdd;
            _scoreTMP.text = "Score:" + _score;
        }

        public void StartGame(int difficulty)
        {
            _spawnRate /= difficulty;
            StartCoroutine(SpawnObjects());
            _scoreTMP.text = "Score:" + _score;
        }

        public void GameOver()
        {
            IsGameActive = false;
            _gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}