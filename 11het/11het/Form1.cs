using _11het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11het
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            BirthProbabilities = GetBirths(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeaths(@"C:\Temp\halál.csv");
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;           
        }

        public List<BirthProbability> GetBirths(string csvpath)
        {
            List<BirthProbability> birtList = new List<BirthProbability>();

            using (StreamReader sr  = new StreamReader(csvpath, Encoding.Default))
            {
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birtList.Add(new BirthProbability()
                    {
                        Kor = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2])
                    });
                }
            }

            return birtList;
        }

        public List<DeathProbability> GetDeaths(string csvpath)
        {
            List<DeathProbability> deaths = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deaths.Add(new DeathProbability()
                    {                     
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Kor = int.Parse(line[1]),
                        DeathP = double.Parse(line[2])
                    });
                }
            }

            return deaths;
        }
    }
}
