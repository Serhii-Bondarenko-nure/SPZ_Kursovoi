using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kursovoi
{
    public partial class QuotaCreateForm : Form
    {
        MainForm CurrentMainFom;
        List<string> UsersForDisk = new List<string>();

        string State;
        string CurrentUser;
        string UsedValue;
        string UsedModifier;
        string LimitByteSize;
        string LimitModifier;
        string WarningByteSize;
        string WarningModifier;
        string OccupiedSpacePerc;
 

        bool modify = false;

        string to_bytes(string toBytes, string modifier)
        {
            double value = double.Parse(toBytes);
            const double BytesInKB = 1024;
            const double BytesInMB = 1048576;
            const double BytesInGB = 1073741824;
            const double BytesInTB = 1099511627776;

            switch (modifier)
            {
                case "KB":
                    if (value == 1 || value == 0)
                    {
                        return BytesInKB.ToString();
                    }
                    else
                    {
                        return ((ulong)(value * BytesInKB)).ToString();
                    }
                case "MB":
                    return ((ulong)(value * BytesInMB)).ToString();
                case "GB":
                    return ((ulong)(value * BytesInGB)).ToString();
                case "TB":
                    return ((ulong)(value * BytesInTB)).ToString();
                default:
                    return "1";
            }
        }

        public QuotaCreateForm(MainForm mf, List<string> usersForDisk)
        {
            InitializeComponent();

            this.CurrentMainFom = mf;

            UsersForDisk.Clear();
            foreach (var user in usersForDisk)
            {
                UsersForDisk.Add(user);
            }

            GetUsers();
            GetQuotaSize();

            LimitRadioButton1.Checked = true;

            LimitTextBox.Text = "1";
            LimitComboBox.SelectedItem = "KB";

            WarningTextBox.Text = "1";
            WarningComboBox.SelectedItem = "KB";


            ApplyButton.Enabled = false;
            ApplyButton.Visible = false;

            QuotaUsedLabel.Visible = false;
            QuotaUsedTextLable.Visible = false;

            QuotaRemainingLabel.Visible = false;
            QuotaRemainingTextLabel.Visible = false;

            UserTextLabel.Visible = false;

            StateLable.Visible = false;
        }

        public QuotaCreateForm(
            MainForm mf, List<string> usersForDisk,
            string state, string currentUser, string usedValue, 
            string limitValue, string warningWalue, string occupiedSpacePerc)
        {
            string[] words = new string[1];

            InitializeComponent();
            GetQuotaSize();
            UsersForDisk.Clear();
            foreach (var user in usersForDisk)
            {
                UsersForDisk.Add(user);
            }
            CurrentMainFom = mf;

            State = state;
            CurrentUser = currentUser;
            words = usedValue.Split(new char[] { ' ' });
            UsedValue = words[0];
            UsedModifier = words[1];

            if (limitValue.CompareTo("No limit") == 0 && warningWalue.CompareTo("No limit") == 0)
            {
                LimitByteSize = limitValue;
                WarningByteSize = warningWalue;

                LimitComboBox.SelectedItem = "KB";
                WarningComboBox.SelectedItem = "KB";
            }
            else
            {
                words = limitValue.Split(new char[] { ' ' });
                LimitByteSize = words[0];
                LimitModifier = words[1];
                words = warningWalue.Split(new char[] { ' ' });
                WarningByteSize = words[0];
                WarningModifier = words[1];
            }           
            OccupiedSpacePerc = occupiedSpacePerc;

            UserTextLabel.Text = CurrentUser;

            QuotaUpdate();

            //modify = true;

            UserComboBox.Visible = false;
            ApplyButton.Visible = false;
        }

        private void QuotaUpdate()
        {
            if (LimitByteSize.CompareTo("No limit") == 0 && WarningByteSize.CompareTo("No limit") == 0)
            {
                LimitRadioButton1.Checked = true;

                QuotaUsedTextLable.Text = UsedValue + " " + UsedModifier;
                QuotaRemainingTextLabel.Text = OccupiedSpacePerc;
            }
            else
            {
                LimitRadioButton2.Checked = true;

                if (CurrentUser.CompareTo(UsersForDisk[0]) == 0)
                {
                    LimitTextBox.Enabled = false;
                    LimitComboBox.Enabled = false;
                    QuotaRemainingTextLabel.Text = OccupiedSpacePerc;
                }
                else
                {
                    LimitTextBox.Enabled = true;
                    LimitTextBox.Text = LimitByteSize; //(CurrentMainFom.Bytes_to_(Int64.Parse(LimitByteSize), LimitModifier)).ToString();
                    LimitComboBox.Enabled = true;
                    LimitComboBox.SelectedItem = LimitModifier;

                    string a = to_bytes(LimitByteSize, LimitModifier);
                    string b = to_bytes(UsedValue, UsedModifier);

                    QuotaRemainingTextLabel.Text = Math.Round(CurrentMainFom.Bytes_to_(Int64.Parse(a) - Int64.Parse(b), UsedModifier), 2).ToString() + " " + UsedModifier;
                }
                WarningTextBox.Enabled = true;
                WarningTextBox.Text = WarningByteSize; //(CurrentMainFom.Bytes_to_(Int64.Parse(WarningByteSize), WarningModifier)).ToString();
                WarningComboBox.Enabled = true;
                WarningComboBox.SelectedItem = WarningModifier;

                QuotaUsedTextLable.Text = UsedValue + " " + UsedModifier + " (" + OccupiedSpacePerc + "%)";
   
            }

            StateLable.Text = State;
        }

        private void QuotaCreateForm_Load(object sender, EventArgs e)
        {

        }

        private void GetQuotaSize()
        {
            string[] size = new string[] { "KB", "MB", "GB", "TB" };

            foreach (var item in size)
            {
                try
                {
                    LimitComboBox.Items.Add(item);
                    WarningComboBox.Items.Add(item);
                }
                catch
                {
                    MessageBox.Show(
                    "Size not found!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void GetUsers()
        {
            foreach (var user in UsersForDisk)
            {
                try
                {
                    UserComboBox.Items.Add(user);
                    UserComboBox.SelectedItem = UsersForDisk[0];
                }
                catch
                {
                    MessageBox.Show(
                    "User not found!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void UserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentUser = UserComboBox.SelectedItem.ToString();
            if (LimitRadioButton2.Checked)
            {
                if (CurrentUser.CompareTo(UsersForDisk[0]) == 0)
                {
                    LimitTextBox.Enabled = false;
                    LimitComboBox.Enabled = false;
                }
                else
                {
                    LimitTextBox.Enabled = true;
                    LimitComboBox.Enabled = true;
                }
            }
        }

        private void LimitRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                LimitTextBox.Enabled = false;
                WarningTextBox.Enabled = false;

                LimitComboBox.Enabled = false;
                WarningComboBox.Enabled = false;
            }
        }

        private void LimitRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {          
                if (CurrentUser.CompareTo(UsersForDisk[0]) == 0)
                {
                    LimitTextBox.Enabled = false;
                    LimitComboBox.Enabled = false;
                }
                else
                {
                    LimitTextBox.Enabled = true;                   
                    LimitComboBox.Enabled = true;
                }
                WarningTextBox.Enabled = true;
                WarningComboBox.Enabled = true;
            }
        }

        private void LimitTextBox_TextChanged(object sender, EventArgs e)
        {
            LimitByteSize = LimitTextBox.Text;
        }

        private void WarningTextBox_TextChanged(object sender, EventArgs e)
        {
            WarningByteSize = WarningTextBox.Text;
        }

        private void LimitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void WarningTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LimitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimitModifier = LimitComboBox.SelectedItem.ToString();
        }

        private void WarningComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WarningModifier = WarningComboBox.SelectedItem.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (LimitRadioButton1.Checked)
            {
                CurrentMainFom.retName = CurrentUser;
                CurrentMainFom.retToSet = true;

                CurrentMainFom.SetEntryQuota();
            }
            else
            {
                LimitByteSize = to_bytes(LimitByteSize, LimitModifier);
                WarningByteSize = to_bytes(WarningByteSize, WarningModifier);

                CurrentMainFom.retName = CurrentUser;
                CurrentMainFom.retLimit = LimitByteSize;
                CurrentMainFom.retWarning = WarningByteSize;
                CurrentMainFom.retToSet = false;
                CurrentMainFom.SetEntryQuota();
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (LimitRadioButton1.Checked)
            {
                CurrentMainFom.retName = CurrentUser;
                CurrentMainFom.retToSet = true;

                CurrentMainFom.SetEntryQuota();
            }
            else
            {
                LimitByteSize = to_bytes(LimitByteSize, LimitModifier);
                WarningByteSize = to_bytes(WarningByteSize, WarningModifier);

                CurrentMainFom.retName = CurrentUser;
                CurrentMainFom.retLimit = LimitByteSize;
                CurrentMainFom.retWarning = WarningByteSize;
                CurrentMainFom.retToSet = false;
                CurrentMainFom.SetEntryQuota();
            }
            QuotaUpdate();
        }

    }
}
