using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOLevelSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Levels Configurations")]
    public int startPiecesNumber = 1;
    public int middlePiecesNumber = 3;
    public int endPiecesNumber = 1;

    [Header("Pieces")]
    public List<LevelPieceBase> startPieces;
    public List<LevelPieceBase> middlePieces;
    public List<LevelPieceBase> endPieces;
}
