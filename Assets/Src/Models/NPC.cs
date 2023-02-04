using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string Name;

    public List<Want> Wants;

    public List<CharacterLook> Look;

    public int Cost;

    public int BankAccount;

    public int Trust;

    public int Threat;

    public string ConversationStart;

    public string ConversationSuccess;

    public string ConversationFailure;

    public string ConversationScam;

    public Nationality Nationality;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public void ShowMain(Transform profile)
    {
        for (var i = 0; i < Look.Count; i++) {
            var newObj = Instantiate(Look[i]._gameObject, profile);
            newObj.layer = 0;
        }
    }
}