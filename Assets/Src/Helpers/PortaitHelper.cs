using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaitHelper : MonoBehaviour
{
    private NPC _npc;

    public Transform Profile;

    public CharacterLook Happy;
    public CharacterLook Angry;
    public CharacterLook Disappointed;
    public CharacterLook Passive;

    public void RegisterProfile(Transform profileParent)
    { 
        Profile = profileParent;
    }

    public void ShowPortrait(NPC npc)
    {
        _npc = npc;

        var existing = Profile.gameObject.GetComponentsInChildren<Transform>();
        foreach (var transform in existing) {
            if (transform != Profile) {
                DestroyImmediate(transform.gameObject);
            }
        }

        _npc.ShowMain(Profile);
    }

    public void MakeHappy()
    {
        _npc.ChangeExpression(Profile, Happy.GameObject);
    }

    public void MakeAngry()
    {
        _npc.ChangeExpression(Profile, Angry.GameObject);
    }

    public void MakeDisappointed()
    {
        _npc.ChangeExpression(Profile, Disappointed.GameObject);
    }

    public void MakePassive()
    {
        _npc.ChangeExpression(Profile, Passive.GameObject);
    }
}
