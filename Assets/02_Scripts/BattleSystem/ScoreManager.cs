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
        // ��� �÷��̾��� ActorNumber�� �����´�
        foreach (int actorNumber in PhotonNetwork.CurrentRoom.Players.Keys)
        {
            // ActorNumber�� ��Ī�ؼ� ������ 0���� �ʱ�ȭ�Ѵ�
            playerScores[actorNumber] = 0;
        }
    }
    public void AddScore(int killerActorNumber, int victimActorNumber) // �÷��̾ �¸� ������ �����ߴٸ� true, �ƴҰ�� false
    {
        // ������ �߰��Ѵ�. �¸� ���� ������ ���� �ʵ��� ����
        playerScores[killerActorNumber] = Mathf.Clamp(
            playerScores[killerActorNumber] + CalculateScore(killerActorNumber, victimActorNumber), 0, winningScore);

        // ��� ������ �������� ��
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
