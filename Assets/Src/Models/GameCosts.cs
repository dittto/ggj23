using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCosts : MonoBehaviour
{
    public double WantFullMatch = 1.0;
    public double WantPartialMatch = 0.5;
    public double WantNoMatch = -0.5;

    public int TrustForNFT = 20;

    public double NFTMultiplier = 0.5;
    public double NFTHackMultiplier = 3.0;

    public double ThreatMultiplier = 1.0;
}
