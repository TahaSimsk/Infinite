using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public TextMeshProUGUI text;

    public PlayerShooting playerShooting;

    public GameEvent Event;

    public ShootBehaviourBaseClass shootBehaviour;

    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(() => Event.Raise());
        //button.onClick.AddListener(() => playerShooting.AddBehaviour(shootBehaviour, shootBehaviour.IsNewUpgrade));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeText()
    {
        this.text.text = shootBehaviour.name;
    }

}
