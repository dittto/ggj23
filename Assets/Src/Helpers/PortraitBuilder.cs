using System;
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

    public GameObject Happy;
    public GameObject Angry;
    public GameObject Passive;
    public GameObject Disappointed;

    public void UpdatePortrait(NPC npc)
    {
        UpdateName(npc.Name);

        var looks = npc.Look;

        Hair.SetActive(false);
        HairBack.SetActive(false);
        Face.SetActive(false);
        Expression.SetActive(false);


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
        UpdateImage(Happy.GetComponent<CharacterLook>(), Expression);
    }

    public void MakeAngry()
    {
        UpdateImage(Angry.GetComponent<CharacterLook>(), Expression);
    }

    public void MakeDisappointed()
    {
        UpdateImage(Disappointed.GetComponent<CharacterLook>(), Expression);
    }

    public void MakePassive()
    {
        UpdateImage(Passive.GetComponent<CharacterLook>(), Expression);
    }

    private void UpdateName(string name)
    {
        Name.text = name;
    }

    private void UpdateImage(CharacterLook look, GameObject target)
    {
        target.GetComponent<RawImage>().texture = look.Texture;
        target.GetComponent<RectTransform>().sizeDelta = new Vector2(look.SizeX, look.SizeY);
        target.GetComponent<RectTransform>().localPosition = new Vector3(look.OffsetX, look.OffsetY, 0);
        target.SetActive(true);
    }
}
