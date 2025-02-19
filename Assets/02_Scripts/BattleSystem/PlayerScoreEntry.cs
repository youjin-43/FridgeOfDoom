using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerScoreEntry : MonoBehaviour
{
    [SerializeField] TMP_Text nickNameText;
    [SerializeField] TMP_Text killCountText;
    [SerializeField] TMP_Text deathCountText;
    [SerializeField] TMP_Text assistCountText;
    public void SetData(Player player)
    {
        nickNameText.text = player.NickName;
        killCountText.text = "0";
        deathCountText.text = "0";
        assistCountText.text = "0";
    }

}
