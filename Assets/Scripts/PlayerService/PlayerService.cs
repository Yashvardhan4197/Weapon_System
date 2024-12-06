
using UnityEngine;

public class PlayerService
{
    private PlayerController playerController;

    public PlayerService(PlayerView playerView,float playerHealth)
    {
        playerController = new PlayerController(playerView,playerHealth);
    }


    public PlayerController GetPlayerController()=> playerController;
}

