﻿using common.models;
using static System.Console;

namespace logic;

public static class BoardVisualizer
{
    /// <summary>
    /// Reads data stored in Board.Squares and outputs them in CLI.
    /// <param name="FEN">
    ///  </param>
    /// </summary>
    public static void VisualizeBoardFromSquares()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            Write("\n---------------------------------\n");
            for (int file = 0; file < 8; file++)
            {
                Write("|");
                if (!Board.IsOccupied(rank, file))
                {
                    Write("   ");
                }
                else
                {
                    Write(" " + Board.GetPiece(rank, file).AsFENChar() + " ");
                }
            }
            Write($"| {8 - rank}");
        }
        Write("\n---------------------------------");
        Write("\n  a   b   c   d   e   f   g   h \n\n");
        Write("Color to move: \n");
        Write(Board.ToMove == "w" ? "White\n\n" : "Black\n\n");
        Write("Castling rights: \n");
        foreach (char symbol in Board.CastlingRights)
        {
            Write(CastlingRightsDictionary._castlingRights[symbol] + '\n');
        }
        Write("\n");
        Write($"En passant target square: \n {Board.EnPassant}");

    }

    public static void VisualizeBoardForSystemCoords()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            Write("\n---------------------------------\n");
            for (int file = 0; file < 8; file++)
            {
                Write("|");
                Write($"{rank}:{file}");
            }
            Write($"| {8 - rank}");
        }
        Write("\n---------------------------------");
        Write("\n  a   b   c   d   e   f   g   h \n\n");
    }
}