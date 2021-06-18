using System;

namespace Class_Abstraite_Employe
{
    abstract class Employe
    {
        private int matricule;
        private string nom;
        private string prenom;
        private DateTime datenaissance;

        public int Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime Datenaissance
        {
            get { return datenaissance; }
            set { datenaissance = value; }
        }

        public Employe(int matricule, string nom, string prenom, DateTime dn)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.datenaissance = dn;
        }

        public override string ToString()
        {
            return "Matricule: " + matricule + " Nom: " + nom + " Prénom: " + prenom + " Date de naissance :" + datenaissance.ToShortDateString();
        }

        public abstract double GetSalaire();
    }

    class Ouvrier : Employe
    {
        private DateTime dateentree;
        private static double sMIG = 2500;

        public static double SMIG
        {
            get { return sMIG; }
        }

        public DateTime Dateentree
        {
            get { return dateentree; }
            set { dateentree = value; }
        }

        public Ouvrier(int m, string n, string p, DateTime dn, DateTime de) : base(m, n, p, dn)
        {
            dateentree = de;
        }

        public override string ToString()
        {
            return "Employé:" + " " + base.ToString() + " Date d'entrée: " + dateentree.ToShortDateString();
        }

        public override double GetSalaire()
        {
            double salaire;
            int Anciennete = DateTime.Now.Year - dateentree.Year;
            if (dateentree.AddYears(Anciennete) > DateTime.Now.Date)
                Anciennete--;
            if (sMIG + Anciennete * 100 <= 2 * sMIG)
                salaire = sMIG + Anciennete * 100;
            else
                salaire = sMIG * 2;

            return salaire;
        }
    }
class Cadre : Employe
    {
        private int indice;

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public Cadre(int matricule, string nom, string prenom, DateTime dn, int indice) : base(matricule, nom, prenom, dn)
        {
            this.indice = indice;
        }

        public override string ToString()
        {
            return "Cadre: " + " " + base.ToString() + " Indice: " + indice;
        }

        public override double GetSalaire()
        {
            if (indice == 1)
                return 13000;
            else if (indice == 2)
                return 15000;
            else if (indice == 3)
                return 17000;
            else if (indice == 4)
                return 20000;
            else
                return -1;
        }
    }

class Patron : Employe
    {
        private static double ca;
        private double pourcentage;

        public static double Ca
        {
            get { return ca; }
            set { ca = value; }
        }

        public double Pourcentage
        {
            get { return pourcentage; }
            set { pourcentage = value; }
        }

        public Patron(int matricule, string nom, string prenom, DateTime dn, double p) : base(matricule, nom, prenom, dn)
        {
            this.pourcentage = p;
        }

        public override string ToString()
        {
            return "Patron: " + " " + base.ToString() + " Pourcentage: " + pourcentage + "%";
        }

        public override double GetSalaire()
        {
            return Math.Round((ca * pourcentage / 100) / 12, 2);
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            Ouvrier o = new Ouvrier(1, "Nom1", "Prenom1", new DateTime(1900, 2, 3), new DateTime(2000, 4, 5));
            Console.Out.WriteLine(o);
            Console.Out.WriteLine("Salaire de l'employé: " + o.GetSalaire());
            Console.Out.WriteLine("***********************************");
            Cadre c = new Cadre(2, "Nom2", "Prenom2", new DateTime(1986, 4, 3), 3);
            Console.Out.WriteLine(c);
            Console.Out.WriteLine("Le salaire du cadre est: " + c.GetSalaire());
            Console.Out.WriteLine("***********************************");
            Patron.Ca = 17000000;
            Patron p = new Patron(3, "Nom3", "Prenom3", new DateTime(1970, 6, 6), 3);
            Console.Out.WriteLine(p);
            Console.Out.WriteLine("Le salaire du patron est: " + p.GetSalaire());
            Console.ReadKey();
            
        }
    }
}
