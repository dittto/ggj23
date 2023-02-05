using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortraitBuilder : MonoBehaviour
{
    public TMP_Text Name;

    public GameObject Hair;
    public GameObject HairBack;
    public GameObject Face;
    public GameObject Expression;

    public void UpdatePortrait(NPC npc)
    {
        UpdateName(npc.name);

        var looks = npc.Look;

        foreach (var look in looks) {
            if (look.Type == CharacterLook.LookType.Face) {
                UpdateImage(look, Face);
            }
            if (look.Type == CharacterLook.LookType.Hair) {
                UpdateImage(look, Hair);
            }
            if (look.Type == CharacterLook.LookType.HairBack) {
                UpdateImage(look, HairBack);
            }
            if (look.Type == CharacterLook.LookType.Expression) {
                UpdateImage(look, Expression);
            }
        }
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
        // Name.text = name;
    }

    private void UpdateExpression(GameObject expression)
    { 
    }

    private void UpdateImage(CharacterLook look, GameObject target)
    {
        target.GetComponent<RawImage>().texture = look.Texture;
        target.GetComponent<RectTransform>().position = new .x = look.OffsetX;
        target.GetComponent<RectTransform>().position.x = look.OffsetX;
    }
}
