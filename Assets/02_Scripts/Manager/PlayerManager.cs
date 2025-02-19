using Photon.Pun.Demo.Asteroids;
using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StarterAssetsInputs input;
    public GameObject bulletPrefab; // ���� ������
    public Transform bulletSpawnPoint; // �������� ������ ��ġ
    public float bulletSpeed = 10f; // ������ �ʱ� �ӵ�
    public float bulletArc = 5f; // ������ ��� ����
    public Transform cameraTransform;
    [Header("Aim")]
    [SerializeField]
    private CinemachineVirtualCamera aimCam;
    [SerializeField]
    private LayerMask targetLayer;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookSameCameraDirection();

        if (input.aim)
        {
            aimCam.gameObject.SetActive(true);
        }
        else
        {
            aimCam.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F)) // �߻� �Է� ���� (Fire1 ��ư)
        {
            anim.SetBool("Shoot", true);
        }
    }

    void ThrowProjectile()
    {
        
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            GameObject projectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 throwDirection = cameraTransform.forward * bulletSpeed + Vector3.up * bulletArc;
                rb.linearVelocity = throwDirection;
            }
        }
    }

    public void EndShoot()
    {
        anim.SetBool("Shoot", false);
    }

    void LookSameCameraDirection()
    {
        Transform camTransform = Camera.main.transform;
        RaycastHit hit;
        Vector3 targetPosition = Vector3.zero;
        

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
        {
            targetPosition = hit.point;
            
        }
        
       
        Vector3 targetAim = targetPosition;
        targetAim.y = transform.position.y;
        Vector3 aimDir = (targetAim - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 30f);
    }
}
