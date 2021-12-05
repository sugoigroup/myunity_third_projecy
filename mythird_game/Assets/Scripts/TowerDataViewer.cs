using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField] private Image imageTower;
    [SerializeField] private TextMeshProUGUI textDamage;
    [SerializeField] private TextMeshProUGUI textRate;
    [SerializeField] private TextMeshProUGUI textRange;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TowerAttackRange towerAttackRange;
    [SerializeField] private Button buttonUpgrade;
    [SerializeField] private SystemTextViewr systemTextViewr;

    private TowerWeapon currentTower;
    private void Awake()
    {
        OffPanel();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
        towerAttackRange.OffAttackRange();
    }
    public void OnPanel(Transform towerWeapon)
    {
        currentTower = towerWeapon.GetComponent<TowerWeapon>();
        gameObject.SetActive(true);
        UpdateTowerDate();
        towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        
    }

    private void UpdateTowerDate()
    {
        imageTower.sprite = currentTower.TowerSprite;
        textDamage.text = "Damage:" + currentTower.Damage;
        textRate.text = "Rate:" + currentTower.Rate;
        textRange.text = "Range:" + currentTower.Range;
        textLevel.text = "Level:" + currentTower.Level;

        buttonUpgrade.interactable = currentTower.Level < currentTower.MaxLevel ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
        
    }

    public void OnClickEventTowerUpgrade()
    {
        bool isSuccess = currentTower.Upgrade();

        if (isSuccess)
        {
            UpdateTowerDate();
            towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        }
        else
        {
            systemTextViewr.PrintText(SystemType.Money);
        }
    }

    public void OnClickEventTowerSell()
    {
        currentTower.Sell();
        OffPanel();
    }
}
