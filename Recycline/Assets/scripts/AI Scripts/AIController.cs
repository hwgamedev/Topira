using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    private Queue minionQueue = new Queue();
	
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //All basic enums and stuff here!
    public enum CommandType { Nothing, GoTo, GoToAndPickUp, GoToAndDropOff};

    /**
     * Basic Singletone pattern - Only want a SINGLE AIController active as it'll be what gives commands to the minions.
     */
    private static AIController _instance;

    private AIController() { }

    public static AIController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AIController();
            }

            return _instance;
        }
    }
}
