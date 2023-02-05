using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScamTree : MonoBehaviour
{
    public List<NPC> NPCs;

    public NPC StartNPC;

    public NPC EndNPC;

    public NPC? FindByName(string name)
    {
        foreach (var npc in NPCs) {
            if (npc.gameObject.name == name) {
                return npc;
            }
        }

        return null;
    }
}