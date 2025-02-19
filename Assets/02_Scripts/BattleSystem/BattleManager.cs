using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleManager : MonoBehaviourPunCallbacks
{
    public static BattleManager Instance { get; private set; } = null;

    public Image fadeImage;

    public int winningScore;

    [SerializeField] bool isFade;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {

    }
    /// <summary>
    /// 킬이 발생했을 경우 죽인 사람에게 1 포인트를 주며
    /// 게임을 진행하는 킬 레이스 방식
    /// </summary>
    /// <param name="killerActorNumber">죽인 사람</param>
    /// <param name="victimActorNumber">죽은 사람</param>
    public static void RegisterKill(int killerActorNumber, int victimActorNumber)
    {
        // 호스트가 아닌 경우 반환시킴
        if (!PhotonNetwork.IsMasterClient) return;

        // 죽인 플레이어의 점수를 1 높인다
        ScoreManager.Instance.AddScore(killerActorNumber, 1);

    }

    public override void OnLeftRoom() // 로컬 플레이어(자신)가 방을 떠날 때 호출
    {
        base.OnLeftRoom();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) // 타 플레이어가 방을 떠날 때 호출
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }
}