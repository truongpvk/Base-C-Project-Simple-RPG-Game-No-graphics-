namespace The_RPG_Based
{
    partial class SuperAdventure
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lbHitPoint = new System.Windows.Forms.Label();
            lbGold = new System.Windows.Forms.Label();
            lbExperience = new System.Windows.Forms.Label();
            lbLevel = new System.Windows.Forms.Label();
            lbSelectAction = new System.Windows.Forms.Label();
            cboWeapon = new System.Windows.Forms.ComboBox();
            cboPotions = new System.Windows.Forms.ComboBox();
            btnUseWeapon = new System.Windows.Forms.Button();
            btnUsePotion = new System.Windows.Forms.Button();
            btnNorth = new System.Windows.Forms.Button();
            btnEast = new System.Windows.Forms.Button();
            btnSouth = new System.Windows.Forms.Button();
            btnWest = new System.Windows.Forms.Button();
            rtbLocation = new System.Windows.Forms.RichTextBox();
            rtbMessage = new System.Windows.Forms.RichTextBox();
            dgvInventory = new System.Windows.Forms.DataGridView();
            dgvQuests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(18, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "Hit Point: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(18, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Gold: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(18, 92);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(102, 20);
            label3.TabIndex = 2;
            label3.Text = "Experience: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(18, 125);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 20);
            label4.TabIndex = 3;
            label4.Text = "Level: ";
            // 
            // lbHitPoint
            // 
            lbHitPoint.AutoSize = true;
            lbHitPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbHitPoint.Location = new System.Drawing.Point(124, 26);
            lbHitPoint.Name = "lbHitPoint";
            lbHitPoint.Size = new System.Drawing.Size(0, 20);
            lbHitPoint.TabIndex = 4;
            // 
            // lbGold
            // 
            lbGold.AutoSize = true;
            lbGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbGold.Location = new System.Drawing.Point(124, 59);
            lbGold.Name = "lbGold";
            lbGold.Size = new System.Drawing.Size(0, 20);
            lbGold.TabIndex = 5;
            // 
            // lbExperience
            // 
            lbExperience.AutoSize = true;
            lbExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbExperience.Location = new System.Drawing.Point(124, 94);
            lbExperience.Name = "lbExperience";
            lbExperience.Size = new System.Drawing.Size(0, 20);
            lbExperience.TabIndex = 6;
            lbExperience.TextChanged += lbExperience_TextChanged;
            // 
            // lbLevel
            // 
            lbLevel.AutoSize = true;
            lbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbLevel.Location = new System.Drawing.Point(124, 128);
            lbLevel.Name = "lbLevel";
            lbLevel.Size = new System.Drawing.Size(0, 20);
            lbLevel.TabIndex = 7;
            // 
            // lbSelectAction
            // 
            lbSelectAction.AutoSize = true;
            lbSelectAction.Location = new System.Drawing.Point(604, 665);
            lbSelectAction.Name = "lbSelectAction";
            lbSelectAction.Size = new System.Drawing.Size(117, 20);
            lbSelectAction.TabIndex = 8;
            lbSelectAction.Text = "Selection Action";
            // 
            // cboWeapon
            // 
            cboWeapon.FormattingEnabled = true;
            cboWeapon.Location = new System.Drawing.Point(369, 699);
            cboWeapon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cboWeapon.Name = "cboWeapon";
            cboWeapon.Size = new System.Drawing.Size(121, 28);
            cboWeapon.TabIndex = 9;
            // 
            // cboPotions
            // 
            cboPotions.FormattingEnabled = true;
            cboPotions.Location = new System.Drawing.Point(369, 741);
            cboPotions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cboPotions.Name = "cboPotions";
            cboPotions.Size = new System.Drawing.Size(121, 28);
            cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            btnUseWeapon.Location = new System.Drawing.Point(620, 699);
            btnUseWeapon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnUseWeapon.Name = "btnUseWeapon";
            btnUseWeapon.Size = new System.Drawing.Size(75, 29);
            btnUseWeapon.TabIndex = 11;
            btnUseWeapon.Text = "Use";
            btnUseWeapon.UseVisualStyleBackColor = true;
            btnUseWeapon.Click += btnUseWeapon_Click;
            // 
            // btnUsePotion
            // 
            btnUsePotion.Location = new System.Drawing.Point(620, 741);
            btnUsePotion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnUsePotion.Name = "btnUsePotion";
            btnUsePotion.Size = new System.Drawing.Size(75, 29);
            btnUsePotion.TabIndex = 12;
            btnUsePotion.Text = "Use";
            btnUsePotion.UseVisualStyleBackColor = true;
            btnUsePotion.Click += btnUsePotion_Click;
            // 
            // btnNorth
            // 
            btnNorth.Location = new System.Drawing.Point(493, 541);
            btnNorth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnNorth.Name = "btnNorth";
            btnNorth.Size = new System.Drawing.Size(75, 29);
            btnNorth.TabIndex = 13;
            btnNorth.Text = "North";
            btnNorth.UseVisualStyleBackColor = true;
            btnNorth.Click += btnNorth_Click;
            // 
            // btnEast
            // 
            btnEast.Location = new System.Drawing.Point(573, 571);
            btnEast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEast.Name = "btnEast";
            btnEast.Size = new System.Drawing.Size(75, 29);
            btnEast.TabIndex = 14;
            btnEast.Text = "East";
            btnEast.UseVisualStyleBackColor = true;
            btnEast.Click += btnEast_Click;
            // 
            // btnSouth
            // 
            btnSouth.Location = new System.Drawing.Point(493, 609);
            btnSouth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSouth.Name = "btnSouth";
            btnSouth.Size = new System.Drawing.Size(75, 29);
            btnSouth.TabIndex = 15;
            btnSouth.Text = "South";
            btnSouth.UseVisualStyleBackColor = true;
            btnSouth.Click += btnSouth_Click;
            // 
            // btnWest
            // 
            btnWest.Location = new System.Drawing.Point(412, 571);
            btnWest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnWest.Name = "btnWest";
            btnWest.Size = new System.Drawing.Size(75, 29);
            btnWest.TabIndex = 16;
            btnWest.Text = "West";
            btnWest.UseVisualStyleBackColor = true;
            btnWest.Click += btnWest_Click;
            // 
            // rtbLocation
            // 
            rtbLocation.Location = new System.Drawing.Point(347, 24);
            rtbLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rtbLocation.Name = "rtbLocation";
            rtbLocation.ReadOnly = true;
            rtbLocation.Size = new System.Drawing.Size(360, 130);
            rtbLocation.TabIndex = 17;
            rtbLocation.Text = "";
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new System.Drawing.Point(347, 162);
            rtbMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.ReadOnly = true;
            rtbMessage.Size = new System.Drawing.Size(360, 356);
            rtbMessage.TabIndex = 18;
            rtbMessage.Text = "";
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AllowUserToResizeRows = false;
            dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvInventory.Enabled = false;
            dgvInventory.Location = new System.Drawing.Point(16, 162);
            dgvInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvInventory.MultiSelect = false;
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new System.Drawing.Size(312, 386);
            dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            dgvQuests.AllowUserToAddRows = false;
            dgvQuests.AllowUserToDeleteRows = false;
            dgvQuests.AllowUserToResizeRows = false;
            dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvQuests.Enabled = false;
            dgvQuests.Location = new System.Drawing.Point(16, 558);
            dgvQuests.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvQuests.MultiSelect = false;
            dgvQuests.Name = "dgvQuests";
            dgvQuests.ReadOnly = true;
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.RowHeadersWidth = 51;
            dgvQuests.Size = new System.Drawing.Size(312, 236);
            dgvQuests.TabIndex = 20;
            // 
            // SuperAdventure
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(717, 804);
            Controls.Add(dgvQuests);
            Controls.Add(dgvInventory);
            Controls.Add(rtbMessage);
            Controls.Add(rtbLocation);
            Controls.Add(btnWest);
            Controls.Add(btnSouth);
            Controls.Add(btnEast);
            Controls.Add(btnNorth);
            Controls.Add(btnUsePotion);
            Controls.Add(btnUseWeapon);
            Controls.Add(cboPotions);
            Controls.Add(cboWeapon);
            Controls.Add(lbSelectAction);
            Controls.Add(lbLevel);
            Controls.Add(lbExperience);
            Controls.Add(lbGold);
            Controls.Add(lbHitPoint);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SuperAdventure";
            Text = "My Game";
            FormClosing += SuperAdventure_FormClosing;
            Load += SuperAdventure_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbHitPoint;
        private System.Windows.Forms.Label lbGold;
        private System.Windows.Forms.Label lbExperience;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbSelectAction;
        private System.Windows.Forms.ComboBox cboWeapon;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
    }
}

