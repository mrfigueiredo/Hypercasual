using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform levelContainer;

    public List<SOLevelSetup> soLevelSetups;

    private List<LevelPieceBase> _spawnedPieces;
    [SerializeField] private SOLevelSetup _currentLevel;


    private void Awake()
    {
        _currentLevel = soLevelSetups[Random.Range(0, soLevelSetups.Count)];
        CreateRandomLevel();
    }

    #region RandomLevel

    private void CreateRandomLevel()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currentLevel.startPiecesNumber; i++)
        {
            CreateLevelPiece(_currentLevel.startPieces);
        }

        for (int i = 0; i < _currentLevel.middlePiecesNumber; i++)
        {
            CreateLevelPiece(_currentLevel.middlePieces);
        }

        for (int i = 0; i < _currentLevel.endPiecesNumber; i++)
        {
            CreateLevelPiece(_currentLevel.endPieces);
        }

        ConfigureColors(_currentLevel.artType);
    }

    private void CreateLevelPiece(List<LevelPieceBase> pieces)
    {

        var piece = pieces[Random.Range(0, pieces.Count)];
        var spawnedPiece = Instantiate(piece, levelContainer);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPosPiece.position;
        }

        ConfigureProps(spawnedPiece.gameObject, _currentLevel.artType);

        _spawnedPieces.Add(spawnedPiece);
    }
    #endregion

    private void ConfigureProps(GameObject piece, ArtManager.ArtType artType)
    {
        foreach (var i in piece.GetComponentsInChildren<ArtPiece>())
        {
            i.ChangeArtProp(ArtManager.Instance.GetPropByType(_currentLevel.artType));
        }

    }

    private void ConfigureColors(ArtManager.ArtType artType)
    {
        ColorManager.Instance.ChangeColorByType(_currentLevel.artType);
    }
}