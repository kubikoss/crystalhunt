using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager GameManagerInstance => _gameManager;

    [SerializeField] Transform _playerTransform;
    public Transform PlayerTransform => _playerTransform;

    private GameManager() { }
    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        }
    }
}
