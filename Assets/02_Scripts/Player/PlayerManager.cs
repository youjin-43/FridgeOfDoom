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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
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
            ThrowProjectile();
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
}
