using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float Angle; // 회전 각
    public float AngleSpeed;
    public float Radius; // 회전 반경
    public float EnergyFillSpeed;
    public float EnergyDrainSpeed;
    public PlayerMoving Player;
    
    

    public Transform player;
    public GameManger gameManger;
    public Transform[] Circle; //회전 서클

    public float rotdir; //회전 방향
    public float WRadius;
    public float WSpeed;
    public float WSize;
    public float CircleSkillSpeed;
    public float ADSpeed;
    public float CircleEnergyDrainSpeed; //Circle Energy Drain Speed;
    
    
    public float PPX; //player position x
    public float PPY; //player position y
    public float doubleclickedtime = -1.0f;
    public float doubleclickedtime2 = -1.0f;
    public float interval = 0.25f;
    public bool IsDoubleClicked = false;
    public bool IsDoubleClicked2 = false;
    public bool stop;
    public bool CircleEnergyCheck1;
    public bool CircleEnergyCheck2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void WSkill(KeyCode Key, float WRadius,float WSpeed,float WSize)
    {
        if (Input.GetKey(Key) && PlayerMoving.CurrentEnergy > 0 && !stop){
            Radius = Mathf.Lerp(Radius,WRadius,Time.deltaTime*10);
            PlayerMoving.CurrentEnergy -= Time.deltaTime * EnergyDrainSpeed;
            rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * WSpeed,Time.deltaTime*10); // 서클 속도 증가
            PlayerMoving.Size = Mathf.Lerp(PlayerMoving.Size,WSize,Time.deltaTime*10); //서클 크기 증가
        }
    }
    


}
