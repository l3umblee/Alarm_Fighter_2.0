using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;
    private IEnumerator coroutine;
    Animator anim;
    GameObject shield;
    GameObject item_angle;
    void Start()
    {
        anim = Util.FindChild(gameObject,"PlayerEach").GetComponent<Animator>();

    }
    private void Update()
    {
        if(CurrentHP<=0&&Managers.Monster.IsAlive())
        {
            coroutine = DieAnimation();
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator DieAnimation()
    {
        yield return new WaitForSeconds(1.0f);//animation time
        //Managers.Sound.Play("Effect/die");
        anim.GetComponent<Animator>().SetTrigger("die");
        yield return new WaitForSeconds(0.5f);//animation time
        StopAllCoroutines();
        Managers.Player.SetAlive(false);
        CurrentHP = -1000f;
    }
    public void FillHp(float mount)    
    {
        CurrentHP += mount;
        if (MaxHP <= CurrentHP)
            CurrentHP = MaxHP;
    }
    public void FillShield(string Shield)
    {
        //creates shield(GameObejct) below Player on scene
        this.shield = Managers.Resource.Instantiate(Shield, transform);
    }
    public void FillInvincible(string item_angle)
    {
        //creates item_angle(GameObejct) below Player on scene
        this.item_angle = Managers.Resource.Instantiate(item_angle, transform);
    }

    public GameObject GetShield() { return  shield; }
    public GameObject GetItem_Angle() { return  item_angle; }
}
