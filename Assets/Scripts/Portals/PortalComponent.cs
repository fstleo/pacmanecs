﻿using Leopotam.Ecs;

namespace Portals
{
    public class PortalComponent : IEcsAutoReset
    {
        public EcsEntity OtherPortalEntity;
        public float EstimateReloadTime;
        
        public void Reset()
        {
            OtherPortalEntity = EcsEntity.Null;
        }
    }
}