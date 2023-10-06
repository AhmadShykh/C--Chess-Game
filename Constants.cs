using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public enum MyColor
	{
		Black,
		White
	}
	public static class chessConst {
		public const string white = "#784738";
		public const string black = "#4D2626";
		public const string canWalk = "#565555";
		public const string doubleJump = "#565556";
		public const string canDie = "#333231";
		public const string kingCheck = "#EE1B24";
		public const string castlingColor = "#1122BC";
		public const string enPassant = "#007C00";

		public const int Dim = 8;
		
	}

}
