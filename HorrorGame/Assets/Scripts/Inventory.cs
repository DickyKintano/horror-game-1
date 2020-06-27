using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if  (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }

        instance = this;
    }

    #endregion


    [SerializeField] private int capacity = 15;

    public delegate void OnItemChange();
    public OnItemChange OnItemChangeCallBack;
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Not enough room");
            return false; ;
        }

        items.Add(item);

        if (OnItemChangeCallBack != null)
        {
            OnItemChangeCallBack.Invoke();
        }

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (OnItemChangeCallBack != null)
        {
            OnItemChangeCallBack.Invoke();
        }
    }
}
