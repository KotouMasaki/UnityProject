using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    [SerializeField] private GameObject lv3_Door1;
    [SerializeField] private GameObject lv3_Door2;
    [SerializeField] private GameObject lv4_Door;

    /// <summary>
    /// ƒhƒA‚ðŠJ•Â‚·‚é
    /// </summary>
    void control_panel()
    {
        lv3_Door1.SetActive(true);
        lv3_Door2.SetActive(true);
        lv4_Door.SetActive(false);
    }
}
