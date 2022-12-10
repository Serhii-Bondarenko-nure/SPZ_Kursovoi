using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DiskQuota
{
    //постоянные переменные ---------------------------------------------------------------------------------------------------------------------------------


    string DiskName; //имя диска, которому пренадлежит класс

    bool Track = false; //мягкая квота, включение управление квотами
    bool Enforce = false; //жесткая квота, применяются указанные ограничения, не выделять место на диске при привышении квоты
    string QuotaTrackEnforce; //в эту строку записывается 2 строка query, которая определяет, включена мягкая или жесткая квота

    //включение регестрации квот
    bool RegLimit = false;
    bool RegWarning = false;
    string QuotaRegLimWar;


    bool LogLimit = false; //включает регистрацию превышения квоты
    bool LogWarning = false; //включает регистрацию порога предупреждения квоты

    List<Quota> Quotas = new List<Quota>(); //список существующих квот          
    List<string> Users = new List<string>();//список существующих пользователей

    //путь к файлам репорта и данных
    string PathReport = "E:\\Report.txt";
    string PathDate = "E:\\Date.txt";


    //строки для команд cmd ---------------------------------------------------------------------------------------------------------------------------------


    string EncodingCMD = "chcp 65001 && ";//задает кодировку для русского языка
    string EchoPathCMD = "> E:\\Date.txt && echo 0 > E:\\Report.txt || echo 1 > E:\\Report.txt";//последняя часть команды, путь вывода данных
    //статичные команды
    string TrackCMD = "fsutil quota Track ";
    string EnforceCMD = "fsutil quota Enforce ";
    string DisableCMD = "fsutil quota disable ";
    string QueryCMD = "fsutil quota query ";
    string UsersCMD = "wmic useraccount get name > E:\\Date.txt";
    //динамические
    string ModifyCMD = "fsutil quota modify "; //тут первая часть команды modify
    string UnlimitedModifyCMD = "fsutil quota modify "; //тут часть команды до имени пользователя
    string ValueUnlimitedModifyCMD = "18446744073709551615 "; //тут значения для безлимитной модификации, его добавлять 2 раза в команду


    //временные переменные ----------------------------------------------------------------------------------------------------------------------------------


    //получение и хранение данных до распределения
    List<string> AllDate = new List<string>();
    List<string> LoginName = new List<string>();
    List<ulong> ULUsedVolume = new List<ulong>();
    List<ulong> ULWarningThreshold = new List<ulong>();
    List<ulong> ULLimitQuota = new List<ulong>();


    //Включение и выключение дисковых квот ------------------------------------------------------------------------------------------------------------------


    //получает track
    void GetTrack()
    {
        ExecuteCommandSync(QueryCMD);
        if (ReadErrorReport())
        {
            Track = false;
        }
        else
        {
            Track = true;
        }
    }

    //получает enforce
    void GetEnforce()
    {
        ExecuteCommandSync(QueryCMD);
        if (ReadErrorReport())
        {
            Enforce = false;
        }
        else
        {
            GetQuotaTrackEnforce();
            string str = "Quotas are tracked and enforced on this volume";
            if (str.CompareTo(QuotaTrackEnforce) == 0)
            {
                Enforce = true;
                Track = true;
            }
            else
            {
                Enforce = false;
            }
        }
    }

    //получает регистрацию квот
    void GetRegLimitWarning()
    {
        ExecuteCommandSync(QueryCMD);
        if (ReadErrorReport())
        {
            RegLimit = false;
            RegWarning = false;
        }
        else
        {
            GetQuotaRegLimWar();
            string[] str = new string[] { "Logging enable for quota limits",
                "Logging enable for quota thresholds",
                "Logging enable for quota limits and threshold" };
            if (QuotaRegLimWar.CompareTo(str[2]) == 0)
            {
                RegLimit = true;
                RegWarning = true;
            }
            else if (QuotaRegLimWar.CompareTo(str[1]) == 0)
            {
                RegLimit = false;
                RegWarning = true;
            }
            else if (QuotaRegLimWar.CompareTo(str[0]) == 0)
            {
                RegLimit = true;
                RegWarning = false;
            }
            else
            {
                RegLimit = false;
                RegWarning = false;
            }
        }
    }

    //установка track
    public void SetTrack(bool set)
    {
        Clear();
        if (set)
        {
            ExecuteCommandSync(TrackCMD);
            GetTrack();
            Append();
        }
        else
        {
            ExecuteCommandSync(DisableCMD);
        }
    }

    //установка enforce
    public void SetEnforce(bool set)
    {
        Clear();
        if (set)
        {
            ExecuteCommandSync(EnforceCMD);
            GetTrack();
            GetEnforce();
            Append();
        }
        else
        {
            ExecuteCommandSync(DisableCMD);
            SetTrack(true);
        }
    }

    //устанавливает регистрацию квот
    public void SetRegLimitWarning()
    {

    }


    //возвращает track
    public bool ReturnTrack()
    {
        return Track;
    }

    //возвращает enforce
    public bool ReturnEnforce()
    {
        return Enforce;
    }

    //возвращает регистрицаию лимита квоты
    public bool ReturnRegLimit()
    {
        return RegLimit;
    }

    //возвращает регистрицаию предупреждения квоты
    public bool ReturnRegWarning()
    {
        return RegWarning;
    }


    //класс квоты -------------------------------------------------------------------------------------------------------------------------------------------


    private class Quota
    {
        //для расчетов
        ulong Missing = 18446744073709551615;
        string[] States = new string[3] { "OK", "Warning", "Limit exceeded" };
        string StateQuota = "No limit";
        string StateOccupiedSpacePerc = "N/A";

        //рабочие переменные
        ulong ULUsedVolume;
        public ulong ULLimitQuota;
        public ulong ULWarningThreshold;
        double DOccupiedSpacePerc = 0;

        //строки на выход
        public string State; //Состояние
        public string LoginName; //Имя ИД безопасности
        public string UsedVolume; //Использованная квота
        public string LimitQuota; //Предел квоты
        public string WarningThreshold; //Пороговое значение квоты
        public string OccupiedSpacePerc;


        //задать существующую
        public Quota(string loginName, ulong ulUsedVolume, ulong ulWarningThreshold, ulong ulLimitQuota)
        {
            this.LoginName = loginName;
            this.ULUsedVolume = ulUsedVolume;
            this.ULWarningThreshold = ulWarningThreshold;
            this.ULLimitQuota = ulLimitQuota;
            SetStates();
        }

        //проставляет необходимые статусы и значения на основе имеющихся данных
        public void SetStates()
        {
            //используемая квота
            UsedVolume = ULUsedVolume.ToString();
            //изменяет состояние квоты
            if (ULUsedVolume >= ULLimitQuota)
            {
                State = States[2];
            }
            else if (ULUsedVolume >= ULWarningThreshold)
            {
                State = States[1];
            }
            else
            {
                State = States[0];
            }

            //если предел квоты = отсутствию, тогда вместо числа отсутсвует, иначе число
            if (ULLimitQuota == Missing)
            {
                LimitQuota = StateQuota;
            }
            else
            {
                LimitQuota = ULLimitQuota.ToString();
            }

            //если порог предупреждения = отсутствию, тогда вместо числа отсутсвует, иначе число
            if (ULWarningThreshold == Missing)
            {
                WarningThreshold = StateQuota;
            }
            else
            {
                WarningThreshold = ULWarningThreshold.ToString();
            }

            //если нет предела и порога квоты, тогда процент квоты будет Н/Д
            if (ULLimitQuota == Missing)
            {
                OccupiedSpacePerc = StateOccupiedSpacePerc;
                DOccupiedSpacePerc = 0;
            }
            else if (ULLimitQuota < Missing && ULUsedVolume == 0)
            {
                OccupiedSpacePerc = "0";
            }
            else
            {
                DOccupiedSpacePerc = ULUsedVolume / (float)ULLimitQuota * 100;
                OccupiedSpacePerc = DOccupiedSpacePerc.ToString();
                /*
                if (State == States[2])
                {
                    DOccupiedSpacePerc = ULUsedVolume / (float)ULLimitQuota * 100;
                }
                else
                {
                    DOccupiedSpacePerc = ULUsedVolume / (float)ULLimitQuota * 100;
                }
                OccupiedSpacePerc = DOccupiedSpacePerc.ToString() + "%";
                */
            }
        }

        //пишет данные квоты (временный метод)
        public Kursovoi.MainForm.QuotaForWrite ReturnQuota()
        {
            if (OccupiedSpacePerc.CompareTo(StateOccupiedSpacePerc) == 0 || OccupiedSpacePerc.CompareTo("0") == 0)
            {
                return new Kursovoi.MainForm.QuotaForWrite(State, LoginName, UsedVolume, LimitQuota, WarningThreshold, OccupiedSpacePerc);
            }
            else
            {
                return new Kursovoi.MainForm.QuotaForWrite(State, LoginName, UsedVolume, LimitQuota, WarningThreshold, DOccupiedSpacePerc.ToString());
            }
        }
    }


    //Заполнение квот и пользователей -----------------------------------------------------------------------------------------------------------------------


    //проверка на существование записи квоты для данного пользователя
    bool IsUser(string loginName)
    {
        foreach (var quota in Quotas)
        {
            if (loginName.CompareTo(quota.LoginName) == 0)
            {
                return true;
            }
        }
        return false;
    }

    //установка/переопределение квоты
    public void SetQuota(ulong ulWarningThreshold, ulong ulLimitQuota, string loginName)
    {
        if (Track)
        {
            ExecuteCommandSync(ModifyCMD + ulWarningThreshold + " " + ulLimitQuota + " " + loginName);
            bool allow = IsUser(loginName);
            if (allow)
            {
                for (int i = 0; i < LoginName.Count(); i++)
                {
                    if (loginName.CompareTo(LoginName[i]) == 0)
                    {
                        ULWarningThreshold[i] = ulWarningThreshold;
                        ULLimitQuota[i] = ulLimitQuota;
                    }
                }
                foreach (var quota in Quotas)
                {
                    if (loginName.CompareTo(quota.LoginName) == 0)
                    {
                        quota.ULWarningThreshold = ulWarningThreshold;
                        quota.ULLimitQuota = ulLimitQuota;
                        quota.SetStates();
                    }
                }
            }
            else
            {
                InitializationQuotas();
            }
        }
    }

    //установка/переопределение квоты в безлимитную
    public void SetQuota(string loginName)
    {
        if (Track)
        {
            ExecuteCommandSync(UnlimitedModifyCMD + loginName);
            bool allow = IsUser(loginName);
            if (allow)
            {
                for (int i = 0; i < LoginName.Count(); i++)
                {
                    if (loginName.CompareTo(LoginName[i]) == 0)
                    {
                        ULLimitQuota[i] = UInt64.Parse(ValueUnlimitedModifyCMD);
                        ULWarningThreshold[i] = UInt64.Parse(ValueUnlimitedModifyCMD);
                    }
                }
                foreach (var quota in Quotas)
                {
                    if (loginName.CompareTo(quota.LoginName) == 0)
                    {
                        quota.ULLimitQuota = UInt64.Parse(ValueUnlimitedModifyCMD);
                        quota.ULWarningThreshold = UInt64.Parse(ValueUnlimitedModifyCMD);
                        quota.SetStates();
                    }
                }
            }
            else
            {
                InitializationQuotas();
            }
        }
    }

    //установка/переопределение квоты для группы администраторы
    public void SetQuota(ulong ulWarningThreshold, string adminName)
    {
        if (Track)
        {
            ExecuteCommandSync(ModifyCMD + ulWarningThreshold + " " + ValueUnlimitedModifyCMD + adminName);
            bool allow = IsUser(adminName);
            if (allow)
            {
                for (int i = 0; i < LoginName.Count(); i++)
                {
                    if (adminName.CompareTo(LoginName[i]) == 0)
                    {
                        ULWarningThreshold[i] = ulWarningThreshold;
                    }
                }
                foreach (var quota in Quotas)
                {
                    if (adminName.CompareTo(quota.LoginName) == 0)
                    {
                        quota.ULWarningThreshold = ulWarningThreshold;
                        quota.SetStates();
                    }
                }
            }
        }
    }


    //инициализирует существующие квоты, заполняет список Quotas
    void InitializationQuotas()
    {
        Quotas.Clear();
        //получение данных
        GetQuotasDate();

        //заполнение списка
        for (int i = 0; i < LoginName.Count(); i++)
        {
            Quota qt = new Quota(LoginName[i], ULUsedVolume[i], ULWarningThreshold[i], ULLimitQuota[i]);
            Quotas.Add(qt);
        }
    }

    //получает значение, квоты tracked or tracked and enforced
    void GetQuotaTrackEnforce()
    {
        ExecuteCommandSync(QueryCMD);
        ReadQuotaContent();

        QuotaTrackEnforce = AllDate[1];
    }

    //получает значение, квоты reg limit or reg warning or reg limit and warning
    void GetQuotaRegLimWar()
    {
        ExecuteCommandSync(QueryCMD);
        ReadQuotaContent();

        QuotaRegLimWar = AllDate[2];
    }

    //сортирует данные в нужные коллекции
    void GetQuotasDate()
    {
        LoginName.Clear();
        ULUsedVolume.Clear();
        ULLimitQuota.Clear();
        ULWarningThreshold.Clear();

        ExecuteCommandSync(QueryCMD);
        ReadQuotaContent();

        QuotaTrackEnforce = AllDate[1];

        for (int i = 0; i < 8; i++)
        {
            AllDate.RemoveAt(0);
        }

        for (int i = 0; i < AllDate.Count(); i += 6)
        {
            string[] words = new string[1];
            string[] words1 = new string[1];

            words = AllDate[i].Split(new char[] { '=' });
            words1 = words[1].Split(new char[] { '(' });
            LoginName.Add("\"" + words1[0].Trim() + "\"");
            words = AllDate[i + 2].Split(new char[] { '=' });
            ULUsedVolume.Add(UInt64.Parse(words[1]));
            words = AllDate[i + 3].Split(new char[] { '=' });
            ULWarningThreshold.Add(UInt64.Parse(words[1]));
            words = AllDate[i + 4].Split(new char[] { '=' });
            ULLimitQuota.Add(UInt64.Parse(words[1]));
        }

        AllDate.Clear();
    }

    //заполняет пользователей в системе
    void GetUsers()
    {
        Users.Clear();
        ExecuteCommandSync(UsersCMD);
        string machineName = Environment.MachineName;

        //дальше работает только если
        Users.Add("\"BUILTIN\\Администраторы\"");

        ReadQuotaContent(); //считываю их из файла
        AllDate.RemoveAt(0);

        //записываю в массив пользователей
        foreach (var item in AllDate)
        {
            Users.Add("\"" + machineName + "\\" + item.Trim() + "\"");
        }
        AllDate.Clear();

        //ищу возможные вхождения других заголовков пользователей
        //если есть, записываю
        foreach (var item in LoginName)
        {
            int i = 0;
            foreach (var user in Users)
            {
                if (item == user)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                Users.Add(item);
            }
        }
    }


    //возвращает коллекцию пользователей
    public void ReturnUsers(ref List<string> usersForDisk)
    {
        usersForDisk.Clear();
        foreach (var user in Users)
        {
            usersForDisk.Add(user);
        }
    }

    //возвращает коллекцию квот
    public void ReturnQuotas(ref List<Kursovoi.MainForm.QuotaForWrite> QuotasForWrite)
    {
        QuotasForWrite.Clear();
        foreach (var qt in Quotas)
        {
            QuotasForWrite.Add(qt.ReturnQuota());
        }
    }


    //чтение данных из файла --------------------------------------------------------------------------------------------------------------------------------


    //читает Report.txt
    bool ReadErrorReport()
    {
        //возвращает
        //true = 1 = ошибка
        //false = 0 = нет ошибки
        return Convert.ToBoolean(Int32.Parse(File.ReadAllText(PathReport)));
    }

    //читает Date.txt и заполняет массив временных данных
    void ReadQuotaContent()
    {
        AllDate.Clear();
        var lines = File.ReadLines(PathDate);

        foreach (var line in lines)
        {
            AllDate.Add(line.Trim());
        }
    }


    //запуск команды в cmd ----------------------------------------------------------------------------------------------------------------------------------


    //запуск cmd с командой
    void ExecuteCommandSync(object command)
    {
        try
        {
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows,
            // and then exit.
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string
            string result = proc.StandardOutput.ReadToEnd();
            // Display the command output.
            Console.WriteLine(result);
        }
        catch (Exception objException)
        {
            // Log the exception
            Console.WriteLine("Error!");
        }
    }

    //задать все основные данные для команд
    void SetCommandCMD()
    {
        TrackCMD = EncodingCMD + TrackCMD + DiskName + EchoPathCMD; ;
        EnforceCMD = EncodingCMD + EnforceCMD + DiskName + EchoPathCMD;
        DisableCMD = EncodingCMD + DisableCMD + DiskName + EchoPathCMD;
        QueryCMD = EncodingCMD + QueryCMD + DiskName + EchoPathCMD;
        ModifyCMD = EncodingCMD + ModifyCMD + DiskName;
        UnlimitedModifyCMD = EncodingCMD + UnlimitedModifyCMD + DiskName + ValueUnlimitedModifyCMD + ValueUnlimitedModifyCMD;
        UsersCMD = EncodingCMD + UsersCMD;
    }


    //конструктор(ы) ----------------------------------------------------------------------------------------------------------------------------------------

    //заполняет все данные, установка
    void Append()
    {
        InitializationQuotas();
        GetUsers();
    }

    //очищает все данные, сброс
    void Clear()
    {
        Quotas.Clear();
        Users.Clear();
        AllDate.Clear();
        LoginName.Clear();
        ULLimitQuota.Clear();
        ULUsedVolume.Clear();
        ULWarningThreshold.Clear();
        Track = false;
        Enforce = false;
        LogLimit = false;
        LogWarning = false;
    }

    public DiskQuota(string DiskName)
    {
        this.DiskName = DiskName;
        SetCommandCMD();

        GetTrack();
        if (Track)
        {
            GetEnforce();
            GetRegLimitWarning();
            Append();
        }
    }
}
