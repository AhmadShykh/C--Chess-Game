using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class Queen:Piece
	{
		public Queen(MyColor co, String n) : base(co, n)
		{

		}
		public override void highlightMove(int row, int col, MyColor playerColor, Cell[,] allcells)
		{
			this.highlightHorizontal(row, col, allcells,true);
			this.highlightVertical(row, col, allcells, true);
			this.highlightForwardDiagonal(row, col, allcells, true);
			this.highlightBackwardDiagonal(row, col, allcells, true);
		}
		public override void checkFootPrint(int row, int col, Cell[,] allcells)
		{
			this.highlightHorizontal(row, col, allcells, false);
			this.highlightVertical(row, col, allcells, false);
			this.highlightForwardDiagonal(row, col, allcells, false);
			this.highlightBackwardDiagonal(row, col, allcells, false);
		}
		public override bool highlightProAreas(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells,bool highlight)
		{
			bool canProtect = false;
			int destX = -1, destY = -1;
			horizontalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				canProtect = true;
				if(highlight) highlightRespCell(allcells[destX, destY]);
			}
			verticalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				canProtect = true;
				if (highlight) highlightRespCell(allcells[destX, destY]);
			}
			forwardDiagonalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				canProtect = true;
				if (highlight) highlightRespCell(allcells[destX, destY]);
			}
			backwardDiagonalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				canProtect = true;
				if (highlight) highlightRespCell(allcells[destX, destY]);
			}
			return canProtect;
		}
	}
}
