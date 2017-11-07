using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_18_TsN
{
    class CLient
    {
        string name;
        string lastName;
        public Credits credit;
        public string Name
        { get; set; }
        public string LastName
        { get; set; }
        public CLient(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public void chooseTheCredit(Credits cr)
        {
            credit = cr;
            credit.creditIsNull = true;
        }
        public void print()
        {
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Фамилия: " + lastName);
            credit.print();
        }
        
    }
    class Banks
    {
        string nameOfBank;
        string NameOfBank { get; set; }
        public List<Credits> cr;
        public Banks(string nameOfBank, List<Credits> cr)
        {
            this.nameOfBank = nameOfBank;
            this.cr = cr;
        }
        int u;
        public Credits search(string name)
        {
            for (int i = 0; i < cr.Count; i++)
            {
                if (cr[i].nameOfCredit == name)
                {
                    u = i;
                }
            }
            return cr[u];
        }

        public void sortByNameAsc()
        {
            var sortedCredits = from c in cr
                                orderby c.nameOfCredit ascending
                                select c;
            foreach (Credits cred in sortedCredits)
                cred.print();
        }
        public void sortByNameDes()
        {
            var sortedCredits = from d in cr
                                orderby d.nameOfCredit descending
                                select d;
            foreach (Credits cred in sortedCredits)
                cred.print();
        }
        public void sortByNumbAsc()
        {
            var sortedCr = from c in cr
                                orderby c.numbOfCredit ascending
                                select c;
            foreach (Credits cred in sortedCr)
                cred.print();
        }
        public void sortByNumbDes()
        {
            var sortedCr = from c in cr
                                orderby c.numbOfCredit descending
                                select c;
            foreach (Credits cred in sortedCr)
                cred.print();
        }
    }
    class Credits : ICloneable
    {
        public string nameOfCredit;
        int moneyForLife;
        public int numbOfCredit;
        public bool creditIsNull;
        public string NameOfCredit { get; set; }
        public int MoneyForLife { get; set; }
        public int NumbOfCredit { get; set; }
        public Credits(string nameOfCredit, int moneyForLife, int numbOfCredit)
        {
            this.nameOfCredit = nameOfCredit;
            this.moneyForLife = moneyForLife;
            this.numbOfCredit = numbOfCredit;
        }
        public void pogCred(int j)
        {
            moneyForLife -= j;
            if (moneyForLife <= 0)
            {
                creditIsNull = false;
                Console.WriteLine("Кредит погашен");
                Console.WriteLine("Кредит: " + creditIsNull);
            }
            else if (moneyForLife > 0)
            {
                Console.WriteLine("Кредит не погашен");
                Console.WriteLine("Кредит: " + creditIsNull);
            }
        }
        public void popCred(int j)
        {
            moneyForLife += j;
            Console.WriteLine("Ваш кредит вырос на {0}",j);
            if (moneyForLife > 10000000)
            {
                Console.WriteLine("Welcome to jail ;)))");
            }
        }
        public void print()
        {
            Console.WriteLine("Название кредита: " + nameOfCredit);
            Console.WriteLine("Сумма кредита: " + moneyForLife);
            Console.WriteLine("Номер кредита: " + numbOfCredit);
            Console.WriteLine("Кредит: " + creditIsNull);
        }
        public Credits ShallowClone()
        {
            return (Credits)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Credits(this.nameOfCredit, this.moneyForLife, this.numbOfCredit);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество банков");
            int n = int.Parse(Console.ReadLine());
            List<Banks> b = new List<Banks>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите название банка");
                string name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите кол-во кредитов");
                int m = int.Parse(Console.ReadLine());
                List<Credits> c = new List<Credits>();
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите название кредита");
                    string nameOfCr = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Введите кредит");
                    int z1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите номер кредита");
                    int z2 = int.Parse(Console.ReadLine());
                    c.Add(new Credits(nameOfCr, z1, z2));
                }
                b.Add(new Banks(name, c));
            }
            Console.WriteLine("Введите имя клиента");
            string name2 = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите фамилию клиента");
            string lastName = Convert.ToString(Console.ReadLine());
            CLient cl = new CLient(name2, lastName);
            Console.WriteLine("Выберите кредит");
            Console.WriteLine("Введите название кредита для поиска");
            string name1 = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("Введите номер кредита для поиска");
            //int numb = int.Parse(Console.ReadLine());
            Credits X = null;
            for (int i = 0; i < b.Count; i++)
            {
               X = b[i].search(name1).ShallowClone();
            }
            cl.chooseTheCredit(X);
            cl.print();
            cl.credit.pogCred(100);
            Console.WriteLine("<------------------------------>");
            Console.WriteLine("Sort by name -> ...");
            b[0].sortByNameDes();
            Console.ReadKey();
        }
    }
}
