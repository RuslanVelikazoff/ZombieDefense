using System.Collections;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Animator[] playerAnimator;
    [SerializeField] private GameObject[] playerGameObject;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        if (ShopData.Instance.GetBuyGun(0))
        {
            player.SetPlayerAnimator(playerAnimator[0]);
            playerGameObject[0].SetActive(true);
            playerGameObject[1].SetActive(false);
            playerGameObject[2].SetActive(false);
            playerGameObject[3].SetActive(false);
        }
        
        if (ShopData.Instance.GetBuyGun(1))
        {
            player.SetPlayerAnimator(playerAnimator[1]);
            playerGameObject[0].SetActive(false);
            playerGameObject[1].SetActive(true);
            playerGameObject[2].SetActive(false);
            playerGameObject[3].SetActive(false);
        }
        
        if (ShopData.Instance.GetBuyGun(2))
        {
            player.SetPlayerAnimator(playerAnimator[2]);
            playerGameObject[0].SetActive(false);
            playerGameObject[1].SetActive(false);
            playerGameObject[2].SetActive(true);
            playerGameObject[3].SetActive(false);
        }
        
        if (ShopData.Instance.GetBuyGun(3))
        {
            player.SetPlayerAnimator(playerAnimator[3]);
            playerGameObject[0].SetActive(false);
            playerGameObject[1].SetActive(false);
            playerGameObject[2].SetActive(false);
            playerGameObject[3].SetActive(true);
        }
    }
}
