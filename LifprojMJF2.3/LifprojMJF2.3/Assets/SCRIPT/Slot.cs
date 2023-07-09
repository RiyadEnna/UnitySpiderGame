using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slot : MonoBehaviour
{
    public Inventory Invent;
    private int nbSlot;
    public StatPlayer sp;
    public TakeWeaponFromQuickSlot Weapon;

    public void Start()
    {
        Weapon = GameObject.Find("Player").GetComponent<TakeWeaponFromQuickSlot> ();
        Invent = GameObject.Find("Inventory").GetComponent<Inventory> ();
        nbSlot = transform.GetSiblingIndex(); 
    }

    public void ConsumHealth()
    {
        if(Invent.slotI[nbSlot] > 0)
        {
            Invent.slotI[nbSlot]--;
            sp.currentHealth += 10;
            Invent.UpdateNumber(nbSlot, Invent.slotI[nbSlot].ToString());
        }
    }

    public void ConsumMana()
    {
        if(Invent.slotI[nbSlot] > 0)
        {
            Invent.slotI[nbSlot]--;
            Invent.UpdateNumber(nbSlot, Invent.slotI[nbSlot].ToString());
        }
    }

    public void addSwordToQuickSlot()
    {
        if(Invent.slotI[nbSlot] > 0)
        {
            Invent.slotI[nbSlot]--;
            Invent.UpdateNumber(nbSlot, Invent.slotI[nbSlot].ToString());
            Weapon.swordQuickSlot.SetActive(true);
        }
    }

    public void addAxeToQuickSlot()
    {
        if(Invent.slotI[nbSlot] > 0)
        {
            Invent.slotI[nbSlot]--;
            Invent.UpdateNumber(nbSlot, Invent.slotI[nbSlot].ToString());
            Weapon.axeQuickSlot.SetActive(true);
            
        }
    }

    public void addShieldToQuickSlot()
    {
        if(Invent.slotI[nbSlot] > 0)
        {
            Invent.slotI[nbSlot]--;
            Invent.UpdateNumber(nbSlot, Invent.slotI[nbSlot].ToString());
            Weapon.shieldQuickSlot.SetActive(true);
        }
    }
}