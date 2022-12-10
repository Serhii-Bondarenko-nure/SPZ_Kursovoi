using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Security.Principal;

namespace Kursovoi
{
    public partial class MainForm : Form
    {
        //static List<DiskQuota> QutasForDisk = new List<DiskQuota>();

        DiskQuota Quota;
        List<string> UsersForDisk = new List<string>();
        List<QuotaForWrite> QuotasForWrite = new List<QuotaForWrite>();

        bool TrackOnOf = false;
        bool EnforceOnOf = false;
        bool LogLimit = false;
        bool LogWarning = false;

        public string retName, retLimit, retWarning;
        public bool retToSet = false;

        public double Bytes_to_(long bytes, string bt)
        {
            const double BytesInKB = 1024;
            const double BytesInMB = 1048576;
            const double BytesInGB = 1073741824;
            const double BytesInTB = 1099511627776;

            switch (bt)
            {
                case "KB":
                    return bytes / BytesInKB;
                case "MB":
                    return bytes / BytesInMB;
                case "GB":
                    return bytes / BytesInGB;
                case "TB":
                    return bytes / BytesInTB;
                default:
                    return 0;
            }
        }

        public class QuotaForWrite
        {
            public string State;
            public string LoginName;
            public string UsedVolume;
            public string LimitQuota;
            public string WarningThreshold;
            public string OccupiedSpacePerc;

            string ConvertBytesTo(string bytesToConvert)
            {
                ulong bytes = UInt64.Parse(bytesToConvert);

                const double BytesInKB = 1024;
                const double BytesInMB = 1048576;
                const double BytesInGB = 1073741824;
                const double BytesInTB = 1099511627776;

                if (bytes < BytesInKB)
                {
                    return "0 KB";
                }
                else if (bytes >= BytesInKB)
                {
                    if (bytes >= BytesInMB)
                    {
                        if (bytes >= BytesInGB)
                        {
                            if (bytes >= BytesInTB)
                            {
                                return Math.Round(bytes / BytesInTB, 2).ToString() + " TB";
                            }
                            return Math.Round(bytes / BytesInGB, 2).ToString() + " GB";
                        }
                        return Math.Round(bytes / BytesInMB, 2).ToString() + " MB";
                    }
                    return Math.Round(bytes / BytesInKB, 2).ToString() + " KB";
                }
                return bytes.ToString() + " Bytes";
            }

            public QuotaForWrite(string state, string loginName, string usedVolume, string limitQuota, string warningThreshold, string occupiedSpacePerc)
            {
                this.State = state;
                this.LoginName = loginName;
                this.UsedVolume = ConvertBytesTo(usedVolume);

                if (limitQuota.CompareTo("No limit") == 0)
                {
                    this.LimitQuota = limitQuota;
                }
                else
                {
                    this.LimitQuota = ConvertBytesTo(limitQuota);
                }
                if (warningThreshold.CompareTo("No limit") == 0)
                {
                    this.WarningThreshold = warningThreshold;
                }
                else
                {
                    this.WarningThreshold = ConvertBytesTo(warningThreshold);
                }
                if (occupiedSpacePerc.CompareTo("N/A") == 0)
                {
                    this.OccupiedSpacePerc = occupiedSpacePerc;
                }
                else
                {
                    this.OccupiedSpacePerc = Math.Round(double.Parse(occupiedSpacePerc), 2).ToString();
                }
                    
            }
        }

        //проверяет, запущина ли программа от имени администратора
        bool IsUserAdministrator()
        {
            bool isAdmin = false;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);//Is Admin
            }
            //Is not admin
            catch (UnauthorizedAccessException ex) { }
            catch (Exception ex) { }

