using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
	class King : Piece
	{
		public bool isMove;
		public King(MyColor co, String n) : base(co, n)
		{
			isMove = false;
		}
		private bool castling(Cell[,] allcells, bool highlight)
		{
			bool canProtect = false;
			if (!isMove)
			{
				string playerRook = (this.co == MyColor.Black) ? "b_rook" : "w_rook";
				if (this.co == MyColor.White)
				{
					if (allcells[7, 7].ps != null && allcells[7, 7].ps.name == playerRook)
					{
						Rook temp = (Rook)allcells[7, 7].ps;
						if (!temp.isMove && allcells[7, 5].ps == null && allcells[7, 6].ps == null && (int)allcells[7, 6].Tag == 2)
						{
							if(highlight) allcells[7, 6].BackColor = ColorTranslator.FromHtml(chessConst.castlingColor);
							canProtect = true;
						}
					}
					if (allcells[7, 0].ps != null && allcells[7, 0].ps.name == playerRook)
					{
						Rook temp = (Rook)allcells[7, 0].ps;
						if (!temp.isMove && allcells[7, 1].ps == null && allcells[7, 2].ps == null && allcells[7, 3].ps == null && (int)allcells[7, 2].Tag == 2)
						{
							if (highlight) allcells[7, 2].BackColor = ColorTranslator.FromHtml(chessConst.castlingColor);
							canProtect = true;
						}
					}
				}
				else
				{
					if (allcells[0, 7].ps != null && allcells[0, 7].ps.name == playerRook)
					{
						Rook temp = (Rook)allcells[0, 7].ps;
						if (!temp.isMove && allcells[0, 5].ps == null && allcells[0, 6].ps == null && (int)allcells[0, 6].Tag == 2)
						{
							if (highlight) allcells[0, 6].BackColor = ColorTranslator.FromHtml(chessConst.castlingColor);
							canProtect = true;
						}
					}
					if (allcells[0, 0].ps != null && allcells[0, 0].ps.name == playerRook)
					{
						Rook temp = (Rook)allcells[0, 0].ps;
						if (!temp.isMove && allcells[0, 1].ps == null && allcells[0, 2].ps == null && allcells[0, 3].ps == null && (int)allcells[0, 2].Tag == 2)
						{
							if (highlight) allcells[0, 2].BackColor = ColorTranslator.FromHtml(chessConst.castlingColor);
							canProtect = true;
						}
					}
				}
			}
			return canProtect;
		}
		public override void highlightMove(int row, int col, MyColor playerColor, Cell[,] allcells)
		{
			this.kingHighlight(row, col, allcells, true);
			this.castling(allcells, true);
		}
		public override void checkFootPrint(int row, int col, Cell[,] allcells)
		{
			this.kingHighlight(row, col, allcells, false);
		}
		public override bool highlightProAreas(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells, bool highlight)
		{
			return (kingCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, allcells, highlight) || this.castling(allcells, highlight)) ;
		}
	}
}
