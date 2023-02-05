using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string Name;

    public List<Want> Wants;

    public List<CharacterLook> Look;

    public int InfoCost;

    public int NFCCost;

    public int BankAccount;

    public int Trust;

    public int Threat;

    public string ConversationStart;

    public string ConversationSuccess;

    public string ConversationFailure;

    public string ConversationScam;

    public Nationality Nationality;

    public List<NPC> Neighbours;

    public bool HasSucceeded;

    public bool HasFailed;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public void ShowMain(Transform profile)
    {
        foreach (var look in Look) {
            var newObj = Instantiate(look.GameObject, profile);
            newObj.layer = 0;
        }
    }

    public void ChangeExpression(Transform profile, GameObject newLook)
    {
        var replacementType = newLook.GetComponent<CharacterLook>().Type;
        var looks = profile.GetComponentsInChildren<CharacterLook>();

        foreach (var look in looks) {
            if (look.Type == replacementType) {
                Destroy(look.gameObject);
                var newObj = Instantiate(newLook, profile);
                newObj.layer = 0;
            }
        }
    }
}