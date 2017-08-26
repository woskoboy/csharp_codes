using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfIntroBee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Qeen qeen;
        public MainWindow()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;

            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] {"Nectar collector", "Honey manufacturing"}, 175);
            workers[1] = new Worker(new string[] { "Egg care", "Baby bee tutoring" }, 114);
            workers[2] = new Worker(new string[] { "Hive maintenance", "Sting patrol" }, 149);
            workers[3] = new Worker(new string[] { "Nectar collector", "Honey manufacturing",
                "Egg care", "Baby bee tutoring", "Hive maintenance", "Sting patrol"  }, 155);
            this.qeen = new Qeen(workers, 275);
        }

        private void assignJob_Click(object sender, RoutedEventArgs e)
        { // раздаем задания
            int shiftsCount;
            if (int.TryParse(shifts.Text, out shiftsCount))
                if (!this.qeen.AssignWork(workerBeeJob.Text, shiftsCount))
                    MessageBox.Show(" Для этого задания рабочих нет ", " Матка говорит...");
                else
                    MessageBox.Show(" Задание будет закончено через " + shiftsCount + " смен ",
                         " Матка говорит...");
        }

        private void workShift_Click(object sender, RoutedEventArgs e)
        { // задания на следующую смену
            textBlock.Text = this.qeen.WorkTheNextShift();
        }
    }
}
