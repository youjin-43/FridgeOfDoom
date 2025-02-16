using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    public float speed = 10f;
    public float destroyTime = 1f;

    private void Start()
    {
        if (photonView.IsMine) // 내 총알만 속도 적용
        {
            GetComponent<Rigidbody>().linearVelocity = transform.up * speed;
        }

        Destroy(gameObject, destroyTime); // 3초 후 자동 제거
    }
}