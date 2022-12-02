using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle1MovingNew : CircleController
{

    // Rigidbody2D rigid;
    // float Angle; // 회전 각
    // public float AngleSpeed;
    // public float Radius; // 회전 반경
    // public float EnergyFillSpeed;
    // public float EnergyDrainSpeed;
    // public PlayerMoving Player;
    
    

    // public Transform player;
    // public GameManger gameManger;
    // public Transform[] Circle; //회전 서클

    // public float rotdir; //회전 방향
    // public float WRadius;
    // public float WSpeed;
    // public float WSize;
    // public float CSSpeed;
    // public float ADSpeed;
    // public float CEDS; //Circle Energy Drain Speed;
    
    
    // float PPX; //player position x
    // float PPY; //player position y
    // float doubleclickedtime = -1.0f;
    // float doubleclickedtime2 = -1.0f;
    // float interval = 0.25f;
    // bool IsDoubleClicked = false;
    // bool IsDoubleClicked2 = false;
    // bool stop;
    // bool CircleEnergyCheck1;
    // bool CircleEnergyCheck2;
    


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        stop = false;
        CircleEnergyCheck1 = false;
        CircleEnergyCheck2 = false;
    }

    // Update is called once per frame

    void Update() {
        //에너지 충전
        if (PlayerMoving.CurrentEnergy <100.1f){
            PlayerMoving.CurrentEnergy += Time.deltaTime * EnergyFillSpeed;;
        }
        // 카이팅
        GetComponent<CircleController>()?.WSkill(KeyCode.W,WRadius,WSpeed,WSize);
        GetComponent<CircleController>()?.ADSkill(KeyCode.D,clockwise,ADSpeed,EnergyDrainSpeed);
        GetComponent<CircleController>()?.ADSkill(KeyCode.A,counterclockwise,ADSpeed,EnergyDrainSpeed);
        GetComponent<CircleController>()?.FeverSkill(KeyCode.D,clockwise,CircleSkillSpeed,CircleEnergyDrainSpeed);
        GetComponent<CircleController>()?.FeverSkill(KeyCode.A,counterclockwise,CircleSkillSpeed,CircleEnergyDrainSpeed);
        
        // if (Input.GetKey(KeyCode.S)){
        //     Radius = Mathf.Lerp(Radius,1,Time.deltaTime*10);
        //     rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * 0.5f,Time.deltaTime*10);
        //     PlayerMoving.Damagefix = Mathf.Lerp(PlayerMoving.Damagefix,0,Time.deltaTime*10);
            
        // }
        if(!Input.GetKey(KeyCode.S) && Radius <3){
            Radius = Mathf.Lerp(Radius,3,Time.deltaTime*10);
            rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * 1.0f,Time.deltaTime*10);
            PlayerMoving.Damagefix = Mathf.Lerp(PlayerMoving.Damagefix,1,Time.deltaTime*10);
        }

        // 서클 사이즈
        transform.GetChild(0).localScale = new Vector3(PlayerMoving.Size,PlayerMoving.Size,1);
        transform.GetChild(1).localScale = new Vector3(PlayerMoving.Size,PlayerMoving.Size,1);

        // 서클 회전
        //this.transform.rotation = Quaternion.Euler(0, 0, Angle);
        PPX = player.position.x;
        PPY = player.position.y;
        Angle += PlayerMoving.AngleSpeed * rotdir * Time.deltaTime * 30;
        transform.GetChild(0).position = new Vector3 (PPX + Radius * Mathf.Cos(Angle * Mathf.Deg2Rad),PPY + Radius * Mathf.Sin(Angle * Mathf.Deg2Rad),-1);
        transform.GetChild(1).position = new Vector3 (PPX + Radius * Mathf.Cos((Angle+180)* Mathf.Deg2Rad),PPY + Radius * Mathf.Sin((Angle+180)* Mathf.Deg2Rad),-1);
        // 360도 마다 저장된 각도 0으로 초기화
        if (Angle  > 360)
        {
            Angle = 0;
        }
        
    }
    void FixedUpdate()
    {
        
        

        
        

        
        
    }
       
}
