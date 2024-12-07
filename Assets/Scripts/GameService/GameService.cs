
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
    [SerializeField] WeaponUIView weaponUIView;
    [SerializeField] float playerhealth;
    [SerializeField] List<WeaponList> weaponList=new List<WeaponList>();
    [SerializeField] Transform weaponHolder;

    //Services
    private PlayerService playerService;
    private WeaponService weaponService;
    private UIService uIService;
    public PlayerService PlayerService {  get { return playerService; } }
    public WeaponService WeaponService { get { return weaponService; } }
    public UIService UIService { get {  return uIService; } }

    private void Init()
    {
        playerService = new PlayerService(playerView,playerhealth);
        weaponService = new WeaponService(weaponList, weaponHolder);
        uIService=new UIService(weaponUIView);
    }

    public void OnSceneChange()
    {

    }


}
