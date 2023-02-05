using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money;

    public int Trust;

    public List<CharacterLook> Look;

    [SerializeField]
    private int _startMoney;

    [SerializeField]
    private int _startTrust;

    [SerializeField]
    private PlayerStore _playerStore;


    public void Start()
    {
        if (_playerStore.GameStarted) {
            Money = _startMoney;
            Trust = _startTrust;

            _playerStore.Money = Money;
            _playerStore.Trust = Trust;

            _playerStore.GameStarted = true;
        }

        Money = _playerStore.Money;
        Trust = _playerStore.Trust;
    }

    public void UpdateMoney(int difference)
    {
        Money += difference;

        _playerStore.Money = Money;
    }

    public void UpdateTrust(int difference)
    {
        Trust += difference;

        if (Trust < -100) { 
            Trust = -100;
        }

        if (Trust > 100) {
            Trust = 100;
        }

        _playerStore.Trust = Trust;
    }

    public int GetNormalisedTrust()
    {
        return (Trust + 100) / 2;
    }

    public void Reset()
    {
        _playerStore.GameStarted = false;

        Start();
    }
}