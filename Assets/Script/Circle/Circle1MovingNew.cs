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
        // if (Input.GetKey(KeyCode.LeftControl)){
        //     PlayerMoving.AngleSpeed = Mathf.Lerp(PlayerMoving.AngleSpeed,10,Time.deltaTime*10);
        // }
        // else if(!Input.GetKeyUp(KeyCode.LeftControl) && Radius >3){
        //     Radius = Mathf.Lerp(Radius,3,Time.deltaTime*10);
        // }


        // 카이팅
        // if (Input.GetKey(KeyCode.W) && PlayerMoving.CurrentEnergy > 0 && !stop){
        //     Radius = Mathf.Lerp(Radius,WRadius,Time.deltaTime*10);
        //     rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * WSpeed,Time.deltaTime*10); // 서클 속도 증가
        //     // PlayerMoving.AngleSpeed = Mathf.Lerp(PlayerMoving.AngleSpeed,PlayerMoving.AngleSpeed-3,Time.deltaTime*10);
        //     PlayerMoving.CurrentEnergy -= Time.deltaTime * EnergyDrainSpeed; //에너지 소모
        //     PlayerMoving.Size = Mathf.Lerp(PlayerMoving.Size,WSize,Time.deltaTime*10); //서클 크기 증가
        //     if (PlayerMoving.CurrentEnergy <0.01f){
        //         stop = true;
        //     }
        // }
        GetComponent<CircleController>()?.WSkill(KeyCode.W,WRadius,WSpeed,WSize);
        if (Input.GetKeyUp(KeyCode.W)){
            stop = false;
        }
        else if(!Input.GetKey(KeyCode.W) && Radius >3 || PlayerMoving.Size >1.0001f || stop){
            Radius = Mathf.Lerp(Radius,3,Time.deltaTime*10);
            rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * 1f,Time.deltaTime*10);
            PlayerMoving.Size = Mathf.Lerp(PlayerMoving.Size,1f,Time.deltaTime*10);
            if (Radius < 3.1f){
                //stop = false;
            }
            // PlayerMoving.AngleSpeed = Mathf.Lerp(PlayerMoving.AngleSpeed,PlayerMoving.AngleSpeed+3,Time.deltaTime*10);
        } 
        // if (Input.GetKey(KeyCode.S)){
        //     Radius = Mathf.Lerp(Radius,1,Time.deltaTime*10);
        //     rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * 0.5f,Time.deltaTime*10);
        //     PlayerMoving.Damagefix = Mathf.Lerp(PlayerMoving.Damagefix,0,Time.deltaTime*10);
            
        // }
        else if(!Input.GetKey(KeyCode.S) && Radius <3){
            Radius = Mathf.Lerp(Radius,3,Time.deltaTime*10);
            rotdir = Mathf.Lerp(rotdir,Mathf.Sign(rotdir) * 1.0f,Time.deltaTime*10);
            PlayerMoving.Damagefix = Mathf.Lerp(PlayerMoving.Damagefix,1,Time.deltaTime*10);
        }
        //서클 속도 증가 패시브
        if (Input.GetKey(KeyCode.D)&& PlayerMoving.CurrentEnergy > 0 && !stop){
            rotdir = -ADSpeed;
            PlayerMoving.CurrentEnergy -= Time.deltaTime * EnergyDrainSpeed;
            if (PlayerMoving.CurrentEnergy <0.01f){
                stop = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D)){
            stop = false;
        }

        //서클 방향 변경
        if (Input.GetKeyDown(KeyCode.D)){
            rotdir = -1;
            if((Time.time-doubleclickedtime) < interval)
            {
                IsDoubleClicked = true;
                doubleclickedtime = -1.0f;
                Debug.Log(IsDoubleClicked);
            }
            else{
                IsDoubleClicked =false;
                doubleclickedtime = Time.time;
                Debug.Log(IsDoubleClicked);
            }
        }
        // 서클 속도 증가 액티브 스킬
        if (IsDoubleClicked && Player.CircleEnergy >= 50 || CircleEnergyCheck1){
            
            if (Player.CircleEnergy > 0.3f){
                Player.CircleEnergy -= Time.deltaTime*CircleEnergyDrainSpeed;
                rotdir = -CircleSkillSpeed;
                CircleEnergyCheck1 = true;
            }
            else if (Player.CircleEnergy <= 0.3f){
                CircleEnergyCheck1 = false;
                rotdir = -1;
            }
        }
        if(Input.GetKeyUp(KeyCode.D)){
            IsDoubleClicked = false;
            rotdir = -1;
        }
        //서클 속도 증가 패시브
        if (Input.GetKey(KeyCode.A)&& PlayerMoving.CurrentEnergy > 0 && !stop){
            rotdir = ADSpeed;
            PlayerMoving.CurrentEnergy -= Time.deltaTime * EnergyDrainSpeed;
            if (PlayerMoving.CurrentEnergy <0.01f){
                stop = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A)){
            stop = false;
        }

        //서클 방향 변경
        if (Input.GetKeyDown(KeyCode.A)){
            rotdir = 1;
            if((Time.time-doubleclickedtime2) < interval)
            {
                IsDoubleClicked2 = true;
                doubleclickedtime2 = -1.0f;
                Debug.Log(IsDoubleClicked2);
            }
            else{
                IsDoubleClicked2 =false;
                doubleclickedtime2 = Time.time;
                Debug.Log(IsDoubleClicked2);
            }
        }
        //서클 속도 증가 액티브 스킬
        if (IsDoubleClicked2 && Player.CircleEnergy >= 50 || CircleEnergyCheck2){
           
            if (Player.CircleEnergy > 0.3f){
                Player.CircleEnergy -= Time.deltaTime*CircleEnergyDrainSpeed;
                rotdir = CircleSkillSpeed;
                CircleEnergyCheck2 = true;
            }
            else if (Player.CircleEnergy <= 0.3f){
                CircleEnergyCheck2 = false;
                rotdir = 1;
            }
        }
        if(Input.GetKeyUp(KeyCode.A)){
            IsDoubleClicked2 = false;
            rotdir = 1;
        }
        // if (Player.CircleEnergy <= 0.3f){
        //     CircleEnergyCheck2 = false;
        //     CircleEnergyCheck1 = false;
        //     rotdir = Mathf.Abs(rotdir) * 1;
        // }


        // 캐릭터 추적
        //rigid.position = player.position;
    }
    void FixedUpdate()
    {
        // 360도 마다 저장된 각도 0으로 초기화
        if (Angle  > 360)
        {
            Angle = 0;
        }

        // 서클 회전
        //this.transform.rotation = Quaternion.Euler(0, 0, Angle);
        Angle += PlayerMoving.AngleSpeed * rotdir;
        transform.GetChild(0).position = new Vector3 (PPX + Radius * Mathf.Cos(Angle * Mathf.Deg2Rad),PPY + Radius * Mathf.Sin(Angle * Mathf.Deg2Rad),-1);
        transform.GetChild(1).position = new Vector3 (PPX + Radius * Mathf.Cos((Angle+180)* Mathf.Deg2Rad),PPY + Radius * Mathf.Sin((Angle+180)* Mathf.Deg2Rad),-1);

        PPX = player.position.x;
        PPY = player.position.y;

        
        // 서클 사이즈
        transform.GetChild(0).localScale = new Vector3(PlayerMoving.Size,PlayerMoving.Size,1);
        transform.GetChild(1).localScale = new Vector3(PlayerMoving.Size,PlayerMoving.Size,1);
        

        //Debug.Log(player.position);
        //Debug.Log(this.transform.position);

        // 서클 플레이어 추적 >>>>> 이거 지금은 position 따라가게 해놨는 데 물리적용해서 속도로 지정으로 딜레이도 고려 중
        // Vector3 dir = player.transform.position - rigid.transform.position;
        

        //Debug.Log(transform.GetChild(0).position);
        //Debug.Log(transform.GetChild(1).position);

    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if(collision.gameObject.tag == "Enemy"){
    //         Debug.Log("hit");
    //         OnAttack(collision.transform);
    //     }
    // }

    // public void OnAttack(Transform Enemy)

    // {
    //     EnemyMove enemymove = Enemy.GetComponent<EnemyMove>();
    //     enemymove.EnemyDamaged();
    //     gameManger.Stage_Score += 100;
    // }
}
