using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money { get; private set; }

    public int Trust { get; private set; }

    public List<CharacterLook> Look;

    private int _startMoney;
    private int _startTrust;


    public void Start()
    {
        _startMoney = Money;
        _startTrust = Trust;
    }

    public void UpdateMoney(int difference)
    {
        Money += difference;
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
    }

    public int GetNormalisedTrust()
    {
        return (Trust + 100) / 2;
    }

    public void Reset()
    {

        Money = _startMoney;
        Trust = _startTrust;
    }
}