using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

	public partial class Chess : Form
	{
		//All Necessary components of chess
		const int Dim = 8;
		Cell[,] cells = new Cell[Dim, Dim];
		Piece[,] allPieces = new Piece[Dim, Dim];
		Player[] allPlayers = new Player[2];
		//All component running during chess
		Player playerTurn;
		Cell Source;
		Cell wKingCell;
		Cell bKingCell;
		bool isCheck;
		int chkSrcX;
		int chkSrcY;
		int chkDesX;
		int chkDesY;
		Cell promotionPawnCell;
		public Chess()
		{
			InitializeComponent();
		}

		private void Chess_Load(object sender, EventArgs e)
		{
			invalidLabel.Hide();
			invalidLabel2.Hide();
			chessPanel.Hide();
		}
		//Reset the color of all cells
		private void refCellsColo()
		{
			for (int i = 0; i < chessConst.Dim; i++)
			{
				for (int j = 0; j < chessConst.Dim; j++)
				{
					Cell temp = (playerTurn.co == MyColor.Black) ? bKingCell : wKingCell;
					if (cells[i, j] != temp) cells[i, j].BackColor = (i + j) % 2 == 0 ? ColorTranslator.FromHtml(chessConst.white) : ColorTranslator.FromHtml(chessConst.black);
					if (cells[i, j].ps != null)
					{
						if (cells[i, j].ps.co == playerTurn.co)
							cells[i, j].doubleJump = false;
					}
					else
						cells[i, j].doubleJump = false;
				}
			}
		}
		//Reset the tag of all cells
		private void refCellsTag()
		{
			for (int i = 0; i < chessConst.Dim; i++)
			{
				for (int j = 0; j < chessConst.Dim; j++)
				{
					cells[i, j].Tag = 2;
				}
			}
		}
		private void promotePawn(string promotedTo)
		{
			int row = promotionPawnCell.ps.row;
			int col = promotionPawnCell.ps.col;

			//All the choises are inverted because by the time player chooses its promotion the turn 
			//is already changed by the changeturn function

			MyColor playerColor = (playerTurn.co == MyColor.White) ? MyColor.Black : MyColor.White;
			if (promotedTo == "rook")
			{
				allPieces[row, col] = null;
				string rookColor = (playerTurn.co == MyColor.Black) ? "w_rook" : "b_rook";
				allPieces[row, col] = new Rook(playerColor, rookColor);

			}
			else if (promotedTo == "bishop")
			{
				allPieces[row, col] = null;
				string bishopColor = (playerTurn.co == MyColor.Black) ? "w_bishop" : "b_bishop";
				allPieces[row, col] = new Bishop(playerColor, bishopColor);
			}
			else if (promotedTo == "knight")
			{
				allPieces[row, col] = null;
				string knightColor = (playerTurn.co == MyColor.Black) ? "w_knight" : "b_knight";
				allPieces[row, col] = new Knight(playerColor, knightColor);
			}
			else if (promotedTo == "queen")
			{
				allPieces[row, col] = null;
				string queenColor = (playerTurn.co == MyColor.Black) ? "w_queen" : "b_queen";
				allPieces[row, col] = new Queen(playerColor, queenColor);
			}
			allPieces[row, col].row = row;
			allPieces[row, col].col = col;
			promotionPawnCell.ps = allPieces[row, col];
			allPieces[row, col].Draw(promotionPawnCell);
			promotionTable.Hide();
			chessTablePanel.Show();
			selfChkBtn.Show();
		}
		private void assignTags(MyColor playerColor)
		{
			for (int i = 0; i < chessConst.Dim; i++)
			{
				for (int j = 0; j < chessConst.Dim; j++)
				{
					if (cells[i, j].ps != null && cells[i, j].ps.co == playerColor)
						cells[i, j].ps.checkFootPrint(i, j, cells);
				}
			}
		}
		private void Start()
		{
			//Default Values of the components
			chessTablePanel.Controls.Clear();
			chessTablePanel.Show();
			selfChkBtn.Show();
			Source = null;
			promotionTable.Hide();
			playerName.Text = allPlayers[0].name;
			isCheck = false;

			for (int r = 0; r < Dim; r++)
			{
				for (int c = 0; c < Dim; c++)
				{
					if (r == 1)
					{
						allPieces[r, c] = new Pawn(MyColor.Black, "b_pawn");
						allPieces[r, c].row = r;
						allPieces[r, c].col = c;
					}
					else if (r == 6)
					{
						allPieces[r, c] = new Pawn(MyColor.White, "w_pawn");
						allPieces[r, c].row = r;
						allPieces[r, c].col = c;
					}
					else if (r == 0)
					{
						if (c == 0 || c == 7)
							allPieces[r, c] = new Rook(MyColor.Black, "b_rook");
						else if (c == 1 || c == 6)
							allPieces[r, c] = new Knight(MyColor.Black, "b_knight");
						else if (c == 2 || c == 5)
							allPieces[r, c] = new Bishop(MyColor.Black, "b_bishop");
						else if (c == 3)
							allPieces[r, c] = new Queen(MyColor.Black, "b_queen");
						else if (c == 4)
							allPieces[r, c] = new King(MyColor.Black, "b_king");
						allPieces[r, c].row = r;
						allPieces[r, c].col = c;
					}
					else if (r == 7)
					{
						if (c == 0 || c == 7)
							allPieces[r, c] = new Rook(MyColor.White, "w_rook");
						else if (c == 1 || c == 6)
							allPieces[r, c] = new Knight(MyColor.White, "w_knight");
						else if (c == 2 || c == 5)
							allPieces[r, c] = new Bishop(MyColor.White, "w_bishop");
						else if (c == 3)
							allPieces[r, c] = new Queen(MyColor.White, "w_queen");
						else if (c == 4)
							allPieces[r, c] = new King(MyColor.White, "w_king");
						allPieces[r, c].row = r;
						allPieces[r, c].col = c;
					}
					else
						allPieces[r, c] = null;

					MyColor clr = (r + c) % 2 == 0 ? MyColor.White : MyColor.Black;
					cells[r, c] = new Cell(clr, r, c, chessTablePanel.Width, chessTablePanel.Height, Dim, allPieces[r, c]);
					if (allPieces[r, c] != null)
					{
						if (allPieces[r, c].name == "w_king")
							wKingCell = cells[r, c];
						if (allPieces[r, c].name == "b_king")
							bKingCell = cells[r, c];
					}

					cells[r, c].BackgroundImageLayout = ImageLayout.Stretch;
					cells[r, c].Margin = new Padding(0);
					cells[r, c].Click += new EventHandler(cellSelected);
					cells[r, c].Tag = 2;
					chessTablePanel.Controls.Add(cells[r, c]);
				}
			}
		}
		private bool isCheckFunc()
		{
			bool temp;
			if (playerTurn.co == MyColor.White)
			{
				if ((int)wKingCell.Tag != 2)
					temp = true;
				else
					temp = false;
			}
			else
			{
				if ((int)bKingCell.Tag != 2)
					temp = true;
				else
					temp = false;
			}
			return temp;
		}
		private bool isCheckMate()
		{
			for (int i = 0; i < chessConst.Dim; i++)
			{
				for (int j = 0; j < chessConst.Dim; j++)
				{
					if (cells[i, j].ps != null && cells[i, j].ps.co == playerTurn.co)
					{
						//Checking here if there is any piece which can protect the king without highlighting the area 
						if (cells[i, j].ps.highlightProAreas(i, j, chkSrcX, chkSrcY, chkDesX, chkDesY, cells, false))
							return false;
					}
				}
			}
			return true;
		}
		private void changeTurn()
		{
			refCellsTag();
			assignTags(playerTurn.co);
			if (playerTurn == allPlayers[0])
			{
				playerTurn = allPlayers[1];
				playerName.Text = allPlayers[1].name;
				isCheck = isCheckFunc();
				if (isCheck)
					bKingCell.BackColor = ColorTranslator.FromHtml(chessConst.kingCheck);
			}
			else
			{
				playerTurn = allPlayers[0];
				playerName.Text = allPlayers[0].name;
				isCheck = isCheckFunc();
				if (isCheck)
					wKingCell.BackColor = ColorTranslator.FromHtml(chessConst.kingCheck);
			}

		}
		private void exchangeCells(Cell selectedCell)
		{
			if (Source.ps.name == "b_rook" || Source.ps.name == "w_rook")
			{
				Rook temp = (Rook)Source.ps;
				temp.isMove = true;
			}
			else if (Source.ps.name == "b_king" || Source.ps.name == "w_king")
			{
				King temp = (King)Source.ps;
				temp.isMove = true;
			}
			Source.ps.remDraw(Source);
			if (Source.ps.name == "w_king")
				wKingCell = selectedCell;
			if (Source.ps.name == "b_king")
				bKingCell = selectedCell;
			selectedCell.ps = Source.ps;
			selectedCell.ps.Draw(selectedCell);
			Source.ps = null;
			Source = null;
			if ((selectedCell.ps.name == "b_pawn" && selectedCell.row == 7) || (selectedCell.ps.name == "w_pawn" && selectedCell.row == 0))
			{
				promotionTable.Show();
				chessTablePanel.Hide();
				selfChkBtn.Hide();
				promotionPawnCell = selectedCell;
			}
		}
		
		private void chkPath(Cell selCell)
		{
			if(selCell.ps.name == "w_knight" || selCell.ps.name == "b_knight")
			{
				chkSrcX = chkDesX = selCell.row;
				chkSrcY = chkDesY = selCell.col;
			}
			else
			{
				chkSrcX = selCell.row;
				chkSrcY = selCell.col;
				Cell temp = (playerTurn.co == MyColor.Black) ? bKingCell : wKingCell;
				chkDesX = temp.row;
				chkDesY = temp.col;

			}
		}
		private void enPassantExchange(Cell selectedCell)
		{
			cells[Source.row, selectedCell.col].ps.remDraw(cells[Source.row, selectedCell.col]);
			cells[Source.row, selectedCell.col].ps = null;
			exchangeCells(selectedCell);
		}
		bool checkOnMove(Cell selectedCell)
		{
			bool check = false;
			if (Source != null)
			{
				
				Piece temp = selectedCell.ps;
				selectedCell.ps = Source.ps;
				Source.ps = null;
				MyColor enemyColor = (playerTurn.co == MyColor.White) ? MyColor.Black : MyColor.White;
				refCellsTag();
				assignTags(enemyColor);
				if (isCheckFunc())
					check = true;
				Source.ps = selectedCell.ps;
				selectedCell.ps = temp;
				refCellsTag();
				assignTags(enemyColor);
			}
			
			return check;

		}
		private void runEnding()
		{
			Label winLabel = new Label()
			{
				AutoSize = true,
				Font = new Font("Microsoft Sans Serif", 13),
				TextAlign = ContentAlignment.MiddleCenter,
				Top = chessPanel.Height / 2,
				Left = chessPanel.Width / 2 - selfChkBtn.Width / 2,
				Anchor = AnchorStyles.None,
			};
			string name;
			if (playerTurn == allPlayers[0])
				name = allPlayers[1].name;
			else
				name = allPlayers[0].name;
			winLabel.Text = "CheckMate " + name + " Won";

			selfChkBtn.Hide();
			chessTablePanel.Hide();
			chessPanel.Controls.Add(winLabel);
		}
		private void castlingExchange(Cell castCell)
		{
			if(playerTurn.co == MyColor.White)
			{
				if(castCell.row == 7 && castCell.col == 6)
				{
					exchangeCells(castCell);
					Source = cells[7, 7];
					exchangeCells(cells[7, 5]);
				}
				else
				{
					exchangeCells(castCell);
					Source = cells[7, 0];
					exchangeCells(cells[7, 3]);
				}
			}
			else
			{
				if (castCell.row == 0 && castCell.col == 6)
				{
					exchangeCells(castCell);
					Source= cells[0, 7];
					exchangeCells(cells[0, 5]);
				}
				else
				{
					exchangeCells(castCell);
					Source= cells[0, 0];
					exchangeCells(cells[0, 3]);
				}
			}
		}
		private void cellSelected(object sender, EventArgs e)
		{

			Cell selectedCell = (Cell)sender;

			if (selectedCell.ps != null)
			{
				if(Source == selectedCell)
				{
					Source = null;
					refCellsColo(); 
				}
				else if (Source != null && selectedCell.BackColor == ColorTranslator.FromHtml(chessConst.canDie))
				{
					if (!checkOnMove(selectedCell))
					{
						exchangeCells(selectedCell);
						changeTurn();
						refCellsColo();
						if (isCheck)
						{
							chkPath(selectedCell);
							if (isCheckMate())
							{
								runEnding();
							}
						}
					}
					else
					{
						string message = "Queen Is Endangered";
						MessageBox.Show(message);
					}

				}
				else if(selectedCell.ps.co == playerTurn.co)
				{
					//checking if check can be protected
					
					if (isCheck)
					{
						refCellsColo();
						//Checking if it can protect the king from check 
						if(selectedCell.ps.highlightProAreas(selectedCell.row,selectedCell.col,chkSrcX,chkSrcY,chkDesX,chkDesY,cells,true))
							Source = selectedCell;
					}
					else
					{
						refCellsColo();
						Source = selectedCell;
						Source.ps.highlightMove(Source.row, Source.col, playerTurn.co, cells);	
					}
				}
				
			}
			else
			{
				if(!checkOnMove(selectedCell))
				{
					if (selectedCell.BackColor == ColorTranslator.FromHtml(chessConst.canWalk))
					{
						exchangeCells(selectedCell);
					}
					else if (selectedCell.BackColor == ColorTranslator.FromHtml(chessConst.castlingColor))
					{
						castlingExchange(selectedCell);
					}
					else if (selectedCell.BackColor == ColorTranslator.FromHtml(chessConst.enPassant))
					{
						enPassantExchange(selectedCell);
					}
					else if (selectedCell.BackColor == ColorTranslator.FromHtml(chessConst.doubleJump))
					{
						exchangeCells(selectedCell);
						selectedCell.doubleJump = true;
					}
					if (selectedCell.BackColor != ColorTranslator.FromHtml(chessConst.white) && selectedCell.BackColor != ColorTranslator.FromHtml(chessConst.black))
					{
						changeTurn();
						if (isCheck)
						{
							chkPath(selectedCell);
							if (isCheckMate())
							{
								runEnding();
							}
						}
					}
					Source = null;
					refCellsColo();
				}
				else
				{
					string message = "Queen Is Endangered";
					MessageBox.Show(message);
				}
				
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if(playerName1.Text.Length ==0 )
				invalidLabel.Show();
			else
				invalidLabel.Hide();
			if (playerName2.Text.Length == 0)
				invalidLabel2.Show();
			else
				invalidLabel2.Hide();
			if(playerName1.Text.Length != 0 && playerName2.Text.Length != 0)
			{
				namesPanel.Hide();
				chessPanel.Show();
				allPlayers[0] = new Player(MyColor.White, playerName1.Text);
				allPlayers[1] = new Player(MyColor.Black, playerName2.Text);
				Start();
				playerTurn = allPlayers[0];
				refCellsTag();
				assignTags(MyColor.Black);
			}

		}

		
		private void exitBtn_Click_1(object sender, EventArgs e)
		{
			playerName1.Text = "";
			playerName2.Text = "";
			chessPanel.Hide();
			namesPanel.Show();
		}

		private void selfChkBtn_Click(object sender, EventArgs e)
		{
			Label winLabel = new Label()
			{
				AutoSize = true,
				Font = new Font("Microsoft Sans Serif", 20),
				TextAlign = ContentAlignment.MiddleCenter,
				Top = chessPanel.Height / 2,
				Left = chessPanel.Width / 2 - selfChkBtn.Width/2,
				Anchor = AnchorStyles.None,
			};
			string name;
			if (playerTurn == allPlayers[0])
				name = allPlayers[1].name;
			else
				name = allPlayers[0].name;
			winLabel.Text = name + "\nWon";
			selfChkBtn.Hide();
			chessTablePanel.Hide();
			chessPanel.Controls.Add(winLabel);

		}

		private void rookPromotion_Click(object sender, EventArgs e)
		{
			promotePawn("rook");
		}

		private void bishopPromotion_Click(object sender, EventArgs e)
		{
			promotePawn("bishop");
		}

		private void knightPromotion_Click(object sender, EventArgs e)
		{
			promotePawn("knight");
		}

		private void queenPromotion_Click(object sender, EventArgs e)
		{
			promotePawn("queen");
		}
	}
}
