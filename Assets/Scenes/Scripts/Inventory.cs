using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Weapon> myWeaponList = null;
    public Weapon currentWeapon = null;
    public Rect guiAreaRect = new Rect(0, 0, 0, 0);
    public Transform weaponPos = null;
    public GameObject currentWeaponGO = null;

    List<KeyCode> numberss = new List<KeyCode>{ KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5};

    void Update()
    {
        ChangeWeaponWithNumbers();
    }

    public void ChangeWeaponWithNumbers()
    {
        for (int i = 0; i < numberss.Count; i++)
        {
            if (myWeaponList[i] != null)
            {
                if (Input.GetKeyDown(numberss[i]))
                {
                    currentWeapon = myWeaponList[i];
                    ChangeWeapon(myWeaponList[i]);
                }
            }
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(guiAreaRect);
        GUILayout.BeginVertical();
        foreach (Weapon weapon in myWeaponList)
        {
            if (weapon != null)
            {
                if (GUILayout.Button(weapon.weaponLogo, GUILayout.Width(50), GUILayout.Height(50)))
                {
                    currentWeapon = weapon;
                    ChangeWeapon(weapon);
                    Debug.Log(currentWeapon);
                }
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (currentWeaponGO != null)
            Destroy(currentWeaponGO);

        currentWeaponGO = GameObject.Instantiate(newWeapon.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        currentWeaponGO.transform.parent = weaponPos;
        currentWeaponGO.transform.position = weaponPos.position;
    }
}
