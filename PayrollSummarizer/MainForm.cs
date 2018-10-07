using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper;

namespace PayrollSummarizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            DialogResult res = dlgOpenCSV.ShowDialog();
            if (res != DialogResult.OK)
                return;
            List<Paycheck> paychecks = GetPaychecks();

            paychecks.Sort((p1, p2) => p1.SSN.CompareTo(p2.SSN));
            List<Paycheck> bySSN = new List<Paycheck>();
            Paycheck bySSNTotal = new Paycheck();
            Paycheck currentSSN = null;
            foreach (var record in paychecks)
            {
                if (currentSSN == null || currentSSN.SSN != record.SSN)
                {
                    currentSSN = new Paycheck();
                    currentSSN.Name = record.Name;
                    currentSSN.SSN = record.SSN;
                    bySSN.Add(currentSSN);
                }
                currentSSN.Add(record);
            }
            foreach(var record in bySSN)
            {
                // We can't just add the records to each other, because the total
                // hours is total of rounded hours for each employee (not total hours rounded).
                bySSNTotal.HourlyPayHours += Math.Round(record.TotalHours);
                bySSNTotal.HourlyPay += record.GrossPay;
                bySSNTotal.StateTax += record.StateTax;
                bySSNTotal.StateTaxAdditional += record.StateTaxAdditional;
            }
            grdBySSN.Rows.Clear();
            foreach (var record in bySSN)
            {
                grdBySSN.Rows.Add(record.SSN2,
                    record.Name,
                    Math.Round(record.TotalHours).ToString(),
                    record.GrossPay.ToString("F2"),
                    record.AllSITW.ToString("F0"));
            }
            grdBySSN.Rows.Add("Total", "", 
                Math.Round(bySSNTotal.TotalHours).ToString(), 
                bySSNTotal.GrossPay.ToString("F2"), 
                bySSNTotal.AllSITW.ToString("F0"));

            paychecks.Sort((p1, p2) => p1.CreatedDate.CompareTo(p2.CreatedDate));
            List<Paycheck> byDate = new List<Paycheck>();
            Paycheck byDateTotal = new Paycheck();
            Paycheck currentDate = null;
            foreach (var record in paychecks)
            {
                if (currentDate == null || currentDate.CreatedDate != record.CreatedDate)
                {
                    currentDate = new Paycheck();
                    currentDate.CreatedDate = record.CreatedDate;
                    byDate.Add(currentDate);
                }
                currentDate.Add(record);
                byDateTotal.Add(record);
            }
            grdByDate.Rows.Clear();
            foreach (var record in byDate)
            {
                grdByDate.Rows.Add(record.CreatedDate.ToShortDateString(), record.AllSITW.ToString("F2"));
            }
            grdByDate.Rows.Add("Total", byDateTotal.AllSITW.ToString("F2"));

            txtOtterData.Text = "Otter Data:" + Environment.NewLine +
                "Subject Wages (column B): " + bySSNTotal.GrossPay.ToString("F2") + Environment.NewLine +
                "Subject Wages (columns C & D): Zero" + Environment.NewLine +
                "WBF Hours Worked: " + bySSNTotal.TotalHours.ToString("F0");
        }

        private List<Paycheck> GetPaychecks()
        {
            using (var rawReader = new System.IO.StreamReader(dlgOpenCSV.FileName))
            {
                using (var memBuffer = new System.IO.MemoryStream())
                {
                    using (var memWriter = new System.IO.StreamWriter(memBuffer))
                    {
                        string header = rawReader.ReadLine();
                        header = header.Replace(" ", "").Replace("(", "").Replace(")", "");
                        memWriter.WriteLine(header);
                        for (; ; )
                        {
                            string line = rawReader.ReadLine();
                            if (line == null)
                                break;
                            memWriter.WriteLine(line);
                        }
                        memWriter.Flush();
                        memBuffer.Position = 0;
                        using (var cleanReader = new System.IO.StreamReader(memBuffer))
                        {
                            CsvReader csv = new CsvReader(cleanReader);
                            var records = csv.GetRecords<Paycheck>();
                            return new List<Paycheck>(records);
                        }
                    }
                }
            }
        }
    }

    public class Paycheck
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public decimal HourlyPay { get; set; }
        public decimal HourlyPayHours { get; set; }
        public decimal Overtimehourly { get; set; }
        public decimal OvertimehourlyHours { get; set; }
        public decimal Vacationhourly { get; set; }
        public decimal VacationhourlyHours { get; set; }
        public decimal Sickhourlypay { get; set; }
        public decimal SickhourlypayHours { get; set; }
        public decimal Bonus { get; set; }
        //public decimal PaymentTotal { get; set; }
        public decimal OregonWCEE { get; set; }
        public decimal Draw { get; set; }
        public decimal FederalTax { get; set; }
        public decimal SocialSecurityTax { get; set; }
        public decimal MedicareTax { get; set; }
        public decimal StateTax { get; set; }
        public decimal FederalTaxAdditional { get; set; }
        public decimal StateTaxAdditional { get; set; }

        public string SSN2
        {
            get { return SSN.Replace("-", ""); }
        }

        public decimal TotalHours
        {
            get { return this.HourlyPayHours + this.OvertimehourlyHours + this.VacationhourlyHours + this.SickhourlypayHours; }
        }

        public decimal GrossPay
        {
            get { return this.HourlyPay + this.Overtimehourly + this.Vacationhourly + this.Sickhourlypay + this.Bonus; }
        }

        public decimal AllSITW
        {
            get { return this.StateTax + this.StateTaxAdditional; }
        }

        public void Add(Paycheck addend)
        {
            this.HourlyPay += addend.HourlyPay;
            this.HourlyPayHours += addend.HourlyPayHours;
            this.Overtimehourly += addend.Overtimehourly;
            this.OvertimehourlyHours += addend.OvertimehourlyHours;
            this.Vacationhourly += addend.Vacationhourly;
            this.VacationhourlyHours += addend.VacationhourlyHours;
            this.Sickhourlypay += addend.Sickhourlypay;
            this.SickhourlypayHours += addend.SickhourlypayHours;
            this.Bonus += addend.Bonus;
            //this.PaymentTotal += addend.PaymentTotal;
            this.OregonWCEE += addend.OregonWCEE;
            this.Draw += addend.Draw;
            this.FederalTax += addend.FederalTax;
            this.SocialSecurityTax += addend.SocialSecurityTax;
            this.MedicareTax += addend.MedicareTax;
            this.StateTax += addend.StateTax;
            this.FederalTaxAdditional += addend.FederalTaxAdditional;
            this.StateTaxAdditional += addend.StateTaxAdditional;
        }

        public override string ToString()
        {
            return this.Name + " " + this.SSN + " " + this.CreatedDate.ToShortDateString();
        }
    }
}
