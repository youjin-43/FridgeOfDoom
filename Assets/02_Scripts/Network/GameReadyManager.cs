using UnityEngine;
using Photon.Pun; // Pun : 포톤 유니티 네트워크의 약자
using Photon.Realtime; // 실시간 통신? 을 위해서

public class GameReadyManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab; // 인스펙터에서 할당 
    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            // 네트워크를 통해 플레이어 생성 (모든 클라이언트에게 공유됨)
            PhotonNetwork.Instantiate(playerPrefab.name, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    // 랜덤한 위치에서 스폰하도록 설정
    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, 10f, z);
    }
}
