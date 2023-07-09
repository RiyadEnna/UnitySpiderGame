using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeaponFromQuickSlot : MonoBehaviour
{ 
    public GameObject swordHand;
    public GameObject axeHand;
    public GameObject shieldHand;

    public GameObject swordBack;
    public GameObject axeBack;
    public GameObject shieldBack;

    // GameObject du quickslot
    public GameObject swordQuickSlot;
    public GameObject axeQuickSlot;
    public GameObject shieldQuickSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        swordHand.SetActive(false);
        axeHand.SetActive(false);
        shieldHand.SetActive(false);

        swordBack.SetActive(false);
        axeBack.SetActive(false);
        shieldBack.SetActive(false);

        swordQuickSlot.SetActive(false);
        axeQuickSlot.SetActive(false);
        shieldQuickSlot.SetActive(false);
    }

    public void addBackWeapon() {
        if (swordQuickSlot.activeSelf) {
            swordBack.SetActive(true) ;
        }

        if (axeQuickSlot.activeSelf) {
            axeBack.SetActive(true);
        }

        if (shieldQuickSlot.activeSelf) {
            shieldBack.SetActive(true);
        }
    }

    public void inputAlpha() {
        if (Input.GetKeyDown(KeyCode.Alpha1) && swordQuickSlot.activeSelf) {
            swordHand.SetActive(true);
            if (axeQuickSlot.activeSelf) {
                swordHand.SetActive(true);
                axeHand.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && axeQuickSlot.activeSelf) {
            axeHand.SetActive(true);
            if (swordQuickSlot.activeSelf) {
                swordHand.SetActive(false);
                axeHand.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && shieldQuickSlot.activeSelf) {
            shieldHand.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            swordHand.SetActive(false);
            axeHand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            swordHand.SetActive(false);
            axeHand.SetActive(false);
            shieldHand.SetActive(false);
        }
    }

    public void hideBackWeapon() {
        if (axeHand.activeSelf) {
            axeBack.SetActive(false);
        }

        if (swordHand.activeSelf) {
            swordBack.SetActive(false);
        }

        if (shieldHand.activeSelf) {
            shieldBack.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        addBackWeapon();

        inputAlpha();

        /*else if (Input.GetKeyDown(KeyCode.Alpha7) && !axeBackActive && axeActive) {
            Debug.Log("7 et !axebackActive");
                axeBackActive = true;
                axeBack.SetActive(true);
                axeHand.SetActive(false);
        }*/
        hideBackWeapon();
    }
}