using UnityEngine;
using System.Collections;

public class testAnimalSkill : MonoBehaviour {
    //skill1 "AirLaunch" variable
    private bool AirLaunch = false;
    public float AirLaunchTimer = 0;
    public float AirLaunchRate = 0.3f;
    public float AirLaunchCd = 0;
    public float AirLaunchCdRate = 3;
    public BoxCollider AirLaunchTrigger;

    //skill2 "BoarSprint" variable
    private bool boarSprint = false;
    public float boarSprintTimer = 0;
    public float boarSprintRate = 4;
    public float boarSprintCd = 0;
    public float boarSprintCdRate = 9;
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
    public float chargeRate = 0.3f;
    public float chargeCd = 0;
    public float chargeCdRate = 5;
    public float chargeSpeed = 30;
    public BoxCollider chargeTrigger;

    public GameObject testAnimal;
    private Animator anim;
    
    //set parameter by code
    /*
    void Start()
    {
        //skill 1 parameter
        AirLaunch = false;
        AirLaunchTimer = 0;
        AirLaunchRate = 0.3f;
        AirLaunchCd = 0;
        AirLaunchCdRate = 1;
        //skill 2 parameter
        boarSprint = false;
        boarSprintTimer = 0;
        boarSprintRate = 4;
        boarSprintCd = 0;
        boarSprintCdRate = 9;
        moveSpeedNormal = 7;
        //skill 3 parameter
        manhole = false;
        manholeTimer = 0;
        manholeRate = 4;
        manholeCd = 0;
        manholdCdRate = 5;
        //skill 4 parameter
        charge = false;
        chargeTimer = 0;
        chargeRate = 4;
        chargeCd = 0;
        chargeCdRate = 5;
}*/

    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        AirLaunchTrigger.enabled = false;
        manholeTrapSpawn = transform.FindChild("manholeSpawnPoint");
        chargeTrigger.enabled = false;
     

    }

    // Update is called once per frame
    void Update()
    {
        AirLaunchSkill();
        boarSprintSkill();
        manholeSkill();
        chargeSkill();
    }

    void AirLaunchSkill()
    {
        //Skill1 AirLaunch
        if (Input.GetMouseButtonDown(0) && !boarSprint && !AirLaunch && AirLaunchCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
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

        if (AirLaunchCd > 0)
        {

            AirLaunchCd -= Time.deltaTime;
        }

    }

    void boarSprintSkill()
    {
        //skill2 BoarSprint
        if (Input.GetMouseButtonDown(1)&& !AirLaunch && !boarSprint && boarSprintCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
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

        if (!boarSprint)
        {
            testAnimal.GetComponent<TestAnimal>().moveSpeed = moveSpeedNormal;
          
        }
        if (boarSprintCd > 0)
        {
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
        }

        if (manholeCd >0 )
        {
            manholeCd -= Time.deltaTime;
        }
    }
    void chargeSkill()
    {
        //skill4 Charge
        if (Input.GetKeyDown(KeyCode.E) && !charge && !AirLaunch  && chargeCd <= 0 && testAnimal.GetComponent<TestAnimal>().isGrounded && !testAnimal.GetComponent<TestAnimal>().isStun)
        {
            charge = true;
            chargeTrigger.enabled = true;
            chargeTimer = chargeRate;
            chargeCd = chargeCdRate;
            
        }
        //reset Attack&SkillCooldown
        if (charge)
        {
            if (chargeTimer > 0)
            {
                chargeTimer -= Time.deltaTime;
            }
            else
            {
                charge = false;
                chargeTrigger.enabled = false;
            }
            anim.SetBool("Charging", charge);
        }

        if (chargeCd > 0)
        {

            chargeCd -= Time.deltaTime;
        }

    }

}
