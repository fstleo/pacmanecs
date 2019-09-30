﻿using Leopotam.Ecs;
using UnityEngine;

namespace Ghosts
{
    public enum GhostTypes
    {
        Blinky,
        Pinky,
        Inky,
        Clyde
    }

    public class GhostComponent : IEcsAutoReset
    {
        public GhostTypes GhostType;
        public MeshRenderer Renderer;
        
        public void Reset()
        {
            Renderer = null;
        }
    }
}