
using System.Collections.Generic;
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
    [SerializeField] List<WeaponList> weaponList=new List<WeaponList>();
    [SerializeField] Transform weaponHolder;

    //Services
    private PlayerService playerService;
    private WeaponService weaponService;
    public PlayerService PlayerService {  get { return playerService; } }
    public WeaponService WeaponService { get { return weaponService; } }

    private void Init()
    {
        playerService = new PlayerService(playerView);
        weaponService = new WeaponService(weaponList, weaponHolder);
    }

    public void OnSceneChange()
    {

    }


}
