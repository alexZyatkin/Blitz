using Cells;
using Sirenix.OdinInspector;
using UnityEngine;

public class TileProperties : MonoBehaviour
{
    [SerializeField] private CellColor _tileColor;
    [SerializeField] private CellFigure _tileFigure;
    
    public CellColor TileColor => _tileColor;
    public CellFigure TileFigure => _tileFigure;
}