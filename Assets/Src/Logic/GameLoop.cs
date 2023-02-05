using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLoop : MonoBehaviour
{
    public enum State { Safe, Scam, NoMoney, NoTargets, End };

    public Player Player;

    public GameCosts GameCosts;

    public ScamTree ScamTree;

    #nullable enable
    public NPC? ActiveMark = null;

    public void Start()
    {
    }

    /// <summary>
    /// Trigger this at the start to reset the variables required for the game
    /// </summary>
    public void ResetGameLoop()
    {
        ActiveMark = null;

        foreach (var npc in ScamTree.NPCs) {
            npc.HasSucceeded = false;
            npc.HasFailed = false;
        }

        Player.Reset();
    }

    /// <summary>
    /// Gets the list of NPCs for the player to choose one
    /// </summary>
    /// <returns>A list of NPCs</returns>
    public List<NPC> GetPotentialMarks()
    {
        if (ActiveMark == null) {
            return new List<NPC> { ScamTree.StartNPC };
        }

        var neighbours = ActiveMark.Neighbours;
        var newNeighbours = new List<NPC>();
        foreach (var npc in neighbours) {
            if (!npc.HasSucceeded && !npc.HasFailed) {
                newNeighbours.Add(npc);
            }
        }

        return newNeighbours;
    }

    /// <summary>
    /// The mark selected to make active
    /// </summary>
    public void SelectMark(NPC mark)
    {
        ActiveMark = mark;

        Player.UpdateMoney(-mark.InfoCost);

    }

    /// <summary>
    /// Once the trade is ready, submit the chosen parts of the NFTree and if you're scamming the mark
    /// </summary>
    /// <param name="treeLook">The parts of the NFTree</param>
    /// <param name="isScam">A flag for if this a scam or not</param>
    /// <returns>the expected game state</returns>
    public State Trade(List<NFTreeLook> treeLooks, bool isScam)
    {
        if (ActiveMark == null) {
            return State.NoTargets;
        }

        var totalWantPercent = GetTotalWantPercent(treeLooks);
        var markPercent = ActiveMark.Wants.Count * 100;
        var trustMultiplier = totalWantPercent >= markPercent ? 1 : (totalWantPercent == 0 ? -0.5 : 0.5);

        Player.UpdateTrust((int)Math.Ceiling(GameCosts.TrustForNFT * trustMultiplier));
        Player.UpdateMoney(-ActiveMark.NFCCost);
        Player.UpdateMoney((int)Math.Ceiling(GameCosts.NFTMultiplier * ActiveMark.NFCCost));

        if (isScam) {
            Player.UpdateMoney((int)Math.Ceiling(GameCosts.NFTHackMultiplier * ActiveMark.NFCCost));
        }

        var foundScam = false;
        if (isScam && Random.Range(0, 100) > (Player.GetNormalisedTrust() - ActiveMark.Threat)) {
            Player.UpdateTrust(-(int)Math.Ceiling(GameCosts.ThreatMultiplier * ActiveMark.Threat));
            foundScam = true;
        }

        if (Player.Money < 0) {
            return State.NoMoney;
        }

        if (ScamTree.EndNPC == ActiveMark) {
            return State.End;
        }

        if (GetPotentialMarks().Count == 0) {
            return State.NoTargets;
        }

        return foundScam ? State.Scam : State.Safe;
    }

    private int GetTotalWantPercent(List<NFTreeLook> treeLooks)
    {
        if (ActiveMark == null) {
            return 0;
        }

        var totalWantPercent = 0;
        foreach (var want in ActiveMark.Wants) {
            var found = false;
            foreach (var treeLook in treeLooks) {
                foreach (var treeWant in treeLook.Wants) {
                    if (treeWant == want && !found) {
                        totalWantPercent += 100;
                        found = true;
                    }

                    if (!found) {
                        for (var i = 0; i < treeWant.SimilarWants.Count; i++) {
                            var similarTreeWant = treeWant.SimilarWants[i];
                            if (similarTreeWant == want) {
                                totalWantPercent += treeWant.SimilarWantPercents[i];
                                found = true;
                            }

                        }
                    }
                }
            }
        }

        return totalWantPercent;
    }
}
