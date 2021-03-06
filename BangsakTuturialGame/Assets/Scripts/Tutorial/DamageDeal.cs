using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    //ForTagAndDeleteWhenShotAI
    public GameObject AICharacter;
    public GameObject PlayerCharacter;
    public GameObject Gun;
    public GameObject PlayerCamera;
    public GameObject Companion;
    public GameObject UITalkOff;
    public GameObject UIRetry;
    public GameObject UIProceed;
    public GameObject WarningUI;
    public GameObject LocationNew;
    public GameObject AISeeker;
    public GameObject BulletScript;
    public bool isDown = false;
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Bullet"){
            StartCoroutine(IntroOfSeeker());
            Destroy(other.GetComponent<BoxCollider>());
            WarningUI.SetActive(false);
            isDown = true;
        }
        else if(other.tag == "Player"){
            AICharacter.GetComponent<AiEnemyHiderSpawns>().enabled = false;
            UIRetry.SetActive(true);
            WarningUI.SetActive(false);
            Destroy(PlayerCharacter.GetComponent<Controller>());
            Destroy(PlayerCamera.GetComponent<MouseLook>());
            Destroy(AICharacter.GetComponent<Rigidbody>());
            Destroy(BulletScript.GetComponent<ShootingCharacter>());
            Destroy(WarningUI);
            Cursor.lockState = CursorLockMode.None;
        }
        else if(isDown == true){
            WarningUI.SetActive(true);
        }
        
    }
    public void EnableMovementCharForSeeker(){
        PlayerCharacter.GetComponent<Controller>().enabled = true;
        PlayerCamera.GetComponent<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCharacter.transform.LookAt(AISeeker.transform);
    }
    IEnumerator IntroOfSeeker(){
        yield return new WaitForSeconds(0.4f);
        AICharacter.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        UIProceed.SetActive(true);
        Gun.SetActive(false);
        UITalkOff.SetActive(false);
        WarningUI.SetActive(false);
        PlayerCharacter.GetComponent<Controller>().enabled = false;
        PlayerCamera.GetComponent<MouseLook>().enabled = false;
        PlayerCharacter.transform.LookAt(Companion.transform);
        PlayerCharacter.transform.position = LocationNew.transform.position;
        PlayerCharacter.transform.rotation = LocationNew.transform.rotation;
    }
}
