using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainSetup : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private NPC _npcTest;

    [SerializeField]
    private NPC _npcTest2;

    public PortaitHelper PortaitHelper;

    public void Start()
    {
        StartCoroutine(WaitForFunction());
    }

    public void Update()
    {

    }

    private IEnumerator WaitForFunction()
    {
        PortaitHelper.ShowPortrait(_npcTest);

        yield return new WaitForSeconds(2);

        PortaitHelper.MakeHappy();

        yield return new WaitForSeconds(2);

        PortaitHelper.MakeAngry();

        yield return new WaitForSeconds(2);

        PortaitHelper.ShowPortrait(_npcTest2);
    }
}