            return isAdmin;
        }

        public MainForm()
        {
            InitializeComponent();

            if (IsUserAdministrator())
            {
                GetDrives();
            }
            else
            {
                MessageBox.Show(
                    "How did you run without admin rights?",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void GetDrives()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    DriveComboBox.Items.Add(drive.Name);
                }
                catch
                {
                    MessageBox.Show(
                    "Drive not found!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void SetDateView()
        {
            QuotasGridView.Rows.Clear();
            foreach (var item in QuotasForWrite)
            {
                QuotasGridView.Rows.Add(item.State, item.LoginName, item.UsedVolume, item.LimitQuota, item.WarningThreshold, item.OccupiedSpacePerc);
            }          
        }

        private void DriveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getInfo = DriveComboBox.SelectedItem.ToString();
            DriveInfo Drive = new DriveInfo(getInfo);

            Quota = new DiskQuota(Drive.Name.Substring(0, 2) + " ");

            DriveTypeLable.Text = "Type: " + Drive.DriveType;
            FileSystemLable.Text = "File system: " + Drive.DriveFormat;
            UsedSpaceLable.Text = "Used space: " +
                (Drive.TotalSize - Drive.TotalFreeSpace) + " bytes  " +
               Math.Round(Bytes_to_(Drive.TotalSize - Drive.TotalFreeSpace, "GB"), 2) + " GB";
            FreeSpaceLable.Text = "Free space: " +
                Drive.TotalFreeSpace + " bytes  " +
                Math.Round(Bytes_to_(Drive.TotalFreeSpace, "GB"), 2) + " GB";
            CapacityLable.Text = "Capacity: " +
                Drive.TotalSize + " bytes  " +
                Math.Round(Bytes_to_(Drive.TotalSize, "GB"), 2) + " GB";
            PercentFreeSpaceLable.Text = "Percent Free Space: " + Math.Round((Drive.AvailableFreeSpace / (float)Drive.TotalSize) * 100, 2) + "%";

            QuotasGridView.Rows.Clear();

            TrackEnableCheckBox.Checked = false;
            EnforceEnableCheckBox.Checked = false;
            LogLimitCheckBox.Checked = false;
            LogWarningCheckBox.Checked = false;           

            TrackEnableCheckBox.Enabled = true;
            QuotaButton.Enabled = true;

            QuotaEntryButton.Enabled = false;


            if (Quota.ReturnTrack())
            {
                Quota.ReturnUsers(ref UsersForDisk);
                Quota.ReturnQuotas(ref QuotasForWrite);
                SetDateView();
                TrackEnableCheckBox.CheckState = CheckState.Checked;
                if (Quota.ReturnRegLimit())
                {
                    LogLimitCheckBox.CheckState = CheckState.Checked;
                }
                if (Quota.ReturnRegWarning())
                {
                    LogWarningCheckBox.CheckState = CheckState.Checked;
                }
                if (Quota.ReturnEnforce())
                {
                    EnforceEnableCheckBox.CheckState = CheckState.Checked;
                }
                EnforceEnableCheckBox.Enabled = true;
                LogLimitCheckBox.Enabled = true;
                LogWarningCheckBox.Enabled = true;
                QuotaEntryButton.Enabled = true;
            }
            else
            {
                EnforceEnableCheckBox.Enabled = false;
                LogLimitCheckBox.Enabled = false;
                LogWarningCheckBox.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TrackEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                TrackOnOf = true;
                EnforceEnableCheckBox.Enabled = true;
                LogLimitCheckBox.Enabled = true;
                LogWarningCheckBox.Enabled = true;
                QuotaEntryButton.Enabled = true;
            }
            else
            {
                TrackOnOf = false;
                EnforceEnableCheckBox.Enabled = false;
                LogLimitCheckBox.Enabled = false;
                LogWarningCheckBox.Enabled = false;
                QuotaEntryButton.Enabled = false;
            }
        }

        private void EnforceEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                EnforceOnOf = true;
            }
            else
            {
                EnforceOnOf = false;
            }
        }

        private void LogLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                LogLimit = true;
            }
            else
            {
                LogLimit = false;
            }
        }

        private void LogWarningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                LogWarning = true;
            }
            else
            {
                LogWarning = false;
            }
        }

        private void QuotaButton_Click(object sender, EventArgs e)
        {
            SetDateView();
            if (TrackOnOf && EnforceOnOf)
            {
                Quota.SetEnforce(EnforceOnOf);
                Quota.ReturnUsers(ref UsersForDisk);
                Quota.ReturnQuotas(ref QuotasForWrite);
                SetDateView();
            }
            else if (TrackOnOf && !EnforceOnOf)
            {
                Quota.SetTrack(TrackOnOf);
                Quota.ReturnUsers(ref UsersForDisk);
                Quota.ReturnQuotas(ref QuotasForWrite);
                SetDateView();
            }
            else if (!TrackOnOf)
            {
                Quota.SetTrack(TrackOnOf);
                QuotasGridView.Rows.Clear();
            }
        }       

        private void QuotaEntryButton_Click(object sender, EventArgs e)
        {
            QuotaCreateForm qtCreateForm = new QuotaCreateForm(this, UsersForDisk);
            qtCreateForm.Show();   
        }

        private void QuotasGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = QuotasGridView.CurrentRow.Index;

            QuotaCreateForm qtCreateForm = new QuotaCreateForm(this, UsersForDisk,
                QuotasGridView.Rows[rowindex].Cells[0].Value.ToString(),
                QuotasGridView.Rows[rowindex].Cells[1].Value.ToString(),
                QuotasGridView.Rows[rowindex].Cells[2].Value.ToString(),
                QuotasGridView.Rows[rowindex].Cells[3].Value.ToString(),
                QuotasGridView.Rows[rowindex].Cells[4].Value.ToString(),
                QuotasGridView.Rows[rowindex].Cells[5].Value.ToString());
            qtCreateForm.Show();
        }

        public void SetEntryQuota()
        {
            if (retName.CompareTo(UsersForDisk[0]) == 0)
            {
                if (retToSet)
                {
                    Quota.SetQuota(retName);
                }
                else
                {
                    Quota.SetQuota(UInt64.Parse(retWarning), retName);
                }
                Quota.ReturnUsers(ref UsersForDisk);
                Quota.ReturnQuotas(ref QuotasForWrite);
                SetDateView();
            }
            else
            {
                if (retToSet)
                {
                    Quota.SetQuota(retName);
                }
                else
                {
                    Quota.SetQuota(UInt64.Parse(retWarning), UInt64.Parse(retLimit), retName);
                }
                Quota.ReturnUsers(ref UsersForDisk);
                Quota.ReturnQuotas(ref QuotasForWrite);
                SetDateView();
            }           
        }

    }
}
