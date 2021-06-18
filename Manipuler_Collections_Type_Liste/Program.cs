using System;

// namespace Manipuler_Collections_Type_Liste 

abstract class Vehicule
{
    private int matricule;
    private int modele;
    private double prix;
    private static int nb_vehicules = 0;

    public int Matricule
    {
        get { return matricule; }
    }

    public int Modele
    {
        get { return modele; }
        set { modele = value; }
    }

    public double Prix
    {
        get { return prix; }
        set { prix = value; }
    }

    public static int Nb_vehicule
    {
        get { return nb_vehicules; }
    }

    public Vehicule(int modele, double prix)
    {
        nb_vehicules++;
        matricule = nb_vehicules;
        this.modele = modele;
        this.prix = prix;
    }

    public abstract void Demarrer();
    public abstract void Accelerer();

    public override string ToString()
    {
        return "Matricule: " + matricule + " Modèle: " + modele + " Prix: " + prix;
    }

class Voiture : Vehicule
    {
        public Voiture(int modele, double prix) : base(modele, prix) { }

        public override void Demarrer()
        {
            Console.Out.WriteLine(" La voiture démarre....." );
        }

        public override void Accelerer()
        {
            Console.Out.WriteLine(" La voiture accélère....." );
        }

        public override string ToString()
        {
            return " Voiture_ " + base.ToString();
        }
    }

class Camion : Vehicule
    {
        public Camion(int modele, double prix) : base(modele, prix) { }

        public override void Demarrer()
        {
            Console.Out.WriteLine(" Le camion démarre....." );
        }

        public override void Accelerer()
        {
            Console.Out.WriteLine(" Le camion accélère....." );
        }

        public override string ToString()
        {
            return " Camion_ " + base.ToString();
        }
    }
     
class Program
    {
        static void Main(string[] args)
        {
            Voiture v = new Voiture(2005, 200000);
            Console.Out.WriteLine(v);
            v.Demarrer();
            v.Accelerer();
            Console.WriteLine();
            Camion c = new Camion(2003, 4560000);
            Console.Out.WriteLine(c);
            c.Demarrer();
            c.Accelerer();
            Console.ReadKey();
        }
    }
            


}

