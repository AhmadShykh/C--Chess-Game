using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class Bishop:Piece
	{
		public Bishop(MyColor co, String n) : base(co, n)
		{

		}
		public override void highlightMove(int row, int col, MyColor playerColor, Cell[,] allcells)
		{
			this.highlightForwardDiagonal(row, col,  allcells,true);
			this.highlightBackwardDiagonal(row, col,  allcells, true);
		}
		public override void checkFootPrint(int row, int col, Cell[,] allcells)
		{
			this.highlightForwardDiagonal(row, col, allcells,false);
			this.highlightBackwardDiagonal(row, col, allcells, false);
		}
		public override bool highlightProAreas(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells,bool highlight)
		{
			int destX = -1, destY = -1;
			bool canProtect = false;
			forwardDiagonalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				if (highlight) highlightRespCell(allcells[destX, destY]);
				canProtect = true;
			}
			backwardDiagonalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				if(highlight) highlightRespCell(allcells[destX, destY]);
				canProtect = true;
			}
			return canProtect;
		}
	}
}
