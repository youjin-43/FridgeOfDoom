using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } = null;

    Dictionary<int, int> playerScores = new Dictionary<int, int>();

    int killScoreReward = 1;

    private void Awake()
    {
        Instance = this;

        Init();
    }
    public void Init()
    {
        // ��� �÷��̾��� ActorNumber�� �����´�
        foreach (int actorNumber in PhotonNetwork.CurrentRoom.Players.Keys)
        {
            // ActorNumber�� ��Ī�ؼ� ������ 0���� �ʱ�ȭ�Ѵ�
            playerScores[actorNumber] = 0;
        }

        killScoreReward = 1;
    }
    public void AddScore(int killerActorNumber) 
    {
        // ���� �߰�
        playerScores[killerActorNumber] += killScoreReward;
    }
    public void ModifyKillReward(int reward)
    {
        killScoreReward = reward;
    }
}
