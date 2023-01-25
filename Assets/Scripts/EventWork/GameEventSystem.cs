using System;
using Grid;

namespace EventWork
{
    public class GameEventSystem
    {
        public static event Action<TileProperties> OnStartMoveTile;
        public static event Action OnEndMoveTile;
        public static event Action OnCheckStartSpawn;
        public static event Action OnSpawnPointEmpty;
        //public static event Action OnCheckClearRowOrColumn;
        
        public static void SendTileMove(TileProperties properties)
        {
            OnStartMoveTile?.Invoke(properties);
        }

        public static void SendTileEndMove()
        {
            OnEndMoveTile?.Invoke();
        }

        public static void SendCheckSpawn()
        {
            OnCheckStartSpawn?.Invoke();
        }

        public static void SendEmptySpawnPoint()
        {
            OnSpawnPointEmpty?.Invoke();
        }
        // public static void SendCheckClear()
        // {
        //     OnCheckClearRowOrColumn?.Invoke();
        // }
    }
}