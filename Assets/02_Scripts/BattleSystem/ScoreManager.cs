using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } = null;

    [SerializeField] int winningScore;

    Dictionary<int, int> playerScores = new Dictionary<int, int>();


    int killScoreReward = 1;

    private void Awake()
    {
        Instance = this;
    }
    public void Init()
    {
        // 모든 플레이어의 ActorNumber를 가져온다
        foreach (int actorNumber in PhotonNetwork.CurrentRoom.Players.Keys)
        {
            // ActorNumber와 매칭해서 점수를 0으로 초기화한다
            playerScores[actorNumber] = 0;
        }
    }
    public void AddScore(int killerActorNumber, int victimActorNumber) // 플레이어가 승리 점수에 도달했다면 true, 아닐경우 false
    {
        // 점수를 추가한다. 승리 조건 점수를 넘지 않도록 제한
        playerScores[killerActorNumber] = Mathf.Clamp(
            playerScores[killerActorNumber] + CalculateScore(killerActorNumber, victimActorNumber), 0, winningScore);

        // 우승 점수에 도달했을 때
        if (playerScores[killerActorNumber] == winningScore)
        {
            // 
        }
    }

    int CalculateScore(int killerActorNumber, int victimActorNumber)
    {
        return 1;
    }
}
