using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace WindowsFormsApp1
{
	abstract class Piece
	{
		public MyColor co;
		public string name;
		public int row;
		public int col;

		public Piece(MyColor c, string n)
		{
			co = c;
			name = n;
		}
		public bool highlightRespCell(Cell highlightCell)
		{
			//returning wethere there is a ps inbetween or not
			if (highlightCell.ps == null)
			{
				highlightCell.BackColor = ColorTranslator.FromHtml(chessConst.canWalk);
				return true;
			}
			else
			{
				if (this.co != highlightCell.ps.co) highlightCell.BackColor = ColorTranslator.FromHtml(chessConst.canDie);
				return false;
			}
		}
		public float distance(int x1, int y1, int x2, int y2)
		{
			return (float) Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
		}
		public bool chkPointLineInter(int x1, int y1, int x2, int y2, int x3, int y3, ref int destX, ref int destY)
		{
			if(x3 == x2 && y2 == y3 && x1 != x2 && y2 != y1)
		 	{
				destX = -1;
				destY = -1;
				return false;
			}
			else if(x3 == x1 && y3 == y1)
			{
				destX = x3;
				destY = y3;
				return true;
			}
			else
			{
				float x1Toyx3Andx2Tox3 = distance(x1, y1, x3, y3) + distance(x2, y2, x3, y3);
				float x1Tox2 = distance(x1, y1, x2, y2);
				if (x1Toyx3Andx2Tox3 == x1Tox2)
				{
					destX = x3;
					destY = y3;
					return true;
				}
				else
				{
					destX = -1;
					destY = -1;
					return false;
				}
			}
			
		  
		}
		public void Draw(Cell C)
		{
			if (name == "b_pawn")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_pawn;
			else if (name == "w_pawn")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_pawn;
			else if (name == "w_rook")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_rook;
			else if (name == "b_rook")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_rook;
			else if (name == "b_bishop")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_bishop;
			else if (name == "w_bishop")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_bishop;
			else if (name == "w_knight")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_knight;
			else if (name == "b_knight")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_knight;
			else if (name == "w_king")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_king;
			else if (name == "b_king")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_king;
			else if (name == "w_queen")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_queen;
			else if (name == "b_queen")
				C.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_queen;
		}
		public void remDraw(Cell C) => C.BackgroundImage = null;
		private int selectStatus()
		{ 
			if (this.co == MyColor.Black)
				return 0;
			else
				return 1;
		}
		abstract public void highlightMove(int row, int col,MyColor playerColor, Cell[,] allcells);
		abstract public bool highlightProAreas(int row,int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells,bool highlight);
		//Checking the footprints of the piece where it lies and send a highlight = false in the functions tellinng that to mark those areas where enemy pieces can step
		abstract public void checkFootPrint(int row, int col, Cell[,] allcells);
		
		//================================================================================================================================
		// All general highlighting of areas where a piece can step 
		public void highlightVertical(int row, int col,Cell[,] allcells,bool highLight)
		{
			for(int i = row+1; i < chessConst.Dim; i++)
			{
				if(highLight)
				{
					if (!highlightRespCell(allcells[i, col]))
						break;
				}
				else
				{
					allcells[i, col].Tag = selectStatus();
					if (allcells[i, col].ps != null)
					{
						if((allcells[i, col].ps.name == "b_king" || allcells[i, col].ps.name == "w_king") && i+1 < chessConst.Dim)
							allcells[i+1, col].Tag = selectStatus();
						break;
					}
						
				}


			}
			for (int i = row - 1; i >= 0; i--)
			{
				if(highLight)
				{
					if (!highlightRespCell(allcells[i, col]))
						break;
				}
				else
				{
					allcells[i, col].Tag = selectStatus();
					if (allcells[i, col].ps != null)
					{
						if ((allcells[i, col].ps.name == "b_king" || allcells[i, col].ps.name == "w_king") && i - 1 >= 0)
							allcells[i-1, col].Tag = selectStatus();
						break;
					}
						
				}
			}

		}
		public void highlightHorizontal(int row, int col, Cell[,] allcells,bool highLight)
		{
			for (int i = col + 1; i < chessConst.Dim; i++)
			{
				if(highLight)
				{
					if (!highlightRespCell(allcells[row, i]))
						break;
				}
				else
				{
					allcells[row, i].Tag = selectStatus();
					if (allcells[row, i].ps != null)
					{
						if ((allcells[row, i].ps.name == "b_king" || allcells[row, i].ps.name == "w_king") && i + 1 < chessConst.Dim)
							allcells[row, i+1].Tag = selectStatus();
						break;
					}
						
				}

			}
			for (int i = col - 1; i >= 0; i--)
			{
				if (highLight)
				{
					if (!highlightRespCell(allcells[row, i]))
						break;
				}
				else
				{
					allcells[row, i].Tag = selectStatus();
					if (allcells[row, i].ps != null)
					{
						if ((allcells[row, i].ps.name == "b_king" || allcells[row, i].ps.name == "w_king") && i - 1 >= 0)
							allcells[row, i-1].Tag = selectStatus();
						break;
					}
						
				}
				
			}

		}
		//Forward Diagonal Means the line goining like this '\' 
		public void highlightForwardDiagonal(int row, int col, Cell[,] allcells,bool highLight)
		{
			for (int i = col + 1,j = row+ 1; i < chessConst.Dim && j < chessConst.Dim; i++,j++)
			{
				if (highLight)
				{
					if (!highlightRespCell(allcells[j, i]))
						break;
				}
				else
				{
					allcells[j, i].Tag = selectStatus();
					if (allcells[j, i].ps != null)
					{
						if ((allcells[j, i].ps.name == "b_king" || allcells[j, i].ps.name == "w_king") && i + 1 < chessConst.Dim && j + 1 < chessConst.Dim)
							allcells[j+1, i+1].Tag = selectStatus();
						break; 
					}
						
				}
			}
			for (int i = col - 1, j = row - 1; i >= 0 && j >= 0; i--, j--)
			{
				if (highLight)
				{
					if (!highlightRespCell(allcells[j, i]))
						break;
				}
				else
				{
					allcells[j, i].Tag = selectStatus();
					if (allcells[j, i].ps != null)
					{
						if ((allcells[j, i].ps.name == "b_king" || allcells[j, i].ps.name == "w_king") && i-1 >= 0 && j-1 >= 0)
							allcells[j-1, i-1].Tag = selectStatus();
						break;
					}
				}
			}

		}
		//Forward Diagonal Means the line goining like this '/' 
		public void highlightBackwardDiagonal(int row, int col, Cell[,] allcells,bool highLight)
		{
			for (int i = col + 1, j = row - 1; i < chessConst.Dim && j >= 0; i++, j--)
			{
				if (highLight)
				{
					if (!highlightRespCell(allcells[j, i]))
						break;
				}
				else
				{
					allcells[j, i].Tag = selectStatus();
					if (allcells[j, i].ps != null)
					{
						if ((allcells[j, i].ps.name == "b_king" || allcells[j, i].ps.name == "w_king") && i + 1 < chessConst.Dim && j - 1 >= 0)
							allcells[j-1, i+1].Tag = selectStatus();
						break;
					}
				}
			}
			for (int i = col - 1, j = row + 1; i >= 0 && j < chessConst.Dim; i--, j++)
			{
				if (highLight)
				{
					if (!highlightRespCell(allcells[j, i]))
						break;
				}
				else
				{
					allcells[j, i].Tag = selectStatus();
					if (allcells[j, i].ps != null)
					{
						if ((allcells[j, i].ps.name == "b_king" || allcells[j, i].ps.name == "w_king") && j + 1 < chessConst.Dim && i - 1 >= 0)
							allcells[j+1, i-1].Tag = selectStatus();
						break;
					}
				}
			}

		}
		public void knightHighlight(int row, int col, Cell[,] allcells,bool highLight)
		{
			if (row + 2 < chessConst.Dim && col + 1 < chessConst.Dim)
			{
				if(highLight) highlightRespCell(allcells[row + 2, col + 1]);
				else
				{
					allcells[row + 2, col + 1].Tag = selectStatus();
				}
			}
				
			if (row + 2 < chessConst.Dim && col - 1 >= 0)
			{
				if (highLight)
					highlightRespCell(allcells[row + 2, col - 1]);
				else
					allcells[row + 2, col - 1].Tag = selectStatus();
			}
			if (row - 2 >= 0 && col + 1 < chessConst.Dim)
			{
				if (highLight)
					highlightRespCell(allcells[row - 2, col + 1]);
				else
					allcells[row - 2, col + 1].Tag = selectStatus();
			}
				
			if (row - 2 >= 0 && col - 1 >= 0)
			{
				if (highLight)
					highlightRespCell(allcells[row - 2, col - 1]);
				else
					allcells[row - 2, col - 1].Tag = selectStatus();
			}
			if (row + 1 < chessConst.Dim && col + 2 < chessConst.Dim)
			{
				if (highLight) highlightRespCell(allcells[row + 1, col + 2]);
				else
				{
					allcells[row + 1, col + 2].Tag = selectStatus();
				}
			}

			if (col + 2 < chessConst.Dim && row - 1 >= 0)
			{
				if (highLight)
					highlightRespCell(allcells[row -1, col +2]);
				else
					allcells[row -1, col +2].Tag = selectStatus();
			}

			if (col - 2 >= 0 && row + 1 < chessConst.Dim)
			{
				if (highLight)
					highlightRespCell(allcells[row+1, col -2]);
				else
					allcells[row +1, col -2].Tag = selectStatus();
			}

			if (col - 2 >= 0 && row - 1 >= 0)
			{
				if (highLight)
					highlightRespCell(allcells[row - 1, col - 2]);
				else
					allcells[row - 1, col - 2].Tag = selectStatus();
			}

		}
		public void pawnHighlight(int row, int col, Cell[,] allcells,bool highLight)
		{
			if(this.co == MyColor.Black) 
			{ 

				//Check for second step at first move
				if(highLight)
				{
					if (row == 1 && allcells[row + 2, col].ps == null && allcells[row + 1, col].ps == null)
					{
						allcells[row + 2, col].BackColor = ColorTranslator.FromHtml(chessConst.doubleJump);
					}
					//Checking for usual step at pawn move
					if (row + 1 < chessConst.Dim && allcells[row + 1, col].ps == null)
					{
						allcells[row + 1, col].BackColor = ColorTranslator.FromHtml(chessConst.canWalk);
					}
				}
				//Check for any diagonal kills
				if (row +1 < chessConst.Dim && col+1 < chessConst.Dim )
				{
					if (highLight)
					{
						if (allcells[row + 1, col + 1].ps != null && allcells[row + 1, col + 1].ps.co != this.co)
							allcells[row + 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.canDie);
					}
					else
						allcells[row + 1, col + 1].Tag = selectStatus();


				}
				if (row + 1 < chessConst.Dim && col - 1 >= 0 )
				{
					if (highLight)
					{
						if (allcells[row + 1, col - 1].ps != null && allcells[row + 1, col - 1].ps.co != this.co)
							allcells[row + 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.canDie);
					}
					else
						allcells[row + 1, col - 1].Tag = selectStatus();
				}
				//Check enpasssant move
				if(row == 4)
				{
					if(col + 1 < 8 && allcells[row,col+1].doubleJump && allcells[row+1, col + 1].ps == null)
					{
						if(highLight) allcells[row + 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
					}
					if (col - 1 >= 0 && allcells[row, col - 1].doubleJump && allcells[row + 1, col - 1].ps == null)
					{
						if (highLight) allcells[row + 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
					}
				}
			}
			else
			{
				if(highLight)
				{
					//Check for second step at first move
					if (row == 6 && allcells[row - 2, col].ps == null && allcells[row -1, col].ps == null)
					{
						allcells[row - 2, col].BackColor = ColorTranslator.FromHtml(chessConst.doubleJump);
					}
					//Checking for usual step at pawn move
					if (row - 1 >= 0 && allcells[row - 1, col].ps == null)
					{
						allcells[row - 1, col].BackColor = ColorTranslator.FromHtml(chessConst.canWalk);
					}
				}
				
				
				//Check for any diagonal kills
				if (row - 1 >= 0 && col + 1 < chessConst.Dim )
				{
					if (highLight)
					{
						if (allcells[row - 1, col + 1].ps != null && allcells[row - 1, col + 1].ps.co != this.co)
							allcells[row - 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.canDie);
					}
					else
						allcells[row - 1, col + 1].Tag = selectStatus();
				}
				if (row - 1 >= 0 && col - 1 >= 0 )
				{
					if (highLight)
					{
						if (allcells[row - 1, col - 1].ps != null && allcells[row - 1, col - 1].ps.co != this.co)
							allcells[row - 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.canDie);
					}
					else
						allcells[row - 1, col - 1].Tag = selectStatus();
				}
				//Check enpasssant move
				if (row == 3)
				{
					if (col + 1 < 8 && allcells[row, col + 1].doubleJump && allcells[row - 1, col + 1].ps == null)
					{
						if (highLight) allcells[row - 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
					}
					if (col - 1 >= 0 && allcells[row, col - 1].doubleJump && allcells[row - 1, col - 1].ps == null)
					{
						if (highLight) allcells[row - 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
					}
				}
			}
		}
		public void kingHighlight(int row, int col, Cell[,] allcells,bool highLight)
		{
			if (row + 1 < chessConst.Dim && col + 1 < chessConst.Dim)
			{
				if (highLight)
				{
					if ((int)allcells[row + 1, col + 1].Tag == 2)
						highlightRespCell(allcells[row + 1, col + 1]);
				}
				else
					allcells[row + 1, col + 1].Tag = selectStatus();
			}
				
			if (row + 1 < chessConst.Dim && col- 1 >= 0)
			{
				if (highLight)
				{
					if ((int)allcells[row + 1, col - 1].Tag == 2)
						highlightRespCell(allcells[row + 1, col - 1]);
				}
				else
					allcells[row + 1, col - 1].Tag = selectStatus();
			}
			if (row - 1 >= 0 && col + 1 < chessConst.Dim)
			{
				if (highLight)
				{
					if ((int)allcells[row - 1, col + 1].Tag == 2)
						highlightRespCell(allcells[row - 1, col + 1]);
				}
				else
					allcells[row - 1, col + 1].Tag = selectStatus();
			}
			if (row - 1 >= 0 && col - 1 >= 0)
			{
				if (highLight)
				{
					if ((int)allcells[row - 1, col - 1].Tag == 2)
						highlightRespCell(allcells[row - 1, col - 1]);
				}
				else
					allcells[row - 1, col - 1].Tag = selectStatus();
			}
			if (row + 1 < chessConst.Dim )
			{
				if (highLight)
				{
					if ((int)allcells[row + 1, col].Tag == 2)
						highlightRespCell(allcells[row + 1, col ]);
				}
				else
					allcells[row + 1, col ].Tag = selectStatus();
			}
			if (row - 1 >= 0 )
			{
				if (highLight)
				{
					if ((int)allcells[row - 1, col].Tag == 2)
						highlightRespCell(allcells[row - 1, col]);
				}
				else
					allcells[row - 1, col].Tag = selectStatus();
			}
			if (col + 1 < chessConst.Dim )
			{
				if (highLight)
				{
					if ((int)allcells[row , col+1].Tag == 2)
						highlightRespCell(allcells[row , col+1]);
				}
				else
					allcells[row , col+1].Tag = selectStatus();
			}
			if (col - 1 >= 0)
			{
				if (highLight)
				{
					if ((int)allcells[row , col-1].Tag == 2)
						highlightRespCell(allcells[row , col - 1]);
				}
				else
					allcells[row , col - 1].Tag = selectStatus();
			}
		}

		//================================================================================================================================
		// Checking where piece can protect the king
		public void horizontalCheck(int row,int col,int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX,ref int destY,Cell[,] allcells)
		{
			for(int i = col+1;  i < chessConst.Dim; i++)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row, i, ref destX, ref destY))
					return;
				else if (allcells[row, i].ps != null)
					break;
			}
			for (int i = col - 1; i >= 0; i--)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row, i, ref destX, ref destY))
					return;
				else if (allcells[row, i].ps != null)
					break;
			}
		}
		public void verticalCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX, ref int destY,Cell[,] allcells)
		{
			for (int i = row + 1; i < chessConst.Dim; i++)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, col, ref destX, ref destY))
					return;
				else if (allcells[i, col].ps != null)
					break;
			}
			for (int i = row - 1; i >= 0; i--)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, col, ref destX, ref destY))
					return;
				else if (allcells[i, col].ps != null)
					break;
			}
		}
		public void forwardDiagonalCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX, ref int destY,Cell[,] allcells)
		{
			for (int i = row + 1,j = col+1; i < chessConst.Dim && j< chessConst.Dim; i++,j++)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, j, ref destX, ref destY))
					return;
				else if (allcells[i, j].ps != null)
					break;
			}
			for (int i = row -1 , j = col - 1; i >= 0 && j >= 0; i--, j--)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, j, ref destX, ref destY))
					return;
				else if (allcells[i, j].ps != null)
					break;
			}

		}
		public void backwardDiagonalCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX, ref int destY,Cell[,] allcells)
		{
			for (int i = row + 1, j = col - 1; i < chessConst.Dim && j >= 0; i++, j--)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, j, ref destX, ref destY))
					return;
				else if (allcells[i, j].ps != null)
					break;
			}
			for (int i = row - 1, j = col + 1; i >= 0 && j < chessConst.Dim; i--, j++)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, i, j, ref destX, ref destY))
					return;
				else if (allcells[i, j].ps != null)
					break;
			}
		}
		public bool pawnCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX, ref int destY,Cell[,] allcells,bool highlight)
		{
			bool canProtect = false;
			if (this.co == MyColor.Black)
			{
				if (row == 1 && allcells[row + 2, col].ps == null && allcells[row +1, col].ps == null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 2, col, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) allcells[row + 2, col].BackColor = ColorTranslator.FromHtml(chessConst.doubleJump);
						}
							
					}
				}
				//Checking for usual step at pawn move
				if (row + 1 < chessConst.Dim && allcells[row + 1, col].ps == null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 1, col, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row + 1, col ]);
						}
							
					}
				}
				
				//Check for any diagonal kills
				if (row + 1 < chessConst.Dim && col + 1 < chessConst.Dim && allcells[row+1,col+1].ps != null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 1, col+1, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row + 1, col + 1]);
						}

						
					}
				}
				if (row + 1 < chessConst.Dim && col - 1 >= 0 && allcells[row + 1, col - 1].ps != null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 1, col - 1, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row + 1, col - 1]);
						}
						
					}
				}
				//Checking for en passant
				if (row == 4)
				{
					if (allcells[row, col + 1].doubleJump && allcells[row + 1, col + 1].ps == null)
					{
						if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row , col + 1, ref destX, ref destY))
						{
							if (destX != -1)
							{
								canProtect = true;
								if (highlight) allcells[row + 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
							}

						}
						
					}
					if (allcells[row, col - 1].doubleJump && allcells[row + 1, col - 1].ps == null)
					{
						if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row, col - 1, ref destX, ref destY))
						{
							if (destX != -1)
							{
								canProtect = true;
								if (highlight) allcells[row + 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
							}

						}
					}
				}
			}
			else
			{
				if (row == 6 && allcells[row - 2, col].ps == null && allcells[row - 1, col].ps == null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 2, col, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) allcells[row - 2, col].BackColor = ColorTranslator.FromHtml(chessConst.doubleJump);
						}
						
					}
				}
				//Checking for usual step at pawn move
				if (row - 1 >= 0 && allcells[row - 1, col].ps == null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 1, col, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row -1, col ]);
						}
					}
				}

				//Check for any diagonal kills
				if (row - 1 >= 0 && col + 1 < chessConst.Dim && allcells[row - 1, col + 1].ps != null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 1, col + 1, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row -1, col + 1]);
						}
						
					}
				}
				if (row - 1 >= 0 && col - 1 >= 0 && allcells[row - 1, col - 1].ps != null)
				{
					if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row -1, col - 1, ref destX, ref destY))
					{
						if (destX != -1)
						{
							canProtect = true;
							if (highlight) highlightRespCell(allcells[row -1, col - 1]);
						}
						
					}
				}
				//checking for en passant
				if(row == 3)
				{
					if (allcells[row, col + 1].doubleJump && allcells[row - 1, col + 1].ps == null)
					{
						if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row, col + 1, ref destX, ref destY))
						{
							if (destX != -1)
							{
								canProtect = true;
								if (highlight) allcells[row - 1, col + 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
							}

						}

					}
					if (allcells[row, col - 1].doubleJump && allcells[row - 1, col - 1].ps == null)
					{
						if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row, col - 1, ref destX, ref destY))
						{
							if (destX != -1)
							{
								canProtect = true;
								if (highlight) allcells[row - 1, col - 1].BackColor = ColorTranslator.FromHtml(chessConst.enPassant);
							}

						}
					}
				}
			}
			return canProtect;
		}
		public bool knightCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, ref int destX, ref int destY, Cell[,] allcells,bool highlight)
		{
			bool canProtect = false;
			if (row + 2 < chessConst.Dim && col + 1 < chessConst.Dim)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 2, col + 1, ref destX, ref destY))
				{
					if (destX != -1)
					{
						canProtect = true;
						if (highlight) highlightRespCell(allcells[row + 2, col + 1]);
					}
				}
				 

			}

			if (row + 2 < chessConst.Dim && col - 1 >= 0)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 2, col - 1, ref destX, ref destY))
				{
					if (destX != -1)
					{
						canProtect = true;
						if (highlight) highlightRespCell(allcells[row + 2, col - 1]);
					}
						
				}
			}

			if (row - 2 >= 0 && col + 1 < chessConst.Dim)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 2, col + 1, ref destX, ref destY))
				{
					if (destX != -1)
					{
						if (highlight) highlightRespCell(allcells[row - 2, col + 1]);
						canProtect = true;
					}
				}
			}

			if (row - 2 >= 0 && col - 1 >= 0)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 2, col - 1, ref destX, ref destY))
				{
					if (destX != -1)
					{
						if (highlight) highlightRespCell(allcells[row - 2, col - 1]);
						canProtect = true;
					}
				}
			}
			if (row + 1 < chessConst.Dim && col + 2 < chessConst.Dim)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 1, col + 2, ref destX, ref destY))
				{
					if (destX != -1)
					{
						if (highlight) highlightRespCell(allcells[row + 1, col + 2]);
						canProtect = true;
					}
				}
			}

			if (col + 2 < chessConst.Dim && row - 1 >= 0)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 1, col +2, ref destX, ref destY))
				{
					if (destX != -1)
					{
						if (highlight) highlightRespCell(allcells[row - 1, col + 2]);
						canProtect = true;
					}
				}
			}

			if (col - 2 >= 0 && row + 1 < chessConst.Dim)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row + 1, col - 2, ref destX, ref destY))
				{
					if (destX != -1)
					{
						if (highlight) highlightRespCell(allcells[row + 1, col - 2]);
						canProtect = true;
					}
				}
			}

			if (col - 2 >= 0 && row - 1 >= 0)
			{
				if (chkPointLineInter(chkSrcX, chkSrcY, chkDesX, chkDesY, row - 1, col - 2, ref destX, ref destY))
				{
					if (destX != -1)
					{
						canProtect = true;
						if (highlight) highlightRespCell(allcells[row - 1, col - 2]);
					}
				}
			}
			return canProtect;

		}
		public bool kingCheck(int row, int col, int chkSrcX, int chkSrcY, int chkDesX, int chkDesY, Cell[,] allcells, bool highlight)
		{
			bool canProtect = false;
			if (row + 1 < chessConst.Dim)
			{
				if ((int)allcells[row + 1, col].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row + 1, col]);
					canProtect = true;
				}
			}
			if (col + 1 < chessConst.Dim)
			{
				if ((int)allcells[row, col + 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row, col + 1]);
					canProtect = true;
				}
			}
			if (row - 1 >= 0)
			{
				if ((int)allcells[row - 1, col].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row - 1, col]);
					canProtect = true;
				}
			}
			if (col - 1 >= 0)
			{
				if ((int)allcells[row, col - 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row, col - 1]);
					canProtect = true;
				}
			}
			if (row + 1 < chessConst.Dim && col + 1 < chessConst.Dim)
			{
				if ((int)allcells[row + 1, col + 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row + 1, col + 1]);
					canProtect = true;
				}
			}
			if (row - 1 >= 0 && col - 1 >= 0)
			{
				if ((int)allcells[row - 1, col - 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row - 1, col - 1]);
					canProtect = true;
				}
			}
			if (row - 1 >= 0 && col + 1 < chessConst.Dim)
			{
				if ((int)allcells[row - 1, col + 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row - 1, col + 1]);
					canProtect = true;
				}
			}
			if (col - 1 >= 0 && row + 1 < chessConst.Dim)
			{
				if ((int)allcells[row + 1, col - 1].Tag == 2)
				{
					if (highlight) highlightRespCell(allcells[row + 1, col - 1]);
					canProtect = true;
				}
			}
			return canProtect;
		}
		
	}
}
