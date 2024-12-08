namespace Permutation
{
    partial class frmPerm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerm));
            btnFindAll = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txtWord = new System.Windows.Forms.TextBox();
            lstAllPermutations = new System.Windows.Forms.ListBox();
            btnClear = new System.Windows.Forms.Button();
            lstDictionaryWords = new System.Windows.Forms.ListBox();
            lblCurrentWordSearched = new System.Windows.Forms.Label();
            btnFindWord = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            chkCycleAllPositions = new System.Windows.Forms.CheckBox();
            txtSubtitutionLetters = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtLetterPosition = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblRunTime = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            chkViewAllPermutations = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnFindAll
            // 
            btnFindAll.Font = new System.Drawing.Font("Calibri", 14.25F);
            btnFindAll.Location = new System.Drawing.Point(584, 85);
            btnFindAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnFindAll.Name = "btnFindAll";
            btnFindAll.Size = new System.Drawing.Size(84, 31);
            btnFindAll.TabIndex = 0;
            btnFindAll.Text = "Find All";
            btnFindAll.UseVisualStyleBackColor = true;
            btnFindAll.Click += btnFindAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(335, 15);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 23);
            label1.TabIndex = 1;
            label1.Text = "Word:";
            // 
            // txtWord
            // 
            txtWord.Font = new System.Drawing.Font("Calibri", 14.25F);
            txtWord.Location = new System.Drawing.Point(397, 12);
            txtWord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtWord.Name = "txtWord";
            txtWord.Size = new System.Drawing.Size(271, 31);
            txtWord.TabIndex = 2;
            // 
            // lstAllPermutations
            // 
            lstAllPermutations.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lstAllPermutations.FormattingEnabled = true;
            lstAllPermutations.ItemHeight = 23;
            lstAllPermutations.Location = new System.Drawing.Point(10, 11);
            lstAllPermutations.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            lstAllPermutations.Name = "lstAllPermutations";
            lstAllPermutations.Size = new System.Drawing.Size(305, 533);
            lstAllPermutations.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Font = new System.Drawing.Font("Calibri", 14.25F);
            btnClear.Location = new System.Drawing.Point(337, 49);
            btnClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(107, 31);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear All";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lstDictionaryWords
            // 
            lstDictionaryWords.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lstDictionaryWords.FormattingEnabled = true;
            lstDictionaryWords.HorizontalScrollbar = true;
            lstDictionaryWords.ItemHeight = 23;
            lstDictionaryWords.Location = new System.Drawing.Point(335, 126);
            lstDictionaryWords.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            lstDictionaryWords.Name = "lstDictionaryWords";
            lstDictionaryWords.Size = new System.Drawing.Size(333, 418);
            lstDictionaryWords.TabIndex = 5;
            // 
            // lblCurrentWordSearched
            // 
            lblCurrentWordSearched.AutoSize = true;
            lblCurrentWordSearched.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCurrentWordSearched.ForeColor = System.Drawing.Color.White;
            lblCurrentWordSearched.Location = new System.Drawing.Point(335, 87);
            lblCurrentWordSearched.Name = "lblCurrentWordSearched";
            lblCurrentWordSearched.Size = new System.Drawing.Size(88, 23);
            lblCurrentWordSearched.TabIndex = 6;
            lblCurrentWordSearched.Text = "-------------";
            // 
            // btnFindWord
            // 
            btnFindWord.Font = new System.Drawing.Font("Calibri", 14.25F);
            btnFindWord.Location = new System.Drawing.Point(448, 49);
            btnFindWord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnFindWord.Name = "btnFindWord";
            btnFindWord.Size = new System.Drawing.Size(220, 31);
            btnFindWord.TabIndex = 7;
            btnFindWord.Text = "Find Word In Dictionary";
            btnFindWord.UseVisualStyleBackColor = true;
            btnFindWord.Click += btnFindWord_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkCycleAllPositions);
            groupBox1.Controls.Add(txtSubtitutionLetters);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtLetterPosition);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(687, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(327, 139);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Variable Letter";
            // 
            // chkCycleAllPositions
            // 
            chkCycleAllPositions.AutoSize = true;
            chkCycleAllPositions.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkCycleAllPositions.Location = new System.Drawing.Point(183, 38);
            chkCycleAllPositions.Name = "chkCycleAllPositions";
            chkCycleAllPositions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkCycleAllPositions.Size = new System.Drawing.Size(84, 23);
            chkCycleAllPositions.TabIndex = 14;
            chkCycleAllPositions.Text = "Cycle All";
            chkCycleAllPositions.UseVisualStyleBackColor = true;
            // 
            // txtSubtitutionLetters
            // 
            txtSubtitutionLetters.Font = new System.Drawing.Font("Calibri", 12F);
            txtSubtitutionLetters.Location = new System.Drawing.Point(15, 98);
            txtSubtitutionLetters.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtSubtitutionLetters.Multiline = true;
            txtSubtitutionLetters.Name = "txtSubtitutionLetters";
            txtSubtitutionLetters.Size = new System.Drawing.Size(294, 26);
            txtSubtitutionLetters.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Calibri", 12F);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(15, 76);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(284, 19);
            label3.TabIndex = 12;
            label3.Text = "Substitution Letters (delimited by comma):";
            // 
            // txtLetterPosition
            // 
            txtLetterPosition.Font = new System.Drawing.Font("Calibri", 12F);
            txtLetterPosition.Location = new System.Drawing.Point(126, 35);
            txtLetterPosition.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtLetterPosition.Name = "txtLetterPosition";
            txtLetterPosition.Size = new System.Drawing.Size(52, 27);
            txtLetterPosition.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Calibri", 12F);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(15, 38);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 19);
            label2.TabIndex = 10;
            label2.Text = "Letter Position:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(687, 521);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 23);
            label4.TabIndex = 10;
            label4.Text = "Run Time:";
            // 
            // lblRunTime
            // 
            lblRunTime.AutoSize = true;
            lblRunTime.Font = new System.Drawing.Font("Calibri", 12F);
            lblRunTime.ForeColor = System.Drawing.Color.White;
            lblRunTime.Location = new System.Drawing.Point(780, 524);
            lblRunTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblRunTime.Name = "lblRunTime";
            lblRunTime.Size = new System.Drawing.Size(54, 19);
            lblRunTime.TabIndex = 14;
            lblRunTime.Text = "---------";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkViewAllPermutations);
            groupBox2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(687, 11);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(327, 139);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            // 
            // chkViewAllPermutations
            // 
            chkViewAllPermutations.AutoSize = true;
            chkViewAllPermutations.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chkViewAllPermutations.Location = new System.Drawing.Point(15, 40);
            chkViewAllPermutations.Name = "chkViewAllPermutations";
            chkViewAllPermutations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            chkViewAllPermutations.Size = new System.Drawing.Size(171, 23);
            chkViewAllPermutations.TabIndex = 14;
            chkViewAllPermutations.Text = "View All Permutations";
            chkViewAllPermutations.UseVisualStyleBackColor = true;
            // 
            // frmPerm
            // 
            AcceptButton = btnFindAll;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(1026, 554);
            Controls.Add(groupBox2);
            Controls.Add(lblRunTime);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(btnFindWord);
            Controls.Add(lblCurrentWordSearched);
            Controls.Add(lstDictionaryWords);
            Controls.Add(btnClear);
            Controls.Add(lstAllPermutations);
            Controls.Add(txtWord);
            Controls.Add(label1);
            Controls.Add(btnFindAll);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "frmPerm";
            Text = "Permutation";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnFindAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.ListBox lstAllPermutations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstDictionaryWords;
        private System.Windows.Forms.Label lblCurrentWordSearched;
        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLetterPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubtitutionLetters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.CheckBox chkCycleAllPositions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkViewAllPermutations;
    }
}

