using UnityEngine;
using System.Collections;

public class testAnimalSkill : MonoBehaviour {
    //skill1 "AirLaunch" variable
    private bool AirLaunch = false;
    public float AirLaunchTimer = 0;
    public float AirLaunchRate = 0.3f;
    public float AirLaunchCd = 0;
    public float AirLaunchCdRate = 5;
    public BoxCollider AirLaunchTrigger;

    //skill2 "BoarSprint" variable
    private bool boarSprint = false;
    public float boarSprintTimer = 0;
    public float boarSprintRate = 4;
    public float boarSprintCd = 0;
    public float boarSprintCdRate = 5;
    private float moveSpeedNormal = 7;

    //skill3 "Manhole" variable
    private bool manhole = false;
    public float manholeTimer = 0;
    public float manholeRate = 4;
    public float manholeCd = 0;
    public float manholdCdRate = 5;    
    public Transform manholeTrapSpawn;
    public GameObject manholeTrap;

    //skill4 "Charge" variable
    private bool charge = false;
    public float chargeTimer = 0;
    public float chargeRate = 4;
    public float chargeCd = 0;
    public float chargeCdRate = 5;

    public GameObject testAnimal;
    private Animator anim;


    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        AirLaunchTrigger.enabled = false;
        manholeTrapSpawn = transform.FindChild("manholeSpawnPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        AirLaunchSkill();
        boarSprintSkill();
        manholeSkill();

    }

    void AirLaunchSkill()
    {
        //Skill1 AirLaunch
        if (Input.GetMouseButtonDown(0) && !AirLaunch && AirLaunchCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
        {
            AirLaunch = true;
            AirLaunchTimer = AirLaunchRate;
            AirLaunchTrigger.enabled = true;
            AirLaunchCd = AirLaunchCdRate;
        }
        //reset Attack&SkillCooldown
        if (AirLaunch)
        {
            if (AirLaunchTimer > 0)
            {
                AirLaunchTimer -= Time.deltaTime;
            }
            else
            {
                AirLaunch = false;
                AirLaunchTrigger.enabled = false;
            }
            anim.SetBool("Attacking", AirLaunch);
        }
        else if (!AirLaunch && AirLaunchCd > 0)
        {

            AirLaunchCd -= Time.deltaTime;
        }

    }

    void boarSprintSkill()
    {
        //skill2 BoarSprint
        if (Input.GetMouseButtonDown(1) && !boarSprint && boarSprintCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
        {
            boarSprint = true;
            boarSprintTimer = boarSprintRate;
            boarSprintCd = boarSprintCdRate;            
            testAnimal.GetComponent<TestAnimal>().moveSpeed += testAnimal.GetComponent<TestAnimal>().moveSpeed * 0.5f;
        }
        //reset Attack&SkillCooldown
        if (boarSprint)
        {
            if (boarSprintTimer > 0)
            {
                
                boarSprintTimer -= Time.deltaTime;
            }
            else
            {
                boarSprint = false;               
            }
            anim.SetBool("Sprinting", boarSprint);
        }
        else if (!boarSprint && boarSprintCd > 0)
        {
            testAnimal.GetComponent<TestAnimal>().moveSpeed = moveSpeedNormal;
            boarSprintCd -= Time.deltaTime;
        }
    }

    void manholeSkill()
    {
        //skill3 Manhole
        if (Input.GetKeyDown(KeyCode.Q) && !manhole && manholeCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
        {
            Debug.Log("Hit");
            manhole = true;
            manholeTimer = manholeRate;
            manholeCd = manholdCdRate;
            //...we instantiate a cannonball from Resources
            GameObject instance = Instantiate(manholeTrap) as GameObject;
            //Let's name it
            instance.name = "Manhole";
            //Let's position it at the cannon
            instance.transform.position = manholeTrapSpawn.position;
        }

        if (manhole)
        {
            if(manholeTimer > 0)
            {
                manholeTimer -= Time.deltaTime;
            }
            else
            {
                manhole = false;
            }
        }else if (!manhole && manholeCd >0 )
        {
            manholeCd -= Time.deltaTime;
        }
    }
  
}
