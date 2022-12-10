
namespace Kursovoi
{
    partial class QuotaCreateForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UserLabel = new System.Windows.Forms.Label();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.LimitRadioButton1 = new System.Windows.Forms.RadioButton();
            this.LimitRadioButton2 = new System.Windows.Forms.RadioButton();
            this.WarningLable = new System.Windows.Forms.Label();
            this.LimitComboBox = new System.Windows.Forms.ComboBox();
            this.LimitTextBox = new System.Windows.Forms.TextBox();
            this.WarningTextBox = new System.Windows.Forms.TextBox();
            this.WarningComboBox = new System.Windows.Forms.ComboBox();
            this.QuotaUsedLabel = new System.Windows.Forms.Label();
            this.QuotaRemainingLabel = new System.Windows.Forms.Label();
            this.QuotaUsedTextLable = new System.Windows.Forms.Label();
            this.QuotaRemainingTextLabel = new System.Windows.Forms.Label();
            this.UserTextLabel = new System.Windows.Forms.Label();
            this.StateLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(218, 319);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 30);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(299, 288);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 30);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(299, 319);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 30);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLabel.Location = new System.Drawing.Point(53, 16);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(50, 20);
            this.UserLabel.TabIndex = 3;
            this.UserLabel.Text = "User:";
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(110, 12);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(264, 24);
            this.UserComboBox.TabIndex = 4;
            this.UserComboBox.SelectedIndexChanged += new System.EventHandler(this.UserComboBox_SelectedIndexChanged);
            // 
            // LimitRadioButton1
            // 
            this.LimitRadioButton1.AutoSize = true;
            this.LimitRadioButton1.Location = new System.Drawing.Point(24, 139);
            this.LimitRadioButton1.Name = "LimitRadioButton1";
            this.LimitRadioButton1.Size = new System.Drawing.Size(171, 21);
            this.LimitRadioButton1.TabIndex = 5;
            this.LimitRadioButton1.TabStop = true;
            this.LimitRadioButton1.Text = "Do not limit disk usage";
            this.LimitRadioButton1.UseVisualStyleBackColor = true;
            this.LimitRadioButton1.CheckedChanged += new System.EventHandler(this.LimitRadioButton1_CheckedChanged);
            // 
            // LimitRadioButton2
            // 
            this.LimitRadioButton2.AutoSize = true;
            this.LimitRadioButton2.Location = new System.Drawing.Point(24, 167);
            this.LimitRadioButton2.Name = "LimitRadioButton2";
            this.LimitRadioButton2.Size = new System.Drawing.Size(145, 21);
            this.LimitRadioButton2.TabIndex = 6;
            this.LimitRadioButton2.TabStop = true;
            this.LimitRadioButton2.Text = "Limit disk space to";
            this.LimitRadioButton2.UseVisualStyleBackColor = true;
            this.LimitRadioButton2.CheckedChanged += new System.EventHandler(this.LimitRadioButton2_CheckedChanged);
            // 
            // WarningLable
            // 
            this.WarningLable.AutoSize = true;
            this.WarningLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WarningLable.Location = new System.Drawing.Point(38, 203);
            this.WarningLable.Name = "WarningLable";
            this.WarningLable.Size = new System.Drawing.Size(131, 17);
            this.WarningLable.TabIndex = 7;
            this.WarningLable.Text = "Set warning level to";
            // 
            // LimitComboBox
            // 
            this.LimitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitComboBox.FormattingEnabled = true;
            this.LimitComboBox.Location = new System.Drawing.Point(253, 166);
            this.LimitComboBox.Name = "LimitComboBox";
            this.LimitComboBox.Size = new System.Drawing.Size(60, 24);
            this.LimitComboBox.TabIndex = 8;
            this.LimitComboBox.SelectedIndexChanged += new System.EventHandler(this.LimitComboBox_SelectedIndexChanged);
            // 
            // LimitTextBox
            // 
            this.LimitTextBox.Location = new System.Drawing.Point(175, 166);
            this.LimitTextBox.Name = "LimitTextBox";
            this.LimitTextBox.Size = new System.Drawing.Size(60, 22);
            this.LimitTextBox.TabIndex = 9;
            this.LimitTextBox.Text = "1";
            this.LimitTextBox.TextChanged += new System.EventHandler(this.LimitTextBox_TextChanged);
            this.LimitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LimitTextBox_KeyPress);
            // 
            // WarningTextBox
            // 
            this.WarningTextBox.Location = new System.Drawing.Point(175, 200);
            this.WarningTextBox.Name = "WarningTextBox";
            this.WarningTextBox.Size = new System.Drawing.Size(60, 22);
            this.WarningTextBox.TabIndex = 11;
            this.WarningTextBox.Text = "1";
            this.WarningTextBox.TextChanged += new System.EventHandler(this.WarningTextBox_TextChanged);
            this.WarningTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WarningTextBox_KeyPress);
            // 
            // WarningComboBox
            // 
            this.WarningComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WarningComboBox.FormattingEnabled = true;
            this.WarningComboBox.Location = new System.Drawing.Point(253, 200);
            this.WarningComboBox.Name = "WarningComboBox";
            this.WarningComboBox.Size = new System.Drawing.Size(60, 24);
            this.WarningComboBox.TabIndex = 10;
            this.WarningComboBox.SelectedIndexChanged += new System.EventHandler(this.WarningComboBox_SelectedIndexChanged);
            // 
            // QuotaUsedLabel
            // 
            this.QuotaUsedLabel.AutoSize = true;
            this.QuotaUsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuotaUsedLabel.Location = new System.Drawing.Point(21, 68);
            this.QuotaUsedLabel.Name = "QuotaUsedLabel";
            this.QuotaUsedLabel.Size = new System.Drawing.Size(86, 17);
            this.QuotaUsedLabel.TabIndex = 12;
            this.QuotaUsedLabel.Text = "Quota used:";
            // 
            // QuotaRemainingLabel
            // 
            this.QuotaRemainingLabel.AutoSize = true;
            this.QuotaRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuotaRemainingLabel.Location = new System.Drawing.Point(21, 97);
            this.QuotaRemainingLabel.Name = "QuotaRemainingLabel";
            this.QuotaRemainingLabel.Size = new System.Drawing.Size(117, 17);
            this.QuotaRemainingLabel.TabIndex = 13;
            this.QuotaRemainingLabel.Text = "Quota remaining:";
            // 
            // QuotaUsedTextLable
            // 
            this.QuotaUsedTextLable.AutoSize = true;
            this.QuotaUsedTextLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuotaUsedTextLable.Location = new System.Drawing.Point(144, 68);
            this.QuotaUsedTextLable.Name = "QuotaUsedTextLable";
            this.QuotaUsedTextLable.Size = new System.Drawing.Size(16, 17);
            this.QuotaUsedTextLable.TabIndex = 14;
            this.QuotaUsedTextLable.Text = "1";
            // 
            // QuotaRemainingTextLabel
            // 
            this.QuotaRemainingTextLabel.AutoSize = true;
            this.QuotaRemainingTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuotaRemainingTextLabel.Location = new System.Drawing.Point(144, 97);
            this.QuotaRemainingTextLabel.Name = "QuotaRemainingTextLabel";
            this.QuotaRemainingTextLabel.Size = new System.Drawing.Size(16, 17);
            this.QuotaRemainingTextLabel.TabIndex = 15;
            this.QuotaRemainingTextLabel.Text = "2";
            // 
            // UserTextLabel
            // 
            this.UserTextLabel.AutoSize = true;
            this.UserTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserTextLabel.Location = new System.Drawing.Point(109, 17);
            this.UserTextLabel.Name = "UserTextLabel";
            this.UserTextLabel.Size = new System.Drawing.Size(40, 18);
            this.UserTextLabel.TabIndex = 16;
            this.UserTextLabel.Text = "User";
            // 
            // StateLable
            // 
            this.StateLable.AutoSize = true;
            this.StateLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StateLable.Location = new System.Drawing.Point(272, 97);
            this.StateLable.Name = "StateLable";
            this.StateLable.Size = new System.Drawing.Size(41, 17);
            this.StateLable.TabIndex = 17;
            this.StateLable.Text = "State";
            // 
            // QuotaCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 361);
            this.Controls.Add(this.StateLable);
            this.Controls.Add(this.UserTextLabel);
            this.Controls.Add(this.QuotaRemainingTextLabel);
            this.Controls.Add(this.QuotaUsedTextLable);
            this.Controls.Add(this.QuotaRemainingLabel);
            this.Controls.Add(this.QuotaUsedLabel);
            this.Controls.Add(this.WarningTextBox);
            this.Controls.Add(this.WarningComboBox);
            this.Controls.Add(this.LimitTextBox);
            this.Controls.Add(this.LimitComboBox);
            this.Controls.Add(this.WarningLable);
            this.Controls.Add(this.LimitRadioButton2);
            this.Controls.Add(this.LimitRadioButton1);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.OkButton);
            this.Name = "QuotaCreateForm";
            this.Text = "Quota params";
            this.Load += new System.EventHandler(this.QuotaCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.RadioButton LimitRadioButton1;
        private System.Windows.Forms.RadioButton LimitRadioButton2;
        private System.Windows.Forms.Label WarningLable;
        private System.Windows.Forms.ComboBox LimitComboBox;
        private System.Windows.Forms.TextBox LimitTextBox;
        private System.Windows.Forms.TextBox WarningTextBox;
        private System.Windows.Forms.ComboBox WarningComboBox;
        private System.Windows.Forms.Label QuotaUsedLabel;
        private System.Windows.Forms.Label QuotaRemainingLabel;
        private System.Windows.Forms.Label QuotaUsedTextLable;
        private System.Windows.Forms.Label QuotaRemainingTextLabel;
        private System.Windows.Forms.Label UserTextLabel;
        private System.Windows.Forms.Label StateLable;
    }
}