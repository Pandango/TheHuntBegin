using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class testAnimalUIctrl : MonoBehaviour {
    public Text skillText1, skillText2, skillText3, skillText4;
    public Image skillImage1, skillImage2, skillImage3, skillImage4;
    public GameObject testAnimal;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //skill1
        if (testAnimal.GetComponent<testAnimalSkill>().AirLaunchCd <= 0)
        {
            skillImage1.color = Color.white;
            skillText1.color = Color.black;
            skillText1.text = "L Click";
        }
        else if(testAnimal.GetComponent<testAnimalSkill>().AirLaunchCd != 0){
            skillImage1.color = Color.red;
            skillText1.color = Color.red;
            skillText1.text = "CD " + Mathf.Ceil(testAnimal.GetComponent<testAnimalSkill>().AirLaunchCd).ToString();
        }
        //skill2
        if (testAnimal.GetComponent<testAnimalSkill>().boarSprintCd <= 0)
        {
            skillImage2.color = Color.white;
            skillText2.color = Color.black;
            skillText2.text = "R Click";
        }
        else if (testAnimal.GetComponent<testAnimalSkill>().boarSprintCd != 0)
        {
            skillImage2.color = Color.red;
            skillText2.color = Color.red;
            skillText2.text = "CD " + Mathf.Ceil(testAnimal.GetComponent<testAnimalSkill>().boarSprintCd).ToString();
        }
        //skill3
        if (testAnimal.GetComponent<testAnimalSkill>().manholeCd <= 0)
        {
            skillImage3.color = Color.white;
            skillText3.color = Color.black;
            skillText3.text = "Q";
        }
        else if (testAnimal.GetComponent<testAnimalSkill>().manholeCd != 0)
        {
            skillImage3.color = Color.red;
            skillText3.color = Color.red;
            skillText3.text = "CD " + Mathf.Ceil(testAnimal.GetComponent<testAnimalSkill>().manholeCd).ToString();
        }

        //skill4
        if (testAnimal.GetComponent<testAnimalSkill>().chargeCd <= 0)
        {
            skillImage4.color = Color.white;
            skillText4.color = Color.black;
            skillText4.text = "E";

        }
        else if (testAnimal.GetComponent<testAnimalSkill>().chargeCd != 0)
        {
            skillImage4.color = Color.red;
            skillText4.color = Color.red;
            skillText4.text = "CD " + Mathf.Ceil(testAnimal.GetComponent<testAnimalSkill>().chargeCd).ToString();
        }
    }
}
