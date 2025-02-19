using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

public class BattleUIController : MonoBehaviour, IOnEventCallback
{
    public static BattleUIController Instance { get; private set; } = null;

    public void OnEvent(EventData photonEvent)
    {
        switch ((RaiseEventCode)photonEvent.Code)
        {
            case RaiseEventCode.ModifyScore:    // ���� ���� �̺�Ʈ
                ModifyScore(photonEvent); break;
        }
    }
    void ModifyScore(EventData photonEvent)
    {
        int actorNumber = ((int[])photonEvent.CustomData)[0];
        int score = ((int[])photonEvent.CustomData)[1];


    }
    private void Awake()
    {
        Instance = this;
    }
}