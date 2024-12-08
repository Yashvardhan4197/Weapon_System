
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] AudioSource sFXAudioSource;
    [SerializeField] AudioSource bgAudioSource;
    [SerializeField] Sound[] soundCollection;
    [SerializeField] InGameUIView inGameUIView;

    //Services
    private PlayerService playerService;
    private WeaponService weaponService;
    private UIService uIService;
    private SoundService soundService;
    public PlayerService PlayerService {  get { return playerService; } }
    public WeaponService WeaponService { get { return weaponService; } }
    public UIService UIService { get {  return uIService; } }
    public SoundService SoundService { get { return soundService; } }

    //EVENTS
    public UnityAction PAUSEGAME;
    public UnityAction UNPAUSEGAME;
    public UnityAction RESETWEAPONDATA;
    private void Init()
    {
        playerService = new PlayerService(playerView,playerhealth);
        weaponService = new WeaponService(weaponList, weaponHolder);
        soundService = new SoundService(sFXAudioSource, bgAudioSource, soundCollection);
        uIService=new UIService(weaponUIView,inGameUIView);
    }


}
