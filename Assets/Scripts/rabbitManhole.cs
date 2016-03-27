using UnityEngine;
using System.Collections;

public class rabbitManhole : MonoBehaviour {

    void OnTriggerExit(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            StartCoroutine(manholeTrap());
            Destroy(this.gameObject, 3.1f);
        }
    }

     IEnumerator manholeTrap()
     {
         manholeTrapped();
         yield return new WaitForSeconds(3f);
         manholeRelease();
     }

     void manholeTrapped()
     {
     GameObject.Find("TestAnimal").GetComponent<TestAnimal>().isStun = true;
     }

     void manholeRelease()
     {
         GameObject.Find("TestAnimal").GetComponent<TestAnimal>().isStun = false;
     }
}
