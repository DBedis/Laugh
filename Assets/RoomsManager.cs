using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class RoomsManager : MonoBehaviour
    {
        public int location; // 0, 1, 2
        public List<GameObject> rooms; // Make sure to make 'Gameobject' lowercase -> 'GameObject'
        public List<triggerRoomshift> roomshifts;
        
        // Start is called before the first frame update
        void Start()
        {
            location = 1;
        }

        // Update is called once per frame
        void Update()
        {
            CheckLoop();
        }

        void CheckLoop()
        {
            if (location == 0)
{
    rooms[2].transform.position = rooms[0].transform.position - CalculateDistance(rooms[1].transform.position, rooms[0].transform.position);
    location = 1;

    List<GameObject> tmpList = new List<GameObject>(); // Fixed declaration syntax
    tmpList.Add(rooms[2]);
    tmpList.Add(rooms[0]);
    tmpList.Add(rooms[1]);

    List<triggerRoomshift> tmpListTriggers = new List<triggerRoomshift>(); // Fixed declaration syntax
    tmpListTriggers.Add(roomshifts[2]);
    tmpListTriggers.Add(roomshifts[0]);
    tmpListTriggers.Add(roomshifts[1]);

    rooms = tmpList;
    roomshifts = tmpListTriggers;

    roomshifts[0].roomPosition = 0;
    roomshifts[1].roomPosition = 1;
    roomshifts[2].roomPosition = 2;
}
else if (location == 2)
{
    rooms[0].transform.position = rooms[2].transform.position + CalculateDistance(rooms[1].transform.position, rooms[0].transform.position);
    location = 1;

    List<GameObject> tmpList = new List<GameObject>(); // Fixed declaration syntax
    tmpList.Add(rooms[1]);
    tmpList.Add(rooms[2]);
    tmpList.Add(rooms[0]);

    List<triggerRoomshift> tmpListTriggers = new List<triggerRoomshift>(); // Fixed declaration syntax
    tmpListTriggers.Add(roomshifts[1]);
    tmpListTriggers.Add(roomshifts[2]);
    tmpListTriggers.Add(roomshifts[0]);

    rooms = tmpList;
    roomshifts = tmpListTriggers;

    roomshifts[0].roomPosition = 0;
    roomshifts[1].roomPosition = 1;
    roomshifts[2].roomPosition = 2;
}
        }

        Vector3 CalculateDistance(Vector3 position1, Vector3 position2)
        {
            // Calculate the distance vector between two positions
            return position1 - position2;
        }

        public void SetLocation(int locationNumber)
        {
            location = locationNumber;
        }
    }
}
