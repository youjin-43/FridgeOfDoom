using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviour
{
    PhotonView pv;
    [SerializeField] GameObject bulletPrefab;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }


    public float speed = 5f;

    private void Update()
    {
        if (pv.IsMine) 
        {
            // 캐릭터 이동 
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
            transform.position += move;

            //총알 발사 
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                Fire();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                FireBullet();
            }
        }
    }

    void Fire()
    {
        PhotonNetwork.Instantiate("Bullet", transform.position + new Vector3(0,2,0), transform.rotation);
        Debug.Log(" 총알 발사!!!");
    }

    [PunRPC]
    void FireBullet_RPC()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(0, 2, 0), transform.rotation);
        Debug.Log("총알 발사!!!");
    }

    void FireBullet()
    {
        pv.RPC("FireBullet_RPC", RpcTarget.All);
    }
}
