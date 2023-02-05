using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortraitBuilder : MonoBehaviour
{
    [SerializeField]
    private PortaitHelper _portaitHelper;

    [SerializeField]
    private Transform _portraitAnchor;

    public TMP_Text _portraitName;

    public void UpdatePortrait(NPC npc)
    {
        UpdateName(npc.name);

        // TODO: update hair

        // TODO: update face

        // TODO: update expression

        // TODO: update hair back
    }

    public void MakeHappy()
    {
        // _npc.ChangeExpression(Profile, Happy.GameObject);
    }

    public void MakeAngry()
    {
        // _npc.ChangeExpression(Profile, Angry.GameObject);
    }

    public void MakeDisappointed()
    {
        // _npc.ChangeExpression(Profile, Disappointed.GameObject);
    }

    public void MakePassive()
    {
        // _npc.ChangeExpression(Profile, Passive.GameObject);
    }

    private void UpdateName(string name)
    {
        // _portraitName.text = name;
    }

    private void UpdateExpression(GameObject expression)
    { 
    }

    private void UpdateImage(CharacterLook look, GameObject target)
    { 
    }
}
