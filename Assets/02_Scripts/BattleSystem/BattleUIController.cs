using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BattleUIController : MonoBehaviour, IOnEventCallback
{
    public static BattleUIController Instance { get; private set; } = null;
    
    [SerializeField] PlayerScoreEntry playerScoreEntryPrefab;

    [SerializeField] GameObject scoreboardPanel;

    [SerializeField] Transform scoreEntryParent;

    Dictionary<int, PlayerScoreEntry> playerScoreEntries = new Dictionary<int, PlayerScoreEntry>();

    private void Awake()
    {
        Instance = this;

        scoreboardPanel.SetActive(false);

        // 모든 플레이어의 ActorNumber를 가져온다
        foreach (int actorNumber in PhotonNetwork.CurrentRoom.Players.Keys)
        {
            // 비어있는 UI에 PlayerScoreEntry를 추가하고 Dictionary로 actorNumber와 매칭한다
            playerScoreEntries[actorNumber] = InstantiatePlayerScoreEntry(PhotonNetwork.CurrentRoom.Players[actorNumber]);
        }

        //생성 테스트
        //for (int i = 0; i < 6; i++) playerScoreEntries[0] = InstantiatePlayerScoreEntry(null);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowScoreboard();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            HideScoreboard();
        }
    }
    void ShowScoreboard()
    {
        scoreboardPanel.SetActive(true);
    }
    void HideScoreboard()
    {
        scoreboardPanel.SetActive(false);
    }
    public void OnEvent(EventData photonEvent)
    {
        switch ((RaiseEventCode)photonEvent.Code)
        {
            case RaiseEventCode.ModifyScore:    // 점수 변경 이벤트
                ModifyScore(photonEvent); break;
        }
    }
    void ModifyScore(EventData photonEvent)
    {
        int actorNumber = ((int[])photonEvent.CustomData)[0];
        int score = ((int[])photonEvent.CustomData)[1];
    }
    PlayerScoreEntry InstantiatePlayerScoreEntry(Player player)
    {
        PlayerScoreEntry entry = Instantiate(playerScoreEntryPrefab, scoreEntryParent);

        entry.SetData(player);

        return entry;
    }
}