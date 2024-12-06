
using UnityEngine;

public class DamageAbleObjects : MonoBehaviour, IDamageAble
{
    [SerializeField] float health;
    [SerializeField] GameObject BrokenObject;

    public void TakeDamage(float damage)
    {
        health-= damage;
        if(health < 0)
        {
            GameObject temp=Instantiate(BrokenObject,transform.position, Quaternion.identity);
            temp.transform.localScale=this.transform.localScale;
            temp.transform.transform.localPosition=transform.position;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Invoke("LookAtPlayer",4f);
    }

    private void LookAtPlayer()
    {
        if (GameService.Instance.PlayerService.GetPlayerController().PlayerTransform != null)
        {
            Vector3 dir = GameService.Instance.PlayerService.GetPlayerController().PlayerTransform.position - transform.position;

            dir.y = 0;

            if (dir != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2);
            }
        }
    }
}

