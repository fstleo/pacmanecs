﻿using Leopotam.Ecs;
using Players;
using Teleports;
using Ui.ScoreTable;
using UnityEngine;
using World;

namespace Death.Systems
{
    public class DeathSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<PlayerComponent, PlayerIsDeadEvent> _deadPlayers = null;

        public void Run()
        {
            foreach (int i in _deadPlayers)
            {
                PlayerComponent deadPlayer = _deadPlayers.Get1[i];
                EcsEntity playerEntity = _deadPlayers.Entities[i];

                Vector2Int spawnPosition = deadPlayer.SpawnPosition;
                if (--deadPlayer.Lives <= 0)
                {
                    deadPlayer.IsDead = true;
                    spawnPosition = Vector2Int.zero;
                    playerEntity.Set<DestroyedWorldObjectComponent>();
                }

                playerEntity.Set<TeleportedComponent>().NewPosition = spawnPosition;
                _ecsWorld.NewEntityWith(out UpdateScoreTableEvent _);
            }
        }
    }
}