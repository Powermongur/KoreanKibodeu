
namespace KoreanKibodeu
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.helpButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.optionsButton = new System.Windows.Forms.Button();
            this.topBarlabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusLabel2 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBottomPanel = new System.Windows.Forms.Panel();
            this.commandsButton = new System.Windows.Forms.Button();
            this.translateButton = new System.Windows.Forms.Button();
            this.ttsButton = new System.Windows.Forms.Button();
            this.keysButton = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.helpButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.White;
            this.helpButton.Location = new System.Drawing.Point(969, 53);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(19, 23);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "?";
            this.mainToolTip.SetToolTip(this.helpButton, "Help");
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.AccessibleDescription = "";
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.minimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(1012, 8);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(19, 23);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.Text = "_";
            this.mainToolTip.SetToolTip(this.minimizeButton, "Minimize");
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizebutton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(1037, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTextBox.ForeColor = System.Drawing.Color.White;
            this.messageTextBox.Location = new System.Drawing.Point(12, 12);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(948, 31);
            this.messageTextBox.TabIndex = 1;
            this.messageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyDown);
            this.messageTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyUp);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.optionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.ForeColor = System.Drawing.Color.White;
            this.optionsButton.Location = new System.Drawing.Point(994, 53);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(19, 23);
            this.optionsButton.TabIndex = 100;
            this.optionsButton.TabStop = false;
            this.optionsButton.Text = "⚙️";
            this.mainToolTip.SetToolTip(this.optionsButton, "Options");
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // topBarlabel
            // 
            this.topBarlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.topBarlabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarlabel.Location = new System.Drawing.Point(0, 0);
            this.topBarlabel.Name = "topBarlabel";
            this.topBarlabel.Size = new System.Drawing.Size(1064, 7);
            this.topBarlabel.TabIndex = 8;
            this.topBarlabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.statusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.statusLabel.Location = new System.Drawing.Point(12, 48);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(20, 4, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(772, 23);
            this.statusLabel.TabIndex = 1001;
            this.statusLabel.Text = "💡Tip of the day: Press <space> after each syllable to convert";
            // 
            // statusLabel2
            // 
            this.statusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.statusLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.statusLabel2.Location = new System.Drawing.Point(784, 48);
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Padding = new System.Windows.Forms.Padding(20, 4, 0, 0);
            this.statusLabel2.Size = new System.Drawing.Size(176, 23);
            this.statusLabel2.TabIndex = 1001;
            this.statusLabel2.Text = "Mode: 한";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.Gray;
            this.nameLabel.Location = new System.Drawing.Point(977, 34);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(75, 16);
            this.nameLabel.TabIndex = 1002;
            this.nameLabel.Text = "IXI Kibodeu";
            // 
            // nameBottomPanel
            // 
            this.nameBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.nameBottomPanel.ForeColor = System.Drawing.Color.Gray;
            this.nameBottomPanel.Location = new System.Drawing.Point(977, 51);
            this.nameBottomPanel.Name = "nameBottomPanel";
            this.nameBottomPanel.Size = new System.Drawing.Size(75, 2);
            this.nameBottomPanel.TabIndex = 1003;
            // 
            // commandsButton
            // 
            this.commandsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.commandsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.commandsButton.FlatAppearance.BorderSize = 0;
            this.commandsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.commandsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandsButton.ForeColor = System.Drawing.Color.White;
            this.commandsButton.Location = new System.Drawing.Point(1019, 53);
            this.commandsButton.Name = "commandsButton";
            this.commandsButton.Size = new System.Drawing.Size(19, 23);
            this.commandsButton.TabIndex = 2;
            this.commandsButton.Text = "+";
            this.mainToolTip.SetToolTip(this.commandsButton, "Commands");
            this.commandsButton.UseVisualStyleBackColor = false;
            this.commandsButton.Click += new System.EventHandler(this.commandsButton_Click);
            // 
            // translateButton
            // 
            this.translateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.translateButton.FlatAppearance.BorderSize = 0;
            this.translateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translateButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.Location = new System.Drawing.Point(897, 12);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(24, 31);
            this.translateButton.TabIndex = 104;
            this.translateButton.Text = "T";
            this.mainToolTip.SetToolTip(this.translateButton, "Translate");
            this.translateButton.UseVisualStyleBackColor = false;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // ttsButton
            // 
            this.ttsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ttsButton.FlatAppearance.BorderSize = 0;
            this.ttsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ttsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttsButton.ForeColor = System.Drawing.Color.White;
            this.ttsButton.Location = new System.Drawing.Point(924, 12);
            this.ttsButton.Name = "ttsButton";
            this.ttsButton.Size = new System.Drawing.Size(29, 31);
            this.ttsButton.TabIndex = 105;
            this.ttsButton.Text = "🔊";
            this.mainToolTip.SetToolTip(this.ttsButton, "Text to Speech");
            this.ttsButton.UseVisualStyleBackColor = false;
            this.ttsButton.Click += new System.EventHandler(this.ttsButton_Click);
            // 
            // keysButton
            // 
            this.keysButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.keysButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.keysButton.FlatAppearance.BorderSize = 0;
            this.keysButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.keysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keysButton.ForeColor = System.Drawing.Color.White;
            this.keysButton.Location = new System.Drawing.Point(1037, 53);
            this.keysButton.Name = "keysButton";
            this.keysButton.Size = new System.Drawing.Size(19, 23);
            this.keysButton.TabIndex = 2;
            this.keysButton.Text = "🔑";
            this.mainToolTip.SetToolTip(this.keysButton, "Input keys");
            this.keysButton.UseVisualStyleBackColor = false;
            this.keysButton.Click += new System.EventHandler(this.keysButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1064, 82);
            this.Controls.Add(this.ttsButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.nameBottomPanel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.statusLabel2);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.topBarlabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.keysButton);
            this.Controls.Add(this.commandsButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.minimizeButton);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IXI Kibodeu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Label topBarlabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusLabel2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel nameBottomPanel;
        private System.Windows.Forms.Button commandsButton;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button ttsButton;
        private System.Windows.Forms.Button keysButton;
        private System.Windows.Forms.ToolTip mainToolTip;
    }
}

