using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	
	public static float skillCD0= 0, skillCD1 = 0;
    public static float skillCD0_show = 0, skillCD1_show = 0;
    public Text SkillText0, SkillText1;
    public Image SkillPic0, SkillPic1;
    bool isCD = false;
	
    void Start()
    {
        
    }

	void Update () {
        if(skillCD0 == 0)
        {
            SkillPic0.color = Color.white;
            SkillText0.color = Color.black;
            SkillText0.text = "LClick";
        }
        else
        {
            SkillPic0.color = Color.red;
            SkillText0.color = Color.red;
            SkillText0.text = "CD :" + skillCD0_show.ToString();
        }

        if (skillCD1 == 0)
        {
            SkillPic1.color = Color.white;
            SkillText1.color = Color.black;
            SkillText1.text = "RClick";
        }
        else
        {
            SkillPic1.color = Color.red;
            SkillText1.color = Color.red;
            SkillText1.text = "CD :" + skillCD1_show.ToString();
        }
        if (!isCD) { StartCoroutine(CoolDown()); }
        
    }

    IEnumerator CoolDown()
    {
        isCD = true;

        yield return new WaitForSeconds(0.5f);
        if (skillCD0 > 0)
        {
            skillCD0_show = Mathf.Ceil(skillCD0);
            skillCD0 -= 0.5f;
            
        }
        if (skillCD1 > 0)
        {
            skillCD1_show = Mathf.Ceil(skillCD1);
            skillCD1 -= 0.5f;
            
        }

        isCD = false;
    }
    

    }
