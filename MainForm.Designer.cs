
namespace Kursovoi
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DriveLbel = new System.Windows.Forms.Label();
            this.DriveComboBox = new System.Windows.Forms.ComboBox();
            this.DriveTypeLable = new System.Windows.Forms.Label();
            this.FileSystemLable = new System.Windows.Forms.Label();
            this.UsedSpaceLable = new System.Windows.Forms.Label();
            this.FreeSpaceLable = new System.Windows.Forms.Label();
            this.CapacityLable = new System.Windows.Forms.Label();
            this.PercentFreeSpaceLable = new System.Windows.Forms.Label();
            this.TrackEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.EnforceEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.QuotaButton = new System.Windows.Forms.Button();
            this.VolumeQuota = new System.Windows.Forms.Label();
            this.StatusQuota = new System.Windows.Forms.Label();
            this.LogWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.LogLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.QuotasGridView = new System.Windows.Forms.DataGridView();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitQuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarningThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OccupiedSpacePerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotaEntryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuotasGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DriveLbel
            // 
            this.DriveLbel.AutoSize = true;
            this.DriveLbel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DriveLbel.Location = new System.Drawing.Point(12, 9);
            this.DriveLbel.Name = "DriveLbel";
            this.DriveLbel.Size = new System.Drawing.Size(63, 25);
            this.DriveLbel.TabIndex = 0;
            this.DriveLbel.Text = "Drive:";
            // 
            // DriveComboBox
            // 
            this.DriveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveComboBox.FormattingEnabled = true;
            this.DriveComboBox.Location = new System.Drawing.Point(81, 9);
            this.DriveComboBox.Name = "DriveComboBox";
            this.DriveComboBox.Size = new System.Drawing.Size(54, 24);
            this.DriveComboBox.TabIndex = 1;
            this.DriveComboBox.SelectedIndexChanged += new System.EventHandler(this.DriveComboBox_SelectedIndexChanged);
            // 
            // DriveTypeLable
            // 
            this.DriveTypeLable.AutoSize = true;
            this.DriveTypeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DriveTypeLable.Location = new System.Drawing.Point(13, 36);
            this.DriveTypeLable.Name = "DriveTypeLable";
            this.DriveTypeLable.Size = new System.Drawing.Size(126, 20);
            this.DriveTypeLable.TabIndex = 2;
            this.DriveTypeLable.Text = "DriveTypeLable";
            // 
            // FileSystemLable
            // 
            this.FileSystemLable.AutoSize = true;
            this.FileSystemLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileSystemLable.Location = new System.Drawing.Point(13, 56);
            this.FileSystemLable.Name = "FileSystemLable";
            this.FileSystemLable.Size = new System.Drawing.Size(133, 20);
            this.FileSystemLable.TabIndex = 3;
            this.FileSystemLable.Text = "FileSystemLable";
            // 
            // UsedSpaceLable
            // 
            this.UsedSpaceLable.AutoSize = true;
            this.UsedSpaceLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsedSpaceLable.Location = new System.Drawing.Point(190, 9);
            this.UsedSpaceLable.Name = "UsedSpaceLable";
            this.UsedSpaceLable.Size = new System.Drawing.Size(136, 20);
            this.UsedSpaceLable.TabIndex = 4;
            this.UsedSpaceLable.Text = "UsedSpaceLable";
            // 
            // FreeSpaceLable
            // 
            this.FreeSpaceLable.AutoSize = true;
            this.FreeSpaceLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FreeSpaceLable.Location = new System.Drawing.Point(190, 36);
            this.FreeSpaceLable.Name = "FreeSpaceLable";
            this.FreeSpaceLable.Size = new System.Drawing.Size(131, 20);
            this.FreeSpaceLable.TabIndex = 5;
            this.FreeSpaceLable.Text = "FreeSpaceLable";
            // 
            // CapacityLable
            // 
            this.CapacityLable.AutoSize = true;
            this.CapacityLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CapacityLable.Location = new System.Drawing.Point(190, 67);
            this.CapacityLable.Name = "CapacityLable";
            this.CapacityLable.Size = new System.Drawing.Size(115, 20);
            this.CapacityLable.TabIndex = 6;
            this.CapacityLable.Text = "CapacityLable";
            // 
            // PercentFreeSpaceLable
            // 
            this.PercentFreeSpaceLable.AutoSize = true;
            this.PercentFreeSpaceLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PercentFreeSpaceLable.Location = new System.Drawing.Point(190, 100);
            this.PercentFreeSpaceLable.Name = "PercentFreeSpaceLable";
            this.PercentFreeSpaceLable.Size = new System.Drawing.Size(189, 20);
            this.PercentFreeSpaceLable.TabIndex = 7;
            this.PercentFreeSpaceLable.Text = "PercentFreeSpaceLable";
            // 
            // TrackEnableCheckBox
            // 
            this.TrackEnableCheckBox.AutoSize = true;
            this.TrackEnableCheckBox.Enabled = false;
            this.TrackEnableCheckBox.Location = new System.Drawing.Point(612, 30);
            this.TrackEnableCheckBox.Name = "TrackEnableCheckBox";
            this.TrackEnableCheckBox.Size = new System.Drawing.Size(200, 21);
            this.TrackEnableCheckBox.TabIndex = 8;
            this.TrackEnableCheckBox.Text = "Enable quota management";
            this.TrackEnableCheckBox.UseVisualStyleBackColor = true;
            this.TrackEnableCheckBox.CheckedChanged += new System.EventHandler(this.TrackEnableCheckBox_CheckedChanged);
            // 
            // EnforceEnableCheckBox
            // 
            this.EnforceEnableCheckBox.AutoSize = true;
            this.EnforceEnableCheckBox.Enabled = false;
            this.EnforceEnableCheckBox.Location = new System.Drawing.Point(612, 57);
            this.EnforceEnableCheckBox.Name = "EnforceEnableCheckBox";
            this.EnforceEnableCheckBox.Size = new System.Drawing.Size(325, 21);
            this.EnforceEnableCheckBox.TabIndex = 9;
            this.EnforceEnableCheckBox.Text = "Deny disk space to users exceeding quota limit";
            this.EnforceEnableCheckBox.UseVisualStyleBackColor = true;
            this.EnforceEnableCheckBox.CheckedChanged += new System.EventHandler(this.EnforceEnableCheckBox_CheckedChanged);
            // 
            // QuotaButton
            // 
            this.QuotaButton.Enabled = false;
            this.QuotaButton.Location = new System.Drawing.Point(612, 156);
            this.QuotaButton.Name = "QuotaButton";
            this.QuotaButton.Size = new System.Drawing.Size(75, 23);
            this.QuotaButton.TabIndex = 10;
            this.QuotaButton.Text = "OK";
            this.QuotaButton.UseVisualStyleBackColor = true;
            this.QuotaButton.Click += new System.EventHandler(this.QuotaButton_Click);
            // 
            // VolumeQuota
            // 
            this.VolumeQuota.AutoSize = true;
            this.VolumeQuota.Location = new System.Drawing.Point(609, 82);
            this.VolumeQuota.Name = "VolumeQuota";
            this.VolumeQuota.Size = new System.Drawing.Size(311, 17);
            this.VolumeQuota.TabIndex = 11;
            this.VolumeQuota.Text = "Select the quota logging options for this volume:";
            // 
            // StatusQuota
            // 
            this.StatusQuota.AutoSize = true;
            this.StatusQuota.Location = new System.Drawing.Point(609, 9);
            this.StatusQuota.Name = "StatusQuota";
            this.StatusQuota.Size = new System.Drawing.Size(52, 17);
            this.StatusQuota.TabIndex = 12;
            this.StatusQuota.Text = "Status:";
            // 
            // LogWarningCheckBox
            // 
            this.LogWarningCheckBox.AutoSize = true;
            this.LogWarningCheckBox.Enabled = false;
            this.LogWarningCheckBox.Location = new System.Drawing.Point(612, 129);
            this.LogWarningCheckBox.Name = "LogWarningCheckBox";
            this.LogWarningCheckBox.Size = new System.Drawing.Size(341, 21);
            this.LogWarningCheckBox.TabIndex = 13;
            this.LogWarningCheckBox.Text = "Log event when a user exeeds their warning level";
            this.LogWarningCheckBox.UseVisualStyleBackColor = true;
            this.LogWarningCheckBox.CheckedChanged += new System.EventHandler(this.LogWarningCheckBox_CheckedChanged);
            // 
            // LogLimitCheckBox
            // 
            this.LogLimitCheckBox.AutoSize = true;
            this.LogLimitCheckBox.Enabled = false;
            this.LogLimitCheckBox.Location = new System.Drawing.Point(612, 102);
            this.LogLimitCheckBox.Name = "LogLimitCheckBox";
            this.LogLimitCheckBox.Size = new System.Drawing.Size(323, 21);
            this.LogLimitCheckBox.TabIndex = 14;
            this.LogLimitCheckBox.Text = "Log event when a user exeeds their quota limit";
            this.LogLimitCheckBox.UseVisualStyleBackColor = true;
            this.LogLimitCheckBox.CheckedChanged += new System.EventHandler(this.LogLimitCheckBox_CheckedChanged);
            // 
            // QuotasGridView
            // 
            this.QuotasGridView.AllowUserToAddRows = false;
            this.QuotasGridView.AllowUserToDeleteRows = false;
            this.QuotasGridView.AllowUserToResizeRows = false;
            this.QuotasGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.QuotasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuotasGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.State,
            this.LoginName,
            this.UsedVolume,
            this.LimitQuota,
            this.WarningThreshold,
            this.OccupiedSpacePerc});
            this.QuotasGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.QuotasGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QuotasGridView.Location = new System.Drawing.Point(0, 202);
            this.QuotasGridView.MultiSelect = false;
            this.QuotasGridView.Name = "QuotasGridView";
            this.QuotasGridView.ReadOnly = true;
            this.QuotasGridView.RowHeadersVisible = false;
            this.QuotasGridView.RowHeadersWidth = 51;
            this.QuotasGridView.RowTemplate.Height = 24;
            this.QuotasGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuotasGridView.Size = new System.Drawing.Size(1230, 392);
            this.QuotasGridView.TabIndex = 15;
            this.QuotasGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.QuotasGridView_CellMouseDoubleClick);
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 125;
            // 
            // LoginName
            // 
            this.LoginName.HeaderText = "LoginName";
            this.LoginName.MinimumWidth = 6;
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.Width = 230;
            // 
            // UsedVolume
            // 
            this.UsedVolume.HeaderText = "UsedVolume";
            this.UsedVolume.MinimumWidth = 6;
            this.UsedVolume.Name = "UsedVolume";
            this.UsedVolume.ReadOnly = true;
            this.UsedVolume.Width = 125;
            // 
            // LimitQuota
            // 
            this.LimitQuota.HeaderText = "LimitQuota";
            this.LimitQuota.MinimumWidth = 6;
            this.LimitQuota.Name = "LimitQuota";
            this.LimitQuota.ReadOnly = true;
            this.LimitQuota.Width = 125;
            // 
            // WarningThreshold
            // 
            this.WarningThreshold.HeaderText = "WarningThreshold";
            this.WarningThreshold.MinimumWidth = 6;
            this.WarningThreshold.Name = "WarningThreshold";
            this.WarningThreshold.ReadOnly = true;
            this.WarningThreshold.Width = 125;
            // 
            // OccupiedSpacePerc
            // 
            this.OccupiedSpacePerc.HeaderText = "OccupiedSpacePerc";
            this.OccupiedSpacePerc.MinimumWidth = 6;
            this.OccupiedSpacePerc.Name = "OccupiedSpacePerc";
            this.OccupiedSpacePerc.ReadOnly = true;
            this.OccupiedSpacePerc.Width = 125;
            // 
            // QuotaEntryButton
            // 
            this.QuotaEntryButton.Enabled = false;
            this.QuotaEntryButton.Location = new System.Drawing.Point(12, 167);
            this.QuotaEntryButton.Name = "QuotaEntryButton";
            this.QuotaEntryButton.Size = new System.Drawing.Size(167, 29);
            this.QuotaEntryButton.TabIndex = 16;
            this.QuotaEntryButton.Text = "Create quota entry";
            this.QuotaEntryButton.UseVisualStyleBackColor = true;
            this.QuotaEntryButton.Click += new System.EventHandler(this.QuotaEntryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 594);
            this.Controls.Add(this.QuotaEntryButton);
            this.Controls.Add(this.QuotasGridView);
            this.Controls.Add(this.LogLimitCheckBox);
            this.Controls.Add(this.LogWarningCheckBox);
            this.Controls.Add(this.StatusQuota);
            this.Controls.Add(this.VolumeQuota);
            this.Controls.Add(this.QuotaButton);
            this.Controls.Add(this.EnforceEnableCheckBox);
            this.Controls.Add(this.TrackEnableCheckBox);
            this.Controls.Add(this.PercentFreeSpaceLable);
            this.Controls.Add(this.CapacityLable);
            this.Controls.Add(this.FreeSpaceLable);
            this.Controls.Add(this.UsedSpaceLable);
            this.Controls.Add(this.FileSystemLable);
            this.Controls.Add(this.DriveTypeLable);
            this.Controls.Add(this.DriveComboBox);
            this.Controls.Add(this.DriveLbel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainForm";
            this.Text = "Kursovoi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuotasGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DriveLbel;
        private System.Windows.Forms.ComboBox DriveComboBox;
        private System.Windows.Forms.Label DriveTypeLable;
        private System.Windows.Forms.Label FileSystemLable;
        private System.Windows.Forms.Label UsedSpaceLable;
        private System.Windows.Forms.Label FreeSpaceLable;
        private System.Windows.Forms.Label CapacityLable;
        private System.Windows.Forms.Label PercentFreeSpaceLable;
        private System.Windows.Forms.CheckBox TrackEnableCheckBox;
        private System.Windows.Forms.CheckBox EnforceEnableCheckBox;
        private System.Windows.Forms.Button QuotaButton;
        private System.Windows.Forms.Label VolumeQuota;
        private System.Windows.Forms.Label StatusQuota;
        private System.Windows.Forms.CheckBox LogWarningCheckBox;
        private System.Windows.Forms.CheckBox LogLimitCheckBox;
        private System.Windows.Forms.DataGridView QuotasGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimitQuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarningThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn OccupiedSpacePerc;
        private System.Windows.Forms.Button QuotaEntryButton;
    }
}

