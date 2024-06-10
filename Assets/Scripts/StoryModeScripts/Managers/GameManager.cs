using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager GameManagerInstance => _gameManager;

    [SerializeField] Transform _playerTransform;
    public Transform PlayerTransform => _playerTransform;

    [SerializeField] Transform _player2Transform;
    public Transform Player2Transform => _player2Transform;

    [SerializeField] public Player _Player;

    [SerializeField] public Player _Player2;

    public static int DifficultyLevel = 0;
    private GameManager() { }
    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        }
    }
}
