using finalProject_2020_q3.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Board
    {
        public static readonly Dictionary<string, int> positions = new Dictionary<string, int>
        {
            {"8", 0}, {"7", 1}, {"6", 2}, {"5", 3}, {"4", 4}, {"3", 5}, {"2", 6}, {"1", 7},
            {"a", 0}, {"b", 1}, {"c", 2}, {"d", 3}, {"e", 4}, {"f", 5}, {"g", 6}, {"h", 7}
        };
        public Color TopColor { get; set; }
        public Cell[,] Sets { get; }
        private Cell[,] CloneSets { get; set; }
        private int PiecesOnBoard;
        public GameResult Result;
        public Board(Color topColor = Color.WHITE)
        {
            this.TopColor = topColor;
            this.Sets = new Cell[8, 8];
            this.CloneSets = new Cell[8, 8];
            this.PiecesOnBoard = 16;
            this.Result = GameResult.Play;
            InitPieces();
        }
        public void InitPieces()
        {
            FillBoardCells();
            FillSet(TopColor, true);
            FillSet(TopColor == Color.BLACK ? Color.WHITE : Color.BLACK, false);
        }
        private void FillBoardCells()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.Sets[i, j] = new Cell(i, j);
                }
            }
        }
        private void FillSet(Color color, bool isTop)
        {
            int pawnsPosition;
            int majorsPosition;
            if (isTop)
            {
                //pawnsPosition = 6;
                //majorsPosition = 7;
                pawnsPosition = 1;
                majorsPosition = 0;
            }
            else
            {
                //pawnsPosition = 1;
                //majorsPosition = 0;
                pawnsPosition = 6;
                majorsPosition = 7;
            }

            for (int i = 0; i < 8; i++)
            {
                this.Sets[pawnsPosition, i].piece = PieceFactory.BuildPieces(PieceType.PAWN, color, isTop);
            }
            this.Sets[majorsPosition, 0].piece = PieceFactory.BuildPieces(PieceType.ROOK, color);
            this.Sets[majorsPosition, 1].piece = PieceFactory.BuildPieces(PieceType.KNIGHT, color);
            this.Sets[majorsPosition, 2].piece = PieceFactory.BuildPieces(PieceType.BISHOP, color);
            this.Sets[majorsPosition, 3].piece = PieceFactory.BuildPieces(PieceType.QUEEN, color);
            this.Sets[majorsPosition, 4].piece = PieceFactory.BuildPieces(PieceType.KING, color);
            this.Sets[majorsPosition, 5].piece = PieceFactory.BuildPieces(PieceType.BISHOP, color);
            this.Sets[majorsPosition, 6].piece = PieceFactory.BuildPieces(PieceType.KNIGHT, color);
            this.Sets[majorsPosition, 7].piece = PieceFactory.BuildPieces(PieceType.ROOK, color);
        }

        public Cell GetCell(string cell)
        {
            string rowString = cell.Substring(0, 1);
            string columnString = cell.Substring(1);
            int rowInMatrix = positions[rowString];
            int columnInMatrix = positions[columnString];
            return this.Sets[rowInMatrix, columnInMatrix];
        }

        public void Rollback(Cell source, Cell target, Piece sourcePiece, Piece targetPiece, Cell[,] sets)
        {
            AddPiece(sourcePiece, source, sets);
            AddPiece(targetPiece, target, sets);
        }

        public bool ApplyMovement(Cell source, Cell target, PieceType promotedType = PieceType.NONE)
        {
           return ApplyMovementSet(source, target, Sets, promotedType);
        }

        public bool ApplyMovementSet(Cell source, Cell target, Cell[,] sets, PieceType promotedType = PieceType.NONE)
        {
            EnPassant(source, target);
            Piece sourcePiece = RemovePiece(source, sets);
            if (sourcePiece is null)
            {
                return false;
            }
            Piece targetPiece;
            if (!(target.piece is null)) {
                targetPiece = RemovePiece(target, sets);
            }
            Piece pieceToAdd = promotedType == PieceType.NONE ?
                sourcePiece :
                (sourcePiece as Pawn).Promote(promotedType);
            if (AddPiece(pieceToAdd, target, sets))
            {
                var status = GetGameStatus(sourcePiece.Color, sets);
                if (status != GameStatus.Draw)
                {
                    Rollback(source, target, sourcePiece, target.piece, sets);
                    return false;
                }
            }
            if (sourcePiece is IMoved)
            {
                ((IMoved)sourcePiece).PiceMoved(true);
            }
            return true;
        }

        public bool AddPiece(Piece piece, Cell cell, Cell[,] sets) { 
             return Add(piece, cell.GetRow(), cell.GetColumn(), sets);
        }
        private void EnPassant(Cell source, Cell target)
        {
            Piece sourcePiece = source.piece;
            if (sourcePiece is Pawn)
            {
                Pawn sourcePawn = sourcePiece as Pawn;
                CellList passantCells = sourcePawn.EnPassantMovements(this.Sets, source.Row, source.Column);
                foreach (var passantCell in passantCells)
                {
                    if (passantCell.Column == target.Column)
                    {
                        int columnToRemove = passantCell.Column;
                        int rowToRemove = sourcePawn.IsTop? passantCell.Row - 1: passantCell.Row + 1;
                        Remove(Cell.rowsString[rowToRemove], Cell.columnsString[columnToRemove], this.Sets);
                        break;
                    }
                }
            }
        }

        public bool Add(Piece piece, string row, string column, Cell[,] sets)
        {
            bool result = false;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                if (this.PiecesOnBoard < 16)
                {
                    int rowInMatrix = positions[row];
                    int columnInMatrix = positions[column];
                    sets[rowInMatrix, columnInMatrix].piece = piece;
                    this.PiecesOnBoard++;
                    result = true;
                }
            }
            return result;
        }

        public Piece RemovePiece(Cell cell, Cell[,] sets)
        {
            return Remove(cell.GetRow(), cell.GetColumn(), sets);
        }
        public Piece Remove(string row, string column, Cell[,] sets)
        {
            Piece removedPiece = null;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                removedPiece = this.Sets[rowInMatrix, columnInMatrix].piece;
                sets[rowInMatrix, columnInMatrix].RemovePiece();
                this.PiecesOnBoard--;
            }
            return removedPiece;
        }
        public string[] GetMovements(string row, string column)
        {
            string[] movements = new string[0];
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                Cell cell = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = cell.GetValidMovements(this.Sets);
                movements = new string[validCells.Count];
                for (int i = 0; i < movements.Length; i++)
                {
                    movements[i] = validCells[i].ToString();
                }
            }
            return movements;
        }
        public String[] AttackMovements(string row, string column)
        {
            string[] attackMovements = new string[0];
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                Cell cell = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = cell.GetAttackMovements(this.Sets);
                attackMovements = new string[validCells.Count];
                for (int i = 0; i < attackMovements.Length; i++)
                {
                    attackMovements[i] = validCells[i].ToString();
                }
            }
            return attackMovements;
        }
        public String[] CaptureFreeCells(string row, string column)
        {
            return new String[0];
        }

        public Cell GetKingCell(Color color, Cell[,] Sets)
        {
            Cell kingCell = null;
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (!(Sets[i, j].piece is null) && Sets[i, j].piece.Color == color
                        && Sets[i, j].piece is King)
                    {
                        kingCell = Sets[i, j];
                    }
                }
            }
            return kingCell;
        }

        public CellList GetAllCellAtack(Color color, Cell[,] Sets)
        {
            CellList cellsToAtack = new CellList();
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (!(Sets[i, j].piece is null) && Sets[i, j].piece.Color == color)
                    {
                        CellList attackCells = Sets[i, j].piece.ValidMovements(Sets, Sets[i, j].Row, Sets[i, j].Column);
                        foreach (Cell cell in attackCells)
                        {
                            cellsToAtack.Add(cell);
                        }
                    }
                }
            }
            return cellsToAtack;
        }

        public GameStatus GetGameStatus(Color color, Cell[,] Sets)
        {
            GameStatus status = GameStatus.Draw;
            CellList cellsToAtack = new CellList();
            bool kingUnderAttack = false;
            if (color == Color.WHITE)
            {
                Cell WhiteKingCell = GetKingCell(color, Sets);
                cellsToAtack = GetAllCellAtack(Color.BLACK, Sets);
                kingUnderAttack = cellsToAtack.Any(cell => cell.CompareCell(WhiteKingCell));
                status = kingUnderAttack == true ? GameStatus.BlackInCheck : GameStatus.Draw;
            } else if (color == Color.BLACK)
            {
                Cell BlackKingCell = GetKingCell(color, Sets);
                cellsToAtack = GetAllCellAtack(Color.WHITE, Sets);
                kingUnderAttack = cellsToAtack.Any(cell => cell.CompareCell(BlackKingCell));
                status = kingUnderAttack == true ? GameStatus.BlackInCheck : GameStatus.Draw;
            }
            return status;
        }

        public bool IsPromotion(Cell source, Cell target)
        {
            bool isPrometed = false;
            Piece piece = source.piece;
            if (piece is Pawn)
            {
                Pawn pawn = piece as Pawn;
                int lastRow = pawn.IsTop ? 0 : 7;
                if (target.Row == lastRow)
                {
                    isPrometed = true;
                }
            }
            return isPrometed;
        }

        public GameResult GetGameResult(GameStatus status)
        {
            GameResult result = GameResult.Play;
            GameStatus checkMateStatus = ValidateCheckMate(status);
            status = checkMateStatus == GameStatus.Draw? status : checkMateStatus;
            if (status == GameStatus.BlackInCheckMatted) 
            {
                result = GameResult.WhiteWin;
            }
            if (status== GameStatus.WhiteInCheckMatted)
            {
                result = GameResult.BlackWin;
            }
            return result;
        }

        public GameStatus ValidateCheckMate(GameStatus status)
        {
            if (status == GameStatus.Draw || status == GameStatus.WhiteInCheckMatted || status == GameStatus.BlackInCheckMatted) {
                return status;
            }
            return RunSimulation(status, Sets);
        }

        public GameStatus RunSimulation(GameStatus status, Cell[,] sets)
        {
            GameStatus checkStatus = status;
            CloneSets = CloneCells(sets);
            Color color = status == GameStatus.WhiteInCheck ? Color.BLACK : Color.WHITE;
            for (var i = 0; i < 8; i++)
            {
                if (checkStatus == GameStatus.Draw)
                {
                    break;
                }
                for (var j = 0; j < 8;  j++)
                {
                    if (!(CloneSets[i, j].piece is null)) { 
                        checkStatus = GetCheckOut(CloneSets[i,j], CloneSets, checkStatus, color);
                        if (checkStatus == GameStatus.Draw)
                        {
                            break;
                        }
                    }
                }
            }
            return GetCheckMate(checkStatus);
        }

        public Cell[,] CloneCells(Cell[,] sets)
        {
            for(var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    Cell cloneCell = new Cell(i,j);
                    cloneCell.piece = sets[i, j].piece;
                    CloneSets[i, j] = cloneCell;
                }
            }
            return CloneSets;
        }

        public GameStatus GetCheckMate(GameStatus status)
        {
            GameStatus checkMateStatus = GameStatus.Draw;
            if (GameStatus.WhiteInCheck == status)
            {
                checkMateStatus = GameStatus.WhiteInCheckMatted;
            }
            if (GameStatus.BlackInCheck == status)
            {
                checkMateStatus = GameStatus.BlackInCheckMatted;
            }
            return checkMateStatus;
        }

        public GameStatus GetCheckOut(Cell cell, Cell[,] sets, GameStatus status, Color color)
        {
            GameStatus checkStatus = status;
            if (cell.piece is null)
            {
                return checkStatus;
            }
            if (status == GameStatus.BlackInCheck && cell.piece.Color == color)
            {
                CellList validMovements = cell.GetValidMovements(sets);
                foreach (Cell target in validMovements)
                {
                    bool posibleMove = ApplyMovementSet(cell, target, sets);
                    if (posibleMove)
                    {
                        Rollback(cell, target, cell.piece, target.piece, sets);
                        checkStatus = GameStatus.Draw;
                        break;
                    }
                }
            } else if (status == GameStatus.WhiteInCheck && cell.piece.Color == color)
            {
                CellList validMovements = cell.GetValidMovements(sets);
                foreach (Cell target in validMovements)
                {
                    bool posibleMove = ApplyMovementSet(cell, target, sets);
                    if (posibleMove)
                    {
                        Rollback(cell, target, cell.piece, target.piece, sets);
                        checkStatus = GameStatus.Draw;
                        break;
                    }
                }
            }
            return checkStatus;
        }
        public bool Castling(Cell king)
        {
            Cell rook = this.Sets[king.Row, 7];
            if(rook.piece is ICastling && king.piece is ICastling)
            {
                Rook rk = (Rook)rook.piece;
                King kn = (King)king.piece;
                if (rk.IsAbleTocast() && kn.IsAbleTocast() && rook.GetColumn() == "h")
                {
                    if (rook.Row == king.Row && this.Sets[rook.Row, 5].IsEmpty() && this.Sets[rook.Row, 6].IsEmpty())
                    {
                        ApplyMovement(king, this.Sets[rook.Row, 6]);
                        ApplyMovement(rook, this.Sets[rook.Row, 5]);
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
}
