using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("飛機移動速度")]
    public float Speed;
    [Header("玩家")]
    public GameObject player;
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成位置")]
    public GameObject CreateObject;
    [Header("子彈生成時間")]
    public float SetTimer;
    bool CanJoystick;
    void Start()
    {
        InvokeRepeating("CreateBullet", SetTimer, SetTimer);
    }
    void CreateBullet()
    {
        Instantiate(Bullet, CreateObject.transform.position, CreateObject.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
       player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    public void IsUsingJoystick()
    {
        CanJoystick = true;
    }
    public void IsntUsingJoystick()
    {
        CanJoystick = false;
    }
    public void UsingJoystick(Vector3 pos)
    {
        if (CanJoystick)
        {
            player.transform.Translate(pos.x * Speed * Time.deltaTime, pos.y * Speed * Time.deltaTime, 0, Space.World);
        }
    }
}
