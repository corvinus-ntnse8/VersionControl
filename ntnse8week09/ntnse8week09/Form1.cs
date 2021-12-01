using ntnse8week09.Entities;
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

namespace ntnse8week09
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        List<int> males = new List<int>();
        List<int> females = new List<int>();
        public Form1()
        {
            InitializeComponent();
            BirthProbabilities = GetBirthProp(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProp(@"C:\Temp\halál.csv");

        }

        private void Simulate()
        {
            richTextBox1.Clear();
            males.Clear();
            females.Clear();
            var lastyear = numericUpDown1.Value;
            for (int year = 2005; year <= lastyear; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int NumberOfMales = (from x in Population
                                     where x.Gender == Gender.Male && x.IsAlive
                                     select x).Count();
                int NumberOfFemales = (from x in Population
                                      where x.Gender == Gender.Female && x.IsAlive
                                      select x).Count();
                males.Add(NumberOfMales);
                females.Add(NumberOfFemales);
            }
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
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

        public List<BirthProbability> GetBirthProp(string csvpath)
        {
            List<BirthProbability> birthProp = new List<BirthProbability>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProp.Add(new BirthProbability()
                    {
                        Kor = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        SzulVal = double.Parse(line[2])
                    });
                }
            }
            return birthProp;
        }

        public void SimStep(int year, Person actualPerson)
        {
            if (!actualPerson.IsAlive) return;

            int age = (int)(year - actualPerson.BirthYear);

            var deathprob = (from x in DeathProbabilities
                             where x.Gender == actualPerson.Gender && x.Kor == age
                             select x.HalVal).FirstOrDefault();

            if (rng.NextDouble() <= deathprob) actualPerson.IsAlive = false;

            if (actualPerson.IsAlive && actualPerson.Gender == Gender.Female)
            {
                var birthprob = (from x in BirthProbabilities
                                 where x.Kor == age
                                 select x.SzulVal).FirstOrDefault();

                if (rng.NextDouble() <= birthprob)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.Gender = (Gender)rng.Next(1, 3);
                    újszülött.NbrOfChildren = 0;
                    újszülött.IsAlive = true;
                    Population.Add(újszülött);
                }
            }
        }

        public List<DeathProbability> GetDeathProp(string csvpath)
        {
            List<DeathProbability> deathProp = new List<DeathProbability>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProp.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Kor = int.Parse(line[1]),
                        HalVal = double.Parse(line[2])
                    });
                }
            }
            return deathProp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Simulate();
            DisplayNext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) 
                textBox1.Text=ofd.FileName;
            Population = GetPopulation(textBox1.Text);
        }
        public void DisplayNext()
        {
            for (int i = 2005; i <= numericUpDown1.Value; i++)
            {
                richTextBox1.Text += "Szimulációs év:" + i.ToString()+"\n"+
                    "\t"+"Férfiak száma:" + males[i-2005] + "\n" +
                    "\t" + "Nők száma:" + females[i - 2005] + "\n";
            }
        }
    }
}
