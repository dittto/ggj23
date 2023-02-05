using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStore", menuName = "Persistence / PlayerStore")]
public class PlayerStore : ScriptableObject
{
    public bool GameStarted = false;

    public int Money = 0;

    public int Trust = 0;
}
