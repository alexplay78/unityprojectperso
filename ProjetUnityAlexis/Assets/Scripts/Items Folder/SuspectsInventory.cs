using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectsInventory : MonoBehaviour
{

    public Item[] itemList = new Item[10];
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public static SuspectsInventory instance;
    public int itemCurrentIndex = 0;
    public Image itemImageUI1;
    public Image itemImageUI2;
    public Image itemImageUI3;
    public Sprite emptyItemImage;
    public Text itemNameUI;
    public Text itemDescriptionUI;
    public GameObject suspectsInventory;
    bool isHidden = false;
    public GameObject itemSlotObject;
    public Transform itemSlotObjectTransform;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.F))
        {
            if(isHidden)
            {
                isHidden = false;
                suspectsInventory.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                suspectsInventory.SetActive(isHidden);
            }
        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            if(isHidden)
            {
                isHidden = false;
                suspectsInventory.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                suspectsInventory.SetActive(isHidden);
            }
        }
    }

    
    public bool Add(Item item)
    {
        AddItemSlots();
        for(int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                return true;
            }
        }
        return false;
    }
    

    public void UpdateInventoryUI()
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot();
        }
        
        /*if(itemImageUI1.sprite != content[contentCurrentIndex].image)
        {
            itemImageUI2.sprite = content[contentCurrentIndex + 1].image;
        }
        */
        
        if(itemList[itemCurrentIndex] != null)
        {
            itemImageUI1.sprite = itemList[itemCurrentIndex].image;
        }
        else
        {
            itemImageUI1.sprite = emptyItemImage;
            itemNameUI.text = "";
            itemDescriptionUI.text = "";
        }
    }

    private void AddItemSlots()
    {
        GameObject GO = Instantiate(itemSlotObject, itemSlotObjectTransform);
        InventorySlot newSlot = GO.GetComponent<InventorySlot>();
        inventorySlots.Add(newSlot);
    }


    public void OpenCloseSuspectsInventory()
    {

        if(isHidden)
            {
                isHidden = false;
                suspectsInventory.SetActive(isHidden);
                Time.timeScale = 1f;
            }
            else
            {
                isHidden = true;
                suspectsInventory.SetActive(isHidden);
            }
    }

}