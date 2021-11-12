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
            set { _toyFactory = value; DisplayNext(); }
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
            ToyFactory = new BallFactory()
            {
                BallColor = btnColor.BackColor
            };

        }

        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                this.Controls.Remove(_nextToy);
            }
            _nextToy = ToyFactory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            this.Controls.Add(_nextToy);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var cd = new ColorDialog();
            cd.Color = button.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            
            button.BackColor = cd.Color;
        }

        private void prsbtn_Click(object sender, EventArgs e)
        {
            ToyFactory = new PresentFactory()
            {
                BoxColor = btncolorBox.BackColor,
                RibbonColor = btnclrRibbon.BackColor,
            };
        }
    }
}
