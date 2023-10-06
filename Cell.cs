using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
	class Cell : Button
	{
		MyColor co;
		public int row;
		public int col;
		public Piece ps;
		public bool doubleJump;

		public Cell(MyColor clr, int r, int c, int W, int H, int dim, Piece p)
		{
			co = clr;
			row = r;
			col = c;
			ps = p;
			this.Width = W / dim ;
			this.Height = H / dim ;
			if(clr == MyColor.Black)
			{
				this.BackColor = ColorTranslator.FromHtml(chessConst.black);
			}
			else
			{
				this.BackColor = ColorTranslator.FromHtml(chessConst.white);
			}
			if (p != null) p.Draw(this);
		}
	}
}
