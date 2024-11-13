using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace WPF_MVVM_SPA_Template.Models
{
    class Client
    {
        public string Name { get; set; }
        public string DniNif { get; set; }
        public string Code { get; set; }
        public bool Profesional { get; set; }
        public int Discount { get; set; } // Descuento en porcentaje
        public DateTime RegistrationDate { get; set; } // Fecha de alta
        public double TotalAnualSells { get; set; } // Ventas totales anuales
        public string Tel {  get; set; }
        public string Mail { get; set; }
        public int[] Results { get; set; } = new int[12];

        // Constructor
        public Client(string name, string dniNif, string code, bool profesional, int discount, DateTime registrationDate, double anualTotalSells, string tel, string mail)
        {
            Name = name;
            DniNif = dniNif;
            Code = code;
            Profesional = profesional;
            Discount = discount;
            RegistrationDate = registrationDate;
            TotalAnualSells = anualTotalSells;
            Tel = tel;
            Mail = mail;
            Random random = new Random();
            for (int i = 0; i < Results.Length; i++)
            {
                Results[i] = random.Next(1, 101);
            }
        }
        public  Client(Client client)
        {
            this.Name = client.Name;
            this.DniNif = client.DniNif;
            this.Code = client.Code;
            this.Profesional = client.Profesional;
            this.Discount = client.Discount;
            this.RegistrationDate = client.RegistrationDate;
            this.TotalAnualSells = client.TotalAnualSells;
            this.Tel = client.Tel;
            this.Mail = client.Mail;
            this.Results = client.Results;
           
        }
        public Client() {

            Random random = new Random();
            for (int i = 0; i < Results.Length; i++)
            {
                Results[i] = random.Next(1, 101);
            }
            RegistrationDate = DateTime.Now;
        }
        public void CloneClient(Client client)
        {
            this.Name = client.Name;
            this.DniNif = client.DniNif;
            this.Code = client.Code;
            this.Profesional = client.Profesional;
            this.Discount = client.Discount;
            this.RegistrationDate = client.RegistrationDate;
            this.TotalAnualSells = client.TotalAnualSells;
            this.Tel = client.Tel;
            this.Mail = client.Mail;
            this.Results = client.Results;
        }
    }
}
