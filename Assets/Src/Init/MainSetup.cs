using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainSetup : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private NPC _npcTest;

    [SerializeField]
    private Transform _profile;

    public void Start()
    {
        _npcTest.transform.transform.localPosition = Vector3.zero;

        _npcTest.GetComponent<NPC>().ShowMain(_profile);
    }

    public void Update()
    {

    }
}
