
namespace PaintApp
{
    partial class PaintForm
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
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.Panel();
            this.ColourPalette = new System.Windows.Forms.Panel();
            this.BlackBox = new System.Windows.Forms.PictureBox();
            this.WhiteBox = new System.Windows.Forms.PictureBox();
            this.PinkBox = new System.Windows.Forms.PictureBox();
            this.PurpleBox = new System.Windows.Forms.PictureBox();
            this.BlueBox = new System.Windows.Forms.PictureBox();
            this.GreenBox = new System.Windows.Forms.PictureBox();
            this.YellowBox = new System.Windows.Forms.PictureBox();
            this.OrangeBox = new System.Windows.Forms.PictureBox();
            this.RedBox = new System.Windows.Forms.PictureBox();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.ServerWindow = new System.Windows.Forms.RichTextBox();
            this.ServerListUnderline = new System.Windows.Forms.Panel();
            this.ServerListLabel = new System.Windows.Forms.Label();
            this.PlayerListUnderline = new System.Windows.Forms.Panel();
            this.PlayerListLabel = new System.Windows.Forms.Label();
            this.PlayerList = new System.Windows.Forms.ListBox();
            this.AdminMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DisablePaintingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearCanvasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.SpawnClientButton = new System.Windows.Forms.Button();
            this.ClearGlobalButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UsernameButton = new System.Windows.Forms.Button();
            this.UsernameUnderline = new System.Windows.Forms.Panel();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.ClearLocalButton = new System.Windows.Forms.Button();
            this.Canvas.SuspendLayout();
            this.ColourPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBox)).BeginInit();
            this.LeftPanel.SuspendLayout();
            this.AdminMenu.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.Gainsboro;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Controls.Add(this.ColourPalette);
            this.Canvas.Enabled = false;
            this.Canvas.Location = new System.Drawing.Point(120, 48);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(685, 411);
            this.Canvas.TabIndex = 8;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // ColourPalette
            // 
            this.ColourPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ColourPalette.BackColor = System.Drawing.Color.Silver;
            this.ColourPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColourPalette.Controls.Add(this.BlackBox);
            this.ColourPalette.Controls.Add(this.WhiteBox);
            this.ColourPalette.Controls.Add(this.PinkBox);
            this.ColourPalette.Controls.Add(this.PurpleBox);
            this.ColourPalette.Controls.Add(this.BlueBox);
            this.ColourPalette.Controls.Add(this.GreenBox);
            this.ColourPalette.Controls.Add(this.YellowBox);
            this.ColourPalette.Controls.Add(this.OrangeBox);
            this.ColourPalette.Controls.Add(this.RedBox);
            this.ColourPalette.Location = new System.Drawing.Point(388, 12);
            this.ColourPalette.Name = "ColourPalette";
            this.ColourPalette.Size = new System.Drawing.Size(283, 32);
            this.ColourPalette.TabIndex = 0;
            // 
            // BlackBox
            // 
            this.BlackBox.BackColor = System.Drawing.Color.Black;
            this.BlackBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlackBox.Location = new System.Drawing.Point(253, 3);
            this.BlackBox.Name = "BlackBox";
            this.BlackBox.Size = new System.Drawing.Size(25, 24);
            this.BlackBox.TabIndex = 8;
            this.BlackBox.TabStop = false;
            this.BlackBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.BlackBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.BlackBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // WhiteBox
            // 
            this.WhiteBox.BackColor = System.Drawing.Color.White;
            this.WhiteBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WhiteBox.Location = new System.Drawing.Point(222, 3);
            this.WhiteBox.Name = "WhiteBox";
            this.WhiteBox.Size = new System.Drawing.Size(25, 24);
            this.WhiteBox.TabIndex = 7;
            this.WhiteBox.TabStop = false;
            this.WhiteBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.WhiteBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.WhiteBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // PinkBox
            // 
            this.PinkBox.BackColor = System.Drawing.Color.Fuchsia;
            this.PinkBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PinkBox.Location = new System.Drawing.Point(191, 3);
            this.PinkBox.Name = "PinkBox";
            this.PinkBox.Size = new System.Drawing.Size(25, 24);
            this.PinkBox.TabIndex = 6;
            this.PinkBox.TabStop = false;
            this.PinkBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.PinkBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.PinkBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // PurpleBox
            // 
            this.PurpleBox.BackColor = System.Drawing.Color.Purple;
            this.PurpleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PurpleBox.Location = new System.Drawing.Point(160, 3);
            this.PurpleBox.Name = "PurpleBox";
            this.PurpleBox.Size = new System.Drawing.Size(25, 24);
            this.PurpleBox.TabIndex = 5;
            this.PurpleBox.TabStop = false;
            this.PurpleBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.PurpleBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.PurpleBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // BlueBox
            // 
            this.BlueBox.BackColor = System.Drawing.Color.Aqua;
            this.BlueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlueBox.Location = new System.Drawing.Point(129, 3);
            this.BlueBox.Name = "BlueBox";
            this.BlueBox.Size = new System.Drawing.Size(25, 24);
            this.BlueBox.TabIndex = 4;
            this.BlueBox.TabStop = false;
            this.BlueBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.BlueBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.BlueBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // GreenBox
            // 
            this.GreenBox.BackColor = System.Drawing.Color.Lime;
            this.GreenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GreenBox.Location = new System.Drawing.Point(98, 3);
            this.GreenBox.Name = "GreenBox";
            this.GreenBox.Size = new System.Drawing.Size(25, 24);
            this.GreenBox.TabIndex = 3;
            this.GreenBox.TabStop = false;
            this.GreenBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.GreenBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.GreenBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // YellowBox
            // 
            this.YellowBox.BackColor = System.Drawing.Color.Yellow;
            this.YellowBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YellowBox.Location = new System.Drawing.Point(67, 3);
            this.YellowBox.Name = "YellowBox";
            this.YellowBox.Size = new System.Drawing.Size(25, 24);
            this.YellowBox.TabIndex = 2;
            this.YellowBox.TabStop = false;
            this.YellowBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.YellowBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.YellowBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // OrangeBox
            // 
            this.OrangeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.OrangeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrangeBox.Location = new System.Drawing.Point(36, 3);
            this.OrangeBox.Name = "OrangeBox";
            this.OrangeBox.Size = new System.Drawing.Size(25, 24);
            this.OrangeBox.TabIndex = 1;
            this.OrangeBox.TabStop = false;
            this.OrangeBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.OrangeBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.OrangeBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // RedBox
            // 
            this.RedBox.BackColor = System.Drawing.Color.Red;
            this.RedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedBox.Location = new System.Drawing.Point(5, 3);
            this.RedBox.Name = "RedBox";
            this.RedBox.Size = new System.Drawing.Size(25, 24);
            this.RedBox.TabIndex = 0;
            this.RedBox.TabStop = false;
            this.RedBox.Click += new System.EventHandler(this.ColourBox_Click);
            this.RedBox.MouseEnter += new System.EventHandler(this.ColourBox_MouseEnter);
            this.RedBox.MouseLeave += new System.EventHandler(this.ColourBox_MouseLeave);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Controls.Add(this.ServerWindow);
            this.LeftPanel.Controls.Add(this.ServerListUnderline);
            this.LeftPanel.Controls.Add(this.ServerListLabel);
            this.LeftPanel.Controls.Add(this.PlayerListUnderline);
            this.LeftPanel.Controls.Add(this.PlayerListLabel);
            this.LeftPanel.Controls.Add(this.PlayerList);
            this.LeftPanel.Location = new System.Drawing.Point(-9, 48);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(131, 411);
            this.LeftPanel.TabIndex = 1;
            // 
            // ServerWindow
            // 
            this.ServerWindow.BackColor = System.Drawing.Color.White;
            this.ServerWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerWindow.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerWindow.Location = new System.Drawing.Point(14, 228);
            this.ServerWindow.Name = "ServerWindow";
            this.ServerWindow.ReadOnly = true;
            this.ServerWindow.Size = new System.Drawing.Size(110, 167);
            this.ServerWindow.TabIndex = 8;
            this.ServerWindow.Text = "";
            // 
            // ServerListUnderline
            // 
            this.ServerListUnderline.BackColor = System.Drawing.Color.Purple;
            this.ServerListUnderline.Location = new System.Drawing.Point(16, 221);
            this.ServerListUnderline.Name = "ServerListUnderline";
            this.ServerListUnderline.Size = new System.Drawing.Size(96, 3);
            this.ServerListUnderline.TabIndex = 5;
            // 
            // ServerListLabel
            // 
            this.ServerListLabel.AutoSize = true;
            this.ServerListLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerListLabel.Location = new System.Drawing.Point(14, 204);
            this.ServerListLabel.Name = "ServerListLabel";
            this.ServerListLabel.Size = new System.Drawing.Size(101, 15);
            this.ServerListLabel.TabIndex = 4;
            this.ServerListLabel.Text = "Server Responses";
            // 
            // PlayerListUnderline
            // 
            this.PlayerListUnderline.BackColor = System.Drawing.Color.Lime;
            this.PlayerListUnderline.Location = new System.Drawing.Point(16, 22);
            this.PlayerListUnderline.Name = "PlayerListUnderline";
            this.PlayerListUnderline.Size = new System.Drawing.Size(70, 3);
            this.PlayerListUnderline.TabIndex = 2;
            // 
            // PlayerListLabel
            // 
            this.PlayerListLabel.AutoSize = true;
            this.PlayerListLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerListLabel.Location = new System.Drawing.Point(14, 5);
            this.PlayerListLabel.Name = "PlayerListLabel";
            this.PlayerListLabel.Size = new System.Drawing.Size(75, 15);
            this.PlayerListLabel.TabIndex = 1;
            this.PlayerListLabel.Text = "Now Playing";
            // 
            // PlayerList
            // 
            this.PlayerList.ContextMenuStrip = this.AdminMenu;
            this.PlayerList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.ItemHeight = 15;
            this.PlayerList.Location = new System.Drawing.Point(14, 29);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(110, 154);
            this.PlayerList.TabIndex = 7;
            // 
            // AdminMenu
            // 
            this.AdminMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisablePaintingItem,
            this.ClearCanvasItem});
            this.AdminMenu.Name = "AdminMenu";
            this.AdminMenu.Size = new System.Drawing.Size(160, 48);
            this.AdminMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AdminMenu_Opening);
            // 
            // DisablePaintingItem
            // 
            this.DisablePaintingItem.Name = "DisablePaintingItem";
            this.DisablePaintingItem.Size = new System.Drawing.Size(159, 22);
            this.DisablePaintingItem.Text = "Disable Painting";
            this.DisablePaintingItem.Visible = false;
            this.DisablePaintingItem.Click += new System.EventHandler(this.DisablePaintingItem_Click);
            // 
            // ClearCanvasItem
            // 
            this.ClearCanvasItem.Name = "ClearCanvasItem";
            this.ClearCanvasItem.Size = new System.Drawing.Size(159, 22);
            this.ClearCanvasItem.Text = "Clear Canvas";
            this.ClearCanvasItem.Visible = false;
            this.ClearCanvasItem.Click += new System.EventHandler(this.ClearCanvasItem_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.SpawnClientButton);
            this.TopPanel.Controls.Add(this.ClearGlobalButton);
            this.TopPanel.Controls.Add(this.DisconnectButton);
            this.TopPanel.Controls.Add(this.ConnectButton);
            this.TopPanel.Controls.Add(this.UsernameButton);
            this.TopPanel.Controls.Add(this.UsernameUnderline);
            this.TopPanel.Controls.Add(this.UsernameTextBox);
            this.TopPanel.Controls.Add(this.ClearLocalButton);
            this.TopPanel.Location = new System.Drawing.Point(-9, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(818, 51);
            this.TopPanel.TabIndex = 1;
            // 
            // SpawnClientButton
            // 
            this.SpawnClientButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SpawnClientButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SpawnClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SpawnClientButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpawnClientButton.ForeColor = System.Drawing.Color.MediumPurple;
            this.SpawnClientButton.Location = new System.Drawing.Point(420, 13);
            this.SpawnClientButton.Name = "SpawnClientButton";
            this.SpawnClientButton.Size = new System.Drawing.Size(91, 23);
            this.SpawnClientButton.TabIndex = 4;
            this.SpawnClientButton.Text = "Spawn Client";
            this.SpawnClientButton.UseVisualStyleBackColor = false;
            this.SpawnClientButton.Visible = false;
            this.SpawnClientButton.Click += new System.EventHandler(this.SpawnClientButton_Click);
            // 
            // ClearGlobalButton
            // 
            this.ClearGlobalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClearGlobalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClearGlobalButton.Enabled = false;
            this.ClearGlobalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearGlobalButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearGlobalButton.ForeColor = System.Drawing.Color.Black;
            this.ClearGlobalButton.Location = new System.Drawing.Point(517, 13);
            this.ClearGlobalButton.Name = "ClearGlobalButton";
            this.ClearGlobalButton.Size = new System.Drawing.Size(138, 23);
            this.ClearGlobalButton.TabIndex = 5;
            this.ClearGlobalButton.Text = "Clear Canvas (Global)";
            this.ClearGlobalButton.UseVisualStyleBackColor = false;
            this.ClearGlobalButton.Visible = false;
            this.ClearGlobalButton.Click += new System.EventHandler(this.ClearGlobalButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DisconnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DisconnectButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectButton.ForeColor = System.Drawing.Color.Red;
            this.DisconnectButton.Location = new System.Drawing.Point(323, 13);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(91, 23);
            this.DisconnectButton.TabIndex = 3;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConnectButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.ForeColor = System.Drawing.Color.Lime;
            this.ConnectButton.Location = new System.Drawing.Point(226, 13);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(91, 23);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UsernameButton
            // 
            this.UsernameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.UsernameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UsernameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UsernameButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameButton.ForeColor = System.Drawing.Color.Black;
            this.UsernameButton.Location = new System.Drawing.Point(128, 13);
            this.UsernameButton.Name = "UsernameButton";
            this.UsernameButton.Size = new System.Drawing.Size(91, 23);
            this.UsernameButton.TabIndex = 1;
            this.UsernameButton.Text = "Set Username";
            this.UsernameButton.UseVisualStyleBackColor = false;
            this.UsernameButton.Click += new System.EventHandler(this.UsernameButton_Click);
            // 
            // UsernameUnderline
            // 
            this.UsernameUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.UsernameUnderline.Location = new System.Drawing.Point(16, 33);
            this.UsernameUnderline.Name = "UsernameUnderline";
            this.UsernameUnderline.Size = new System.Drawing.Size(95, 3);
            this.UsernameUnderline.TabIndex = 3;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.Location = new System.Drawing.Point(17, 13);
            this.UsernameTextBox.MaxLength = 10;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(113, 14);
            this.UsernameTextBox.TabIndex = 0;
            this.UsernameTextBox.Text = "Username...";
            this.UsernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextBox_KeyDown);
            // 
            // ClearLocalButton
            // 
            this.ClearLocalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClearLocalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClearLocalButton.Enabled = false;
            this.ClearLocalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearLocalButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLocalButton.ForeColor = System.Drawing.Color.Black;
            this.ClearLocalButton.Location = new System.Drawing.Point(662, 13);
            this.ClearLocalButton.Name = "ClearLocalButton";
            this.ClearLocalButton.Size = new System.Drawing.Size(138, 23);
            this.ClearLocalButton.TabIndex = 6;
            this.ClearLocalButton.Text = "Clear Canvas";
            this.ClearLocalButton.UseVisualStyleBackColor = false;
            this.ClearLocalButton.Click += new System.EventHandler(this.ClearLocalButton_Click);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.Canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PaintForm";
            this.Text = "Paint Application";
            this.Canvas.ResumeLayout(false);
            this.ColourPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBox)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.AdminMenu.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ColourPalette;
        private System.Windows.Forms.PictureBox BlackBox;
        private System.Windows.Forms.PictureBox WhiteBox;
        private System.Windows.Forms.PictureBox PinkBox;
        private System.Windows.Forms.PictureBox PurpleBox;
        private System.Windows.Forms.PictureBox BlueBox;
        private System.Windows.Forms.PictureBox GreenBox;
        private System.Windows.Forms.PictureBox YellowBox;
        private System.Windows.Forms.PictureBox OrangeBox;
        private System.Windows.Forms.PictureBox RedBox;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button ClearLocalButton;
        private System.Windows.Forms.Panel PlayerListUnderline;
        private System.Windows.Forms.Label PlayerListLabel;
        private System.Windows.Forms.ListBox PlayerList;
        private System.Windows.Forms.Label ServerListLabel;
        private System.Windows.Forms.Panel ServerListUnderline;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button UsernameButton;
        private System.Windows.Forms.Panel UsernameUnderline;
        private System.Windows.Forms.Button ClearGlobalButton;
        private System.Windows.Forms.RichTextBox ServerWindow;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.ContextMenuStrip AdminMenu;
        private System.Windows.Forms.ToolStripMenuItem DisablePaintingItem;
        private System.Windows.Forms.ToolStripMenuItem ClearCanvasItem;
        private System.Windows.Forms.Button SpawnClientButton;
    }
}

