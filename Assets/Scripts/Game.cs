using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const string WinMessage = "Вы победили\nНажмите F для рестарта";
    private const string LoseMessage = "Вы проиграли\nНажмите F для рестарта";

    [SerializeField] private Mover _ball;
    [SerializeField] private Coins _coins;
    [SerializeField] private TMP_Text _timerInfo;
    [SerializeField] private TMP_Text _coinsCountInfo;
    [SerializeField] private TMP_Text _gameResultInfo;

    [SerializeField] private float _startGameTime;

    private float _tempGameTime = 0;
    private float _gameTime;

    private Vector3 _startBallPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
        }

        ShowGameTimer();

        ShowCoinsCount();

        if (_gameTime > 0 && _coins.Count == 0)
        {
            _gameResultInfo.text = WinMessage;
            StopGame();
        }
        else if (_gameTime <= 0 && _coins.Count > 0)
        {
            _gameResultInfo.text = LoseMessage;
            StopGame();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _ball.GetComponent<Rigidbody>().isKinematic = false;
        _ball.transform.position = _startBallPosition;
        _tempGameTime = 0;
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
        _ball.GetComponent<Rigidbody>().isKinematic = true;
        _coins.MakeInactive();
        _gameTime = 0;
    }

    private void RestartGame()
    {
        _gameResultInfo.text = null;
        _coins.Respawn();

        StartGame();
    }

    private void ShowCoinsCount()
    {
        _coinsCountInfo.text = _coins.Count.ToString();
    }

    private void ShowGameTimer()
    {
        _tempGameTime += Time.deltaTime;
        _gameTime = _startGameTime - _tempGameTime;
        _timerInfo.text = (_gameTime).ToString("0.00");
    }
}