using System;
using System.Collections;
using System.Collections.Generic;
using Cells;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Grid
{
    public class GridClearControl : MonoBehaviour
    {
        [SerializeField] private List<CellBehavior> cells;

        public void SetCellBehavior(CellBehavior[,] cellBehaviors)
        {
            foreach (CellBehavior cell in cellBehaviors)
            {
                cells.Add(cell);
            }
        }
        
        public async void ClearRowOrColumn(int x, int y)
        {
            bool rowCheck = cells.Where(row => row.x == x ).All(row=> row.Type == CellType.Filled);
            bool columnCheck = cells.Where(row => row.y == y ).All(row => row.Type == CellType.Filled);
            
            Debug.Log("ROW FULL " + rowCheck);
            Debug.Log("COLUMN FULL " + columnCheck);
            
            if (rowCheck)
            {
                foreach (CellBehavior cell in cells)
                {
                    if (cell.x == x)
                    {
                        await DeleteTile(cell);
                    }
                }
            }
            if (columnCheck)
            {
                foreach (CellBehavior cell in cells)
                {
                    if (cell.y == y)
                    {
                        await DeleteTile(cell);
                    }
                }
            }
        }

        private async Task DeleteTile(CellBehavior cell)
        {
            Destroy(cell.transform.GetChild(0).gameObject);
            cell.Type = CellType.Empty;
            await Task.Delay(200);
        }

    }
}