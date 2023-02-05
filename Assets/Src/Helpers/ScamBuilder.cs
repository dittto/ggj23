using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScamBuilder : MonoBehaviour
{
    public TMP_Text Request;

    public TMP_Text ThreatLevel;

    public TMP_Text Cost;

    public void UpdateData(NPC data)
    {
        Request.text = data.ConversationStart;
        ThreatLevel.text = data.Threat < 20 ? "Low" : (data.Threat > 50 ? "High" : "Average");
        Cost.text = "$" + data.NFCCost;
    }
}
