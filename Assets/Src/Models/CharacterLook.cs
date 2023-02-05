using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    public enum LookType { Hair, HairBack, Face, Expression }

    public LookType Type;

    public Texture2D Texture;

    public int OffsetX;

    public int OffsetY;

    public int SizeX;

    public int SizeY;

    public GameObject GameObject;
}