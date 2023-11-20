using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Checkpoint
    {
        public Vector3 position;
        public float rotation;
        public Checkpoint(Vector3 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}
