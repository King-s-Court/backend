﻿using System.Text;
using logic;

namespace common.models;

public class Board
{
    // [ranks, files]
    private Square[,] Squares = new Square[8, 8];
    public string ToMove { get; set; }
    public string CastlingRights { get; set; }
    public string EnPassant { get; set; }
    public string HalfmoveClock { get; set; }
    public string FullmoveClock { get; set; }

    public Board()
    {
        ToMove = "w";
        CastlingRights = "KQkq";
        EnPassant = "-";
        HalfmoveClock = "0";
        FullmoveClock = "1";

        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                Squares[rank, file] = new Square();
            }
        }
    }

    public Square[,] GetBoardSquares()
    {
        return Squares;
    }

    public void AddPiece(int rank, int file, Piece? piece)
    {
        Squares[rank, file].SquarePiece = piece;
    }

    public Piece? GetPiece(int rank, int file)
    {
        return Squares[rank, file].SquarePiece;
    }

    public void DestroyPiece(int rank, int file)
    {
        Squares[rank, file].SquarePiece = null;
    }

    public void MovePiece(int startRank, int startFile, int targetRank, int targetFile)
    {
        if (IsOccupied(startRank, startFile))
        {
            Piece? piece = GetPiece(startRank, startFile);
            AddPiece(targetRank, targetFile, piece);
            DestroyPiece(startRank, startFile);
        }
        else
        {
            throw new InvalidOperationException("No piece found.");
        }
    }

    public bool IsOccupied(int rank, int file)
    {
        return GetPiece(rank, file) is not null;
    }

    public string AsFENString()
    {
        StringBuilder fenBuilder = new();

        for (int rank = 0; rank < 8; rank++)
        {
            int emptySquares = 0;
            for (int file = 0; file < 8; file++)
            {
                if (!IsOccupied(rank, file))
                {
                    emptySquares++;
                }

                else
                {
                    if (emptySquares > 0)
                    {
                        fenBuilder.Append(emptySquares);
                        emptySquares = 0;
                    }
                    fenBuilder.Append(GetPiece(rank, file)?.AsFENChar());
                }
            }

            if (emptySquares > 0)
            {
                fenBuilder.Append(emptySquares);
            }

            if (rank < 7)
            {
                fenBuilder.Append("/");
            }

        }
        fenBuilder.Append($" {ToMove} {CastlingRights} {EnPassant} {HalfmoveClock} {FullmoveClock}");
        return fenBuilder.ToString();

    }
}