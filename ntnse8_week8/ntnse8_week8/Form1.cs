using ntnse8_week8.Abstractions;
using ntnse8_week8.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntnse8_week8
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        Toy _nextToy;

        private IToyFactory _toyFactory;
        public IToyFactory ToyFactory

        {
            get { return _toyFactory; }
            set { _toyFactory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            ToyFactory = new CarFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy toy = (Toy)ToyFactory.CreateNew();
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void carbtn_Click(object sender, EventArgs e)
        {
            ToyFactory = new CarFactory();
        }

        private void ballbtn_Click(object sender, EventArgs e)
        {
            ToyFactory = new BallFactory();
        }

        private void DisplayNext()
        {

        }
    }
}
