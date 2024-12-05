
using UnityEngine;

public class PlayerService :MonoBehaviour
{
    [SerializeField] PlayerView PlayerView;
    private PlayerController playerController;

    /*
    public PlayerService(PlayerView playerView)
    {
        playerController = new PlayerController(playerView);
    }
    */

    private void Start()
    {
        playerController=new PlayerController(PlayerView);
    }

    public PlayerController GetPlayerController()=> playerController;
}

