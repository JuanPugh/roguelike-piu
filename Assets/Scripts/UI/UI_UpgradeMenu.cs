using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UI_UpgradeMenu : MonoBehaviour
{
    // Lista de mejoras (Scriptable Objects con descripcion), para mostrarlo como cartas
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private int cardAmount = 4;
    [SerializeField] private Upgrade[] upgrades;


    private void OnEnable()
    {
        EventManager.UpgradeSelected += RemoveCards;
        Time.timeScale = 0;
        CreateCards();
    }

    private void OnDisable()
    {
        EventManager.UpgradeSelected -= RemoveCards;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void CreateCards()
    {
        var availableUpgrades= upgrades.ToList();

        int x = 300;

        for(int i = 0; i < cardAmount; i++)
        {

            var length = availableUpgrades.Count;
            var random = Random.Range(0, length);
            
            Vector3 pos = new Vector3(x, 400, 0);
            var card = Instantiate(cardPrefab, pos, Quaternion.identity, transform);
            x += 300;
            card.GetComponent<UI_UpgradeCard>().SetUpgrade(availableUpgrades[random]);
            availableUpgrades.Remove(availableUpgrades[random]);

        }
    }

    private void RemoveCards()
    {
        for(int i = transform.childCount - 1 ; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
         
    }
}
