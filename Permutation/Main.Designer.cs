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
            btnPer = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txtPer = new System.Windows.Forms.TextBox();
            lstAllPermutations = new System.Windows.Forms.ListBox();
            btnClear = new System.Windows.Forms.Button();
            lstDictionaryWords = new System.Windows.Forms.ListBox();
            lblCurrentWordSearched = new System.Windows.Forms.Label();
            btnFindWord = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnPer
            // 
            btnPer.Font = new System.Drawing.Font("Calibri", 14.25F);
            btnPer.Location = new System.Drawing.Point(552, 83);
            btnPer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnPer.Name = "btnPer";
            btnPer.Size = new System.Drawing.Size(116, 31);
            btnPer.TabIndex = 0;
            btnPer.Text = "Find All";
            btnPer.UseVisualStyleBackColor = true;
            btnPer.Click += btnPer_Click;
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
            // txtPer
            // 
            txtPer.Font = new System.Drawing.Font("Calibri", 14.25F);
            txtPer.Location = new System.Drawing.Point(397, 12);
            txtPer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtPer.Name = "txtPer";
            txtPer.Size = new System.Drawing.Size(271, 31);
            txtPer.TabIndex = 2;
            txtPer.TextChanged += txtPer_TextChanged;
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
            lstDictionaryWords.Location = new System.Drawing.Point(335, 123);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(683, 15);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 23);
            label2.TabIndex = 8;
            label2.Text = "Lock Letters";
            // 
            // frmPerm
            // 
            AcceptButton = btnPer;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(793, 554);
            Controls.Add(label2);
            Controls.Add(btnFindWord);
            Controls.Add(lblCurrentWordSearched);
            Controls.Add(lstDictionaryWords);
            Controls.Add(btnClear);
            Controls.Add(lstAllPermutations);
            Controls.Add(txtPer);
            Controls.Add(label1);
            Controls.Add(btnPer);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "frmPerm";
            Text = "Permutation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnPer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPer;
        private System.Windows.Forms.ListBox lstAllPermutations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstDictionaryWords;
        private System.Windows.Forms.Label lblCurrentWordSearched;
        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.Label label2;
    }
}

