using Gauss_Jordan_Solution.CustomerItems;
using GaussJordanMethod;
using GaussJordanMethod.Controller;
using GaussJordanMethod.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Gauss_Jordan_Solution
{
    /// <summary>
    /// Interaction logic for UserControlSolve.xaml
    /// </summary>
    public partial class UserControlSolve : UserControl
    {
        public DataLoader inputLoader { get; set; }
        public SpecifiedVector vectorX { get; set; }
        public MethodSolver solver { get; set; }
        static void Process(object callback)
        {
            ((MethodSolver)callback).solveEquationsUsingGaussJordanElimination();

        }
        static void ProcessWithThreadPoolMethod(MethodSolver solver)
        {
            ThreadPool.SetMaxThreads(1, ParameterProperties.Instance.threadsNumber);
            ThreadPool.SetMinThreads(1, ParameterProperties.Instance.threadsNumber);
            ThreadPool.QueueUserWorkItem((Process), solver);
        }

        public UserControlSolve(DataLoader inputLoader, SpecifiedVector vectorX, MethodSolver solver)
        {
            InitializeComponent();
            this.inputLoader = inputLoader;
            this.vectorX = vectorX;
            this.solver = solver;
        }


        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {


            //handle the event 
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoControl.Position = new TimeSpan(0, 0, 0);
        }
        DispatcherTimer obj = new DispatcherTimer();


        private void ButtonSolveMethod_Click(object sender, RoutedEventArgs e)
        {
            ButtonSolveMethod.Visibility = Visibility.Collapsed;
            LoadingText.Visibility = Visibility.Visible;
            LoadSpinner.Visibility = Visibility.Visible;
            obj.Interval = new TimeSpan(0, 0, 5);
            obj.Start();
            obj.Tick += Obj_Tick;




        }
        private void Obj_Tick(object sender, EventArgs e)
        {
            timer_Tick();
            obj.Stop();
        }
        private readonly object balanceLock = new object();
        void timer_Tick()
        {

            SolutionsStackPanel.Visibility = Visibility.Visible;
            Stopwatch mywatch = new Stopwatch();
            try
            {
                inputLoader = new DataLoader(ParameterProperties.Instance.inFileName);
                vectorX = new SpecifiedVector(inputLoader.VectorB.numberOfRows);
                solver = new MethodSolver(inputLoader.MatrixA, inputLoader.VectorB, vectorX);
            }
            catch (Exception ex)
            {
                string exceptionMessage = string.Format("A handled exception occurred: {0}", ex.Message);
                ApplicationMessageBox.Show(exceptionMessage, "Checkbox Selection Exception", "OK");
            }



            try
            {

                if (ParameterProperties.Instance.ProgrammingLanguages["C++"] == true)
                {
                    mywatch.Start();
                    lock(balanceLock)
                    ProcessWithThreadPoolMethod(solver);
                    mywatch.Stop();
                    CExecutionTime.Text = mywatch.ElapsedTicks.ToString();
                    mywatch.Reset();
                }
                if (ParameterProperties.Instance.ProgrammingLanguages["ASM"] == true)
                {
                    //wywolanie kodu dla ASM
                }


            }
            catch (Exception ex)
            {
                string exceptionMessage = string.Format("A handled exception occurred: {0}", ex.Message);
                ApplicationMessageBox.Show(exceptionMessage, "Checkbox Selection Exception", "OK");
            }
            int xIndex = 1;
            
            for (int row = 0; row < inputLoader.matrixA.numberOfRows; row++)
            {
                for (int column = 0; column < inputLoader.matrixA.numberOfRows; column++)
                {
                    xIndex = column + 1;
                    if (inputLoader.matrixA.Data[row, column] >= 0 && column != 0)
                        Equations.Text += "+ ";
                    Equations.Text += inputLoader.matrixA.Data[row, column] + "x";

                    Equations.Text += xIndex + " ";


                }
                Equations.Text += " = " + inputLoader.vectorB.Data[row] + "\n";
            }
            Thread.Sleep(500);
           SolutionSet.Text += "Solution set: \n";
            
            for (int row=0; row<vectorX.numberOfRows; row++) 
            {
                SolutionSet.Text += "x" + xIndex + " = " + vectorX.Data[row] + "\n";
                xIndex++;
            }

        


        }

    }
}
