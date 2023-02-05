using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTreeLook : MonoBehaviour
{
    public enum LookType { Branches, Trunk, Roots }

    public LookType Type;

    public GameObject GameObject;

    public List<Want> Wants;

    public void Start()
    {

    }
}
