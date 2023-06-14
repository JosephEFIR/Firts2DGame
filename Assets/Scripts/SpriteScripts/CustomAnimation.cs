using System.Collections.Generic;
using UnityEngine;

namespace First2DGame
{
    public class CustomAnimation
    {
        public Track Track;
        public List<Sprite> Sprites;
        public bool Loop;
        public float Speed = 10f;
        public float Counter;
        public bool Sleeps;

        public void Update()
        {
            if (Sleeps) { return; }

            Counter += Time.deltaTime * Speed;

            if (Loop)
            {
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if (Counter > Sprites.Count)
            {
                Counter = Sprites.Count - 1;
                Sleeps = true;
            }

        }
    }
}