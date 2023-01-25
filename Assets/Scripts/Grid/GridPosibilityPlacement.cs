using System;
using System.Collections.Generic;
using Cells;
using EventWork;
using UnityEngine;
using UnityEngine.UI;

namespace Grid
{
    public class GridPosibilityPlacement : MonoBehaviour
    {
        [SerializeField] private Sprite _normalCellImage;
        [SerializeField] private Sprite _uncorrectCellImage;
        [SerializeField] private CellBehavior[,] cells;

        private void Awake()
        {
            GameEventSystem.OnStartMoveTile += CheckCellPlace;
            GameEventSystem.OnEndMoveTile += NormalGridView;
        }

        private void OnDestroy()
        {
            GameEventSystem.OnStartMoveTile -= CheckCellPlace;
            GameEventSystem.OnEndMoveTile -= NormalGridView;
        }

        public void SetCellBehavior(CellBehavior[,] cellBehaviors)
        {
            cells = cellBehaviors;
        }
        public void CheckCellPlace(TileProperties selectedTile)
        {
            foreach (CellBehavior cell in cells)
            {
                Image img = cell.GetComponent<Image>();
                if (cell.Type == CellType.Empty)
                {
                    if (cell.CellColorList == null || cell.CellFigureList == null)
                    {
                        return;
                    }
                    
                    for (int i = 0; i < cell.CellColorList.Count; i++)
                    {
                        for (int j = 0; j < cell.CellFigureList.Count; j++)
                        {
                            if (cell.CellColorList[i] != selectedTile.TileColor
                                && cell.CellFigureList[j] != selectedTile.TileFigure)
                            {
                                cell.IsPosibleToPlace = false;
                                img.sprite = _uncorrectCellImage;
                            }
                            else
                            {
                                cell.IsPosibleToPlace = true;
                                img.sprite = _normalCellImage;
                            }
                        }
                    }
                }
            }
        }

        public void NormalGridView()
        {
            foreach (CellBehavior cell in cells)
            {
                Image img = cell.GetComponent<Image>();
                img.sprite = _normalCellImage;
                if (cell.Type == CellType.Filled)
                {
                    cell.IsPosibleToPlace = false;
                }
                else
                {
                    cell.IsPosibleToPlace = true;
                }
            }
        }
    }
}