using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGems : MonoBehaviour {

    public static UIGems current;

    public List<GameObject> Gems;

    private void Awake()
    {
        current = this;
    }

    public void activateGem(int index)
    {
        Gems[index].SetActive(true);
    }

}
