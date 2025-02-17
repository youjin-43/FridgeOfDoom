using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StarterAssetsInputs input;

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
    }
}
