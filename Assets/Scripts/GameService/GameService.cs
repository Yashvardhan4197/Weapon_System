
using UnityEngine;

public class GameService : MonoBehaviour
{
    private static GameService instance;
    public static GameService Instance { get { return instance; } }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Data
    [SerializeField] PlayerView playerView;


    //Services
    private PlayerService playerService;
    public PlayerService PlayerService {  get { return playerService; } }

    private void Init()
    {
        playerService = new PlayerService(playerView);
    }

    public void OnSceneChange()
    {

    }


}
