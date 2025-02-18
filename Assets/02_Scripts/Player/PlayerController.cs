using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviour
{
    PhotonView pv;
    [SerializeField] GameObject bulletPrefab;
    public GameObject bullet;   
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>(); // Rigidbody 가져오기
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
                ApplyUpwardForce();
            }
        }
    }

    void Fire()
    {
        PhotonNetwork.Instantiate("Bullet", transform.position + new Vector3(0,2,0), transform.rotation);
        Debug.Log(" 총알 발사!!!");
    }

    [PunRPC]
    void ApplyUpwardForce_RPC()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("🔥 위쪽으로 힘을 가했다!!!");
    }

    void ApplyUpwardForce()
    {
        pv.RPC("ApplyUpwardForce_RPC", RpcTarget.All);
    }

    public float jumpForce = 5f; // 위로 가해지는 힘
    private Rigidbody rb;
}
