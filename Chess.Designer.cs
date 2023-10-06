
namespace WindowsFormsApp1
{
	partial class Chess
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.startBtn = new System.Windows.Forms.Button();
			this.namesPanel = new System.Windows.Forms.Panel();
			this.invalidLabel2 = new System.Windows.Forms.Label();
			this.invalidLabel = new System.Windows.Forms.Label();
			this.nameLabel2 = new System.Windows.Forms.Label();
			this.playerName1 = new System.Windows.Forms.TextBox();
			this.nameLabel1 = new System.Windows.Forms.Label();
			this.playerName2 = new System.Windows.Forms.TextBox();
			this.chessPanel = new System.Windows.Forms.Panel();
			this.promotionTable = new System.Windows.Forms.TableLayoutPanel();
			this.rookPromotion = new System.Windows.Forms.Button();
			this.bishopPromotion = new System.Windows.Forms.Button();
			this.knightPromotion = new System.Windows.Forms.Button();
			this.queenPromotion = new System.Windows.Forms.Button();
			this.selfChkBtn = new System.Windows.Forms.Button();
			this.playerName = new System.Windows.Forms.Label();
			this.turnLabel = new System.Windows.Forms.Label();
			this.exitBtn = new System.Windows.Forms.Button();
			this.chessTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.namesPanel.SuspendLayout();
			this.chessPanel.SuspendLayout();
			this.promotionTable.SuspendLayout();
			this.SuspendLayout();
			// 
			// startBtn
			// 
			this.startBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
			this.startBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.startBtn.Location = new System.Drawing.Point(303, 76);
			this.startBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(161, 44);
			this.startBtn.TabIndex = 0;
			this.startBtn.Text = "Start The Game";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// namesPanel
			// 
			this.namesPanel.Controls.Add(this.invalidLabel2);
			this.namesPanel.Controls.Add(this.startBtn);
			this.namesPanel.Controls.Add(this.invalidLabel);
			this.namesPanel.Controls.Add(this.nameLabel2);
			this.namesPanel.Controls.Add(this.playerName1);
			this.namesPanel.Controls.Add(this.nameLabel1);
			this.namesPanel.Controls.Add(this.playerName2);
			this.namesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.namesPanel.Location = new System.Drawing.Point(0, 0);
			this.namesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.namesPanel.Name = "namesPanel";
			this.namesPanel.Size = new System.Drawing.Size(795, 720);
			this.namesPanel.TabIndex = 5;
			// 
			// invalidLabel2
			// 
			this.invalidLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.invalidLabel2.AutoSize = true;
			this.invalidLabel2.Location = new System.Drawing.Point(413, 318);
			this.invalidLabel2.Name = "invalidLabel2";
			this.invalidLabel2.Size = new System.Drawing.Size(81, 17);
			this.invalidLabel2.TabIndex = 10;
			this.invalidLabel2.Text = "Field Empty";
			// 
			// invalidLabel
			// 
			this.invalidLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.invalidLabel.AutoSize = true;
			this.invalidLabel.Location = new System.Drawing.Point(413, 254);
			this.invalidLabel.Name = "invalidLabel";
			this.invalidLabel.Size = new System.Drawing.Size(81, 17);
			this.invalidLabel.TabIndex = 9;
			this.invalidLabel.Text = "Field Empty";
			// 
			// nameLabel2
			// 
			this.nameLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.nameLabel2.AutoSize = true;
			this.nameLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.nameLabel2.Location = new System.Drawing.Point(195, 287);
			this.nameLabel2.Name = "nameLabel2";
			this.nameLabel2.Size = new System.Drawing.Size(197, 25);
			this.nameLabel2.TabIndex = 8;
			this.nameLabel2.Text = "Second Player Name";
			// 
			// playerName1
			// 
			this.playerName1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.playerName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.playerName1.Location = new System.Drawing.Point(407, 220);
			this.playerName1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.playerName1.Name = "playerName1";
			this.playerName1.Size = new System.Drawing.Size(155, 30);
			this.playerName1.TabIndex = 5;
			// 
			// nameLabel1
			// 
			this.nameLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.nameLabel1.AutoSize = true;
			this.nameLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.nameLabel1.Location = new System.Drawing.Point(195, 223);
			this.nameLabel1.Name = "nameLabel1";
			this.nameLabel1.Size = new System.Drawing.Size(166, 25);
			this.nameLabel1.TabIndex = 6;
			this.nameLabel1.Text = "First Player Name";
			// 
			// playerName2
			// 
			this.playerName2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.playerName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.playerName2.Location = new System.Drawing.Point(407, 284);
			this.playerName2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.playerName2.Name = "playerName2";
			this.playerName2.Size = new System.Drawing.Size(155, 30);
			this.playerName2.TabIndex = 7;
			// 
			// chessPanel
			// 
			this.chessPanel.Controls.Add(this.promotionTable);
			this.chessPanel.Controls.Add(this.selfChkBtn);
			this.chessPanel.Controls.Add(this.playerName);
			this.chessPanel.Controls.Add(this.turnLabel);
			this.chessPanel.Controls.Add(this.exitBtn);
			this.chessPanel.Controls.Add(this.chessTablePanel);
			this.chessPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chessPanel.Location = new System.Drawing.Point(0, 0);
			this.chessPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chessPanel.Name = "chessPanel";
			this.chessPanel.Size = new System.Drawing.Size(795, 720);
			this.chessPanel.TabIndex = 6;
			// 
			// promotionTable
			// 
			this.promotionTable.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.promotionTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.promotionTable.ColumnCount = 4;
			this.promotionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.promotionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.promotionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.promotionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.promotionTable.Controls.Add(this.rookPromotion, 0, 0);
			this.promotionTable.Controls.Add(this.bishopPromotion, 1, 0);
			this.promotionTable.Controls.Add(this.knightPromotion, 2, 0);
			this.promotionTable.Controls.Add(this.queenPromotion, 3, 0);
			this.promotionTable.Location = new System.Drawing.Point(175, 302);
			this.promotionTable.Name = "promotionTable";
			this.promotionTable.RowCount = 1;
			this.promotionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.promotionTable.Size = new System.Drawing.Size(428, 112);
			this.promotionTable.TabIndex = 0;
			// 
			// rookPromotion
			// 
			this.rookPromotion.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_rook;
			this.rookPromotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.rookPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rookPromotion.Location = new System.Drawing.Point(3, 3);
			this.rookPromotion.Name = "rookPromotion";
			this.rookPromotion.Size = new System.Drawing.Size(101, 106);
			this.rookPromotion.TabIndex = 0;
			this.rookPromotion.UseVisualStyleBackColor = true;
			this.rookPromotion.Click += new System.EventHandler(this.rookPromotion_Click);
			// 
			// bishopPromotion
			// 
			this.bishopPromotion.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_bishop;
			this.bishopPromotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.bishopPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bishopPromotion.Location = new System.Drawing.Point(110, 3);
			this.bishopPromotion.Name = "bishopPromotion";
			this.bishopPromotion.Size = new System.Drawing.Size(101, 106);
			this.bishopPromotion.TabIndex = 1;
			this.bishopPromotion.UseVisualStyleBackColor = true;
			this.bishopPromotion.Click += new System.EventHandler(this.bishopPromotion_Click);
			// 
			// knightPromotion
			// 
			this.knightPromotion.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.b_knight;
			this.knightPromotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.knightPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.knightPromotion.Location = new System.Drawing.Point(217, 3);
			this.knightPromotion.Name = "knightPromotion";
			this.knightPromotion.Size = new System.Drawing.Size(101, 106);
			this.knightPromotion.TabIndex = 2;
			this.knightPromotion.UseVisualStyleBackColor = true;
			this.knightPromotion.Click += new System.EventHandler(this.knightPromotion_Click);
			// 
			// queenPromotion
			// 
			this.queenPromotion.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.w_queen;
			this.queenPromotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.queenPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.queenPromotion.Location = new System.Drawing.Point(324, 3);
			this.queenPromotion.Name = "queenPromotion";
			this.queenPromotion.Size = new System.Drawing.Size(101, 106);
			this.queenPromotion.TabIndex = 3;
			this.queenPromotion.UseVisualStyleBackColor = true;
			this.queenPromotion.Click += new System.EventHandler(this.queenPromotion_Click);
			// 
			// selfChkBtn
			// 
			this.selfChkBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.selfChkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.selfChkBtn.Location = new System.Drawing.Point(329, 10);
			this.selfChkBtn.Margin = new System.Windows.Forms.Padding(4);
			this.selfChkBtn.Name = "selfChkBtn";
			this.selfChkBtn.Size = new System.Drawing.Size(152, 38);
			this.selfChkBtn.TabIndex = 4;
			this.selfChkBtn.Text = "Self Check";
			this.selfChkBtn.UseVisualStyleBackColor = true;
			this.selfChkBtn.Click += new System.EventHandler(this.selfChkBtn_Click);
			// 
			// playerName
			// 
			this.playerName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.playerName.AutoSize = true;
			this.playerName.Location = new System.Drawing.Point(172, 57);
			this.playerName.Margin = new System.Windows.Forms.Padding(0);
			this.playerName.Name = "playerName";
			this.playerName.Size = new System.Drawing.Size(43, 17);
			this.playerName.TabIndex = 3;
			this.playerName.Text = "name";
			this.playerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// turnLabel
			// 
			this.turnLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.turnLabel.AutoSize = true;
			this.turnLabel.Location = new System.Drawing.Point(84, 57);
			this.turnLabel.Name = "turnLabel";
			this.turnLabel.Size = new System.Drawing.Size(86, 17);
			this.turnLabel.TabIndex = 2;
			this.turnLabel.Text = "Player Turn:";
			// 
			// exitBtn
			// 
			this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exitBtn.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.x_sign;
			this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.exitBtn.Location = new System.Drawing.Point(748, 14);
			this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(33, 32);
			this.exitBtn.TabIndex = 1;
			this.exitBtn.UseVisualStyleBackColor = true;
			this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click_1);
			// 
			// chessTablePanel
			// 
			this.chessTablePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chessTablePanel.ColumnCount = 8;
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.Location = new System.Drawing.Point(88, 87);
			this.chessTablePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chessTablePanel.Name = "chessTablePanel";
			this.chessTablePanel.RowCount = 8;
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.chessTablePanel.Size = new System.Drawing.Size(607, 597);
			this.chessTablePanel.TabIndex = 0;
			// 
			// Chess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(795, 720);
			this.Controls.Add(this.chessPanel);
			this.Controls.Add(this.namesPanel);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Chess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chess";
			this.Load += new System.EventHandler(this.Chess_Load);
			this.namesPanel.ResumeLayout(false);
			this.namesPanel.PerformLayout();
			this.chessPanel.ResumeLayout(false);
			this.chessPanel.PerformLayout();
			this.promotionTable.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Panel namesPanel;
		private System.Windows.Forms.Label nameLabel2;
		private System.Windows.Forms.TextBox playerName1;
		private System.Windows.Forms.Label nameLabel1;
		private System.Windows.Forms.TextBox playerName2;
		private System.Windows.Forms.Label invalidLabel;
		private System.Windows.Forms.Label invalidLabel2;
		private System.Windows.Forms.Panel chessPanel;
		private System.Windows.Forms.Button exitBtn;
		private System.Windows.Forms.TableLayoutPanel chessTablePanel;
		private System.Windows.Forms.Label turnLabel;
		private System.Windows.Forms.Label playerName;
		private System.Windows.Forms.Button selfChkBtn;
		private System.Windows.Forms.TableLayoutPanel promotionTable;
		private System.Windows.Forms.Button rookPromotion;
		private System.Windows.Forms.Button bishopPromotion;
		private System.Windows.Forms.Button knightPromotion;
		private System.Windows.Forms.Button queenPromotion;
	}
}

