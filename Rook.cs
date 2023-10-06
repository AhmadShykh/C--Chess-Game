using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class Rook:Piece
	{
		public bool isMove;
		public Rook(MyColor co, String n) : base(co, n)
		{
			isMove = false;
		}
		public override void highlightMove(int row, int col, MyColor playerColor, Cell[,] allcells)
		{
			this.highlightHorizontal(row, col,  allcells,true);
			this.highlightVertical(row, col,  allcells,true);
		}
		public override void checkFootPrint(int row, int col, Cell[,] allcells)
		{
			this.highlightHorizontal(row, col, allcells, false);
			this.highlightVertical(row, col, allcells, false);
		}
		public override bool highlightProAreas(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells, bool highlight)
		{
			int destX = -1, destY = -1;
			bool canProtect = false;
			horizontalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if(destY != -1)
			{
				if(highlight) highlightRespCell(allcells[destX, destY]);
				canProtect = true;
			}
			verticalCheck(row, col, chkSrcX, chkSrcY, chkDesX, chkDesY, ref destX, ref destY, allcells);
			if (destY != -1)
			{
				if (highlight)
					highlightRespCell(allcells[destX, destY]);
				canProtect = true ;
			}
			return canProtect;
		}
	}
}
