using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostScamBuilder : MonoBehaviour
{
    public TMP_Text Response;

    public GameObject RestartButton;

    public GameObject ContinueButton;

    public void UpdateData(NPC data, GameLoop.State state)
    {
        if (state == GameLoop.State.Safe || state == GameLoop.State.Scam) {
            Response.text = state == GameLoop.State.Safe ? data.ConversationSuccess : data.ConversationScam;
            ContinueButton.SetActive(true);
            RestartButton.SetActive(false);
        }

        else {
            Response.text = state == GameLoop.State.NoTargets ? "No targets remaining" : (state == GameLoop.State.NoMoney ?  "No money remaining" : "Ended");

            ContinueButton.SetActive(false);
            RestartButton.SetActive(true);
        }

    }
}
