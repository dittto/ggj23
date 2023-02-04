using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    enum Type { Hair, Face, Expression }

    [SerializeField]
    private Type _type;

    [SerializeField]
    public GameObject _gameObject;

    public void Start()
    {

    }

    public void Update()
    {

    }
}